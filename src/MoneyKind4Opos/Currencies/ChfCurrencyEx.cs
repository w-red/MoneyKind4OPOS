using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>
/// Swiss Franc Currency Extension with Multi-language Local Support (DE/FR/IT/RM).
/// Localizes currency names and denominations based on the Swiss cantonal language.
/// </summary>
public class ChfCurrencyEx : 
    ChfCurrency,
    ICashCountFormattable<ChfCurrencyEx>,
    ICurrencyFormattable<ChfCurrencyEx>
{
    // Required by ICurrency interfaces
    /// <inheritdoc/>
    public static new Iso4217 Code => ChfCurrency.Code;
    /// <inheritdoc/>
    public static new decimal MinimumUnit => ChfCurrency.MinimumUnit;
    /// <inheritdoc/>
    public static new bool IsZeroPadding => ChfCurrency.IsZeroPadding;

    // Required by ICurrencyFormattable<ChfCurrencyEx>
    /// <inheritdoc/>
    public static new CurrencyFormattingOptions Global => ChfCurrency.Global;

    // Multi-language definitions for Switzerland
    private static readonly Dictionary<string, (string Sub, string Main)> _localLabels = new()
    {
        { "de", ("Rappen", "Franken") },  // German
        { "fr", ("centime", "franc") },    // French
        { "it", ("centesimo", "franco") }, // Italian
        { "rm", ("rap", "franc") },       // Romansh
    };

    /// <summary>
    /// Returns localized formatting options using the cantonal language name.
    /// </summary>
    public static new CurrencyFormattingOptions Local
    {
        get
        {
            var culture = CultureInfo.CurrentCulture;
            var lang = culture.TwoLetterISOLanguageName;
            
            if (_localLabels.TryGetValue(lang, out var labels))
            {
                // Use the local word (e.g. "Franken") as the symbol while keeping CH formatting rules.
                return CurrencyFormattingOptions.FromIso4217(
                    Code, 
                    cultureName: culture.Name, 
                    overrideSymbol: labels.Main);
            }

            return Global;
        }
    }

    /// <summary>Localized Subsidiary Units.</summary>
    public static new IEnumerable<ISubsidiaryUnit> SubsidiaryUnits
    {
        get
        {
            var lang = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            if (!_localLabels.TryGetValue(lang, out var labels))
            {
                labels = ("Rappen", "Franken");
            }
            // Note: In Switzerland, the symbol for sub-units often varies, 
            // but we keep it simple for the label.
            return [new SubsidiaryUnit(labels.Sub, string.Empty, 0.01m)];
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
            labels = ("Rappen", "Franken");
        }

        if (isCoin)
        {
            // Note: 1/2 unit is common in Switzerland.
            return [
                new(0.05m, CashType.Coin, "0.05", $"5 {labels.Sub}"),
                new(0.10m, CashType.Coin, "0.10", $"10 {labels.Sub}"),
                new(0.20m, CashType.Coin, "0.20", $"20 {labels.Sub}"),
                new(0.50m, CashType.Coin, "1/2", $"1/2 {labels.Main}"),
                new(1.00m, CashType.Coin, "1", $"1 {labels.Main}"),
                new(2.00m, CashType.Coin, "2", $"2 {labels.Main}"),
                new(5.00m, CashType.Coin, "5", $"5 {labels.Main}"),
            ];
        }
        else
        {
            return [
                new(10.00m, CashType.Bill, "10 Bill", $"10 {labels.Main}"),
                new(20.00m, CashType.Bill, "20 Bill", $"20 {labels.Main}"),
                new(50.00m, CashType.Bill, "50 Bill", $"50 {labels.Main}"),
                new(100.00m, CashType.Bill, "100 Bill", $"100 {labels.Main}"),
                new(200.00m, CashType.Bill, "200 Bill", $"200 {labels.Main}"),
                new(1000.00m, CashType.Bill, "1000 Bill", $"1000 {labels.Main}"),
            ];
        }
    }
}
