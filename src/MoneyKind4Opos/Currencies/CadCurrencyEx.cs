using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>
/// Canadian Dollar Extension with Multi-language Local Support (EN/FR).
/// Localizes currency names and formatting based on Canadian English or French.
/// </summary>
public class CadCurrencyEx : 
    CadCurrency,
    ICashCountFormattable<CadCurrencyEx>,
    ICurrencyFormattable<CadCurrencyEx>
{
    // Required by ICurrency interfaces
    /// <inheritdoc/>
    public static new Iso4217 Code => CadCurrency.Code;
    /// <inheritdoc/>
    public static new decimal MinimumUnit => CadCurrency.MinimumUnit;
    /// <inheritdoc/>
    public static new bool IsZeroPadding => CadCurrency.IsZeroPadding;
    /// <inheritdoc/>
    public static new IEnumerable<ISubsidiaryUnit> SubsidiaryUnits => CadCurrency.SubsidiaryUnits;

    // Required by ICurrencyFormattable<CadCurrencyEx>
    /// <inheritdoc/>
    public static new CurrencyFormattingOptions Global => CadCurrency.Global;

    // Multi-language definitions for Canadian Dollar
    private static readonly Dictionary<string, (string Sub, string Main)> _localLabels = new()
    {
        { "en", ("Cent", "Dollar") },    // English Canada
        { "fr", ("cent", "dollar") },    // French Canada (lowercase is conventional)
    };

    /// <summary>
    /// Returns localized formatting options using the Canadian language conventions.
    /// </summary>
    public static new CurrencyFormattingOptions Local
    {
        get
        {
            var culture = CultureInfo.CurrentCulture;
            var lang = culture.TwoLetterISOLanguageName;
            
            if (_localLabels.TryGetValue(lang, out var labels))
            {
                // Use OS culture-based formatting with the local word as symbol
                return CurrencyFormattingOptions.FromIso4217(
                    Code, 
                    cultureName: culture.Name, 
                    overrideSymbol: "$");
            }

            return Global;
        }
    }

    /// <summary>Localized Coins Labels.</summary>
    public static new IEnumerable<CashFaceInfo> Coins => GetLocalizedFaces(isCoin: true);

    /// <summary>Localized Bills Labels.</summary>
    public static new IEnumerable<CashFaceInfo> Bills => GetLocalizedFaces(isCoin: false);

    private static IEnumerable<CashFaceInfo> GetLocalizedFaces(bool isCoin)
    {
        var lang = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
        if (!_localLabels.TryGetValue(lang, out var labels))
        {
            labels = ("Cent", "Dollar");
        }

        if (isCoin)
        {
            return [
                new(0.05m, CashType.Coin, "5 Cents", $"5 {labels.Sub}s"),
                new(0.10m, CashType.Coin, "10 Cents", $"10 {labels.Sub}s"),
                new(0.25m, CashType.Coin, "25 Cents", $"25 {labels.Sub}s"),
                new(1.00m, CashType.Coin, "1 Dollar", $"1 {labels.Main}"),
                new(2.00m, CashType.Coin, "2 Dollars", $"2 {labels.Main}s"),
            ];
        }
        else
        {
            return [
                new(5m, CashType.Bill, "5 Dollars", $"5 {labels.Main}s"),
                new(10m, CashType.Bill, "10 Dollars", $"10 {labels.Main}s"),
                new(20m, CashType.Bill, "20 Dollars", $"20 {labels.Main}s"),
                new(50m, CashType.Bill, "50 Dollars", $"50 {labels.Main}s"),
                new(100m, CashType.Bill, "100 Dollars", $"100 {labels.Main}s"),
            ];
        }
    }
}
