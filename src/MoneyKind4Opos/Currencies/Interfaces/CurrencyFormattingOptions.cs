using MoneyKind4Opos.Codes;
using System.Globalization;

namespace MoneyKind4Opos.Currencies.Interfaces;

/// <summary>Provides options and logic for currency formatting.</summary>
/// <param name="Symbol">Currency symbol (e.g. "$", "¥", "元").</param>
/// <param name="NumberFormat">Numerical format information.</param>
/// <param name="DisplayFormat">Specific display rules.</param>
/// <param name="CustomFormatter">Optional custom logic for amount-to-string conversion.</param>
public record CurrencyFormattingOptions(
    string Symbol,
    NumberFormatInfo NumberFormat,
    CurrencyDisplayFormat DisplayFormat,
    Func<decimal, string>? CustomFormatter = null
)
{
    /// <summary>Mapping from ISO 4217 currency code to default culture name and optional symbol.
    /// null, use the 3-letter ISO code (e.g., "CHF") is used.</summary>
    private static readonly Dictionary<Iso4217, (string CultureName, string? Symbol)>
        _isoToCultureMap = new()
    {
        { Iso4217.JPY, ("ja-JP", "¥") },
        { Iso4217.USD, ("en-US", "$") },
        { Iso4217.EUR, ("de-DE", "€") },
        { Iso4217.CNY, ("zh-CN", "¥") },
        { Iso4217.GBP, ("en-GB", "£") },
        { Iso4217.AUD, ("en-AU", "$") },
        { Iso4217.CAD, ("en-CA", "$") },
        { Iso4217.CHF, ("de-CH", null) },
        { Iso4217.KRW, ("ko-KR", "₩") },
        { Iso4217.INR, ("hi-IN", "₹") },
        { Iso4217.BRL, ("pt-BR", "R$") },
        { Iso4217.MXN, ("es-MX", "$") },
        { Iso4217.SGD, ("en-SG", "$") },
        { Iso4217.HKD, ("zh-HK", "HK$") },
        { Iso4217.SEK, ("sv-SE", "kr") },
        { Iso4217.NOK, ("nb-NO", "kr") },
        { Iso4217.DKK, ("da-DK", "kr") },
        { Iso4217.NZD, ("en-NZ", "$") },
        { Iso4217.ZAR, ("en-ZA", "R") },
        { Iso4217.RUB, ("ru-RU", "₽") },
        { Iso4217.PLN, ("pl-PL", "zł") },
        { Iso4217.THB, ("th-TH", "฿") },
        { Iso4217.TWD, ("zh-TW", "NT$") },
        { Iso4217.TRY, ("tr-TR", "₺") },
    };

    /// <summary>Creates a <see cref="CurrencyFormattingOptions"/> instance from an ISO 4217 currency code.</summary>
    /// <param name="code">The ISO 4217 currency code.</param>
    /// <param name="cultureName">Optional culture name override (e.g., "fr-FR" for French Euro formatting).</param>
    /// <param name="preferThreeLetterSymbol">If true, uses the 3-letter ISO code as the symbol instead of the native symbol.</param>
    /// <param name="overrideSymbol">Optional custom symbol to use instead of the default or ISO code.</param>
    /// <returns>A configured <see cref="CurrencyFormattingOptions"/> instance.</returns>
    /// <exception cref="ArgumentException">Thrown when the currency code is not supported and no culture override is provided.</exception>
    public static CurrencyFormattingOptions FromIso4217(
        Iso4217 code,
        string? cultureName = null,
        bool preferThreeLetterSymbol = false,
        string? overrideSymbol = null)
    {
        string targetCulture;
        string symbol;

        if (cultureName != null)
        {
            // Use the provided culture override
            targetCulture = cultureName;
            symbol = _isoToCultureMap.TryGetValue(code, out var mapped)
                ? mapped.Symbol
                    ?? code.ToString()
                : code.ToString();
        }
        else if (_isoToCultureMap.TryGetValue(code, out var map))
        {
            targetCulture = map.CultureName;
            symbol =
                map.Symbol
                ?? code.ToString();
        }
        else
        {
            throw new ArgumentException(
                $"Unsupported currency code: {code}. Please provide a cultureName override.",
                nameof(code));
        }

        var culture = new CultureInfo(targetCulture);
        var nfi = (NumberFormatInfo)culture
            .NumberFormat.Clone();

        // Override symbol if 3-letter code is preferred
        nfi.CurrencySymbol =
            overrideSymbol
            ?? (
                preferThreeLetterSymbol
                ? code.ToString()
                : symbol
            );

        // Determine symbol placement based on CurrencyPositivePattern
        return new CurrencyFormattingOptions(
            Symbol: nfi.CurrencySymbol,
            NumberFormat: nfi,
            DisplayFormat: new CurrencyDisplayFormat(GetPlacement(nfi))
        );
    }

    /// <summary>Formats the specified amount using the options.</summary>
    /// <param name="amount">The decimal amount to format.</param>
    /// <param name="culture">Optional culture override for dynamic formatting.</param>
    /// <returns>A formatted string.</returns>
    public string Format(decimal amount, CultureInfo? culture = null)
    {
        var options = culture != null ? WithCulture(culture) : this;

        if (options.CustomFormatter != null)
        {
            return options.CustomFormatter(amount);
        }

        var formatted = amount.ToString("C", options.NumberFormat);

        // Apply DecimalZeroReplacement logic from DisplayFormat
        if (amount % 1 == 0
            && !string.IsNullOrEmpty(options.DisplayFormat.DecimalZeroReplacement))
        {
            var digits =
                options.NumberFormat.CurrencyDecimalDigits;
            var zeroPart =
                0
                .ToString($"F{digits}", options.NumberFormat)[1..];

            formatted = formatted.Replace(
                zeroPart,
                $"{options.DisplayFormat.DecimalSeparator}{options.DisplayFormat.DecimalZeroReplacement}");
        }

        return formatted;
    }

    /// <summary>
    /// Creates a new instance of <see cref="CurrencyFormattingOptions"/> using the numeric format
    /// of the specified culture while preserving the custom formatter logic.
    /// </summary>
    /// <param name="culture">The target culture.</param>
    /// <returns>A new <see cref="CurrencyFormattingOptions"/> instance.</returns>
    public CurrencyFormattingOptions WithCulture(CultureInfo culture)
    {
        var nfi = (NumberFormatInfo)culture.NumberFormat.Clone();

        // Merge currency identity (preserve predefined symbol and digits)
        ApplyIdentity(nfi);

        return this with
        {
            Symbol = nfi.CurrencySymbol,
            NumberFormat = nfi,
            DisplayFormat = DisplayFormat with
            {
                Placement = GetPlacement(nfi)
            }
        };
    }

    /// <summary>Apply currency identity to the specified number format.</summary>
    private void ApplyIdentity(NumberFormatInfo target)
    {
        target.CurrencySymbol = NumberFormat.CurrencySymbol;
        target.CurrencyDecimalDigits = NumberFormat.CurrencyDecimalDigits;
    }

    /// <summary>Determines symbol placement from NumberFormatInfo pattern.</summary>
    private static SymbolPlacement GetPlacement(NumberFormatInfo nfi)
    {
        return nfi.CurrencyPositivePattern switch
        {
            0 or 2 => SymbolPlacement.Prefix,
            _ => SymbolPlacement.Postfix
        };
    }
}
