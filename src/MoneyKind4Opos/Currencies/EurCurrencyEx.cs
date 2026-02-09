using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>
/// Euro Currency Extension with Multi-language Local Support.
/// This class demonstrates how to localize denominations and formatting based on the current culture.
/// </summary>
public class EurCurrencyEx : 
    EurCurrency,
    ICashCountFormattable<EurCurrencyEx>, // Bind static members to this type
    ICurrencyFormattable<EurCurrencyEx>
{
    // Required by ICurrency through interfaces
    public static new Iso4217 Code => EurCurrency.Code;
    public static new decimal MinimumUnit => EurCurrency.MinimumUnit;
    public static new IEnumerable<ISubsidiaryUnit> SubsidiaryUnits => EurCurrency.SubsidiaryUnits;

    // Required by ICurrencyFormattable<EurCurrencyEx>
    public static new CurrencyFormattingOptions Global => EurCurrency.Global;
    public static new bool IsZeroPadding => EurCurrency.IsZeroPadding;

    // Locally used labels for "Euro" and "Cent" in various languages
    private static readonly Dictionary<string, (string Cent, string Euro)> _localLabels = new()
    {
        { "bg", ("евроцент", "евро") }, // Bulgarian
        { "el", ("λεπτό", "ευρώ") },    // Greek
        { "fr", ("centime", "euro") },   // French
        { "es", ("céntimo", "euro") },   // Spanish
        { "it", ("centesimo", "euro") }, // Italian
        { "pt", ("cêntimo", "euro") },   // Portuguese
        { "de", ("Cent", "Euro") },      // German
    };

    /// <summary>
    /// Returns localized formatting options (using words like 'евро' instead of '€' when applicable).
    /// </summary>
    public static new CurrencyFormattingOptions Local
    {
        get
        {
            var culture = CultureInfo.CurrentCulture;
            var lang = culture.TwoLetterISOLanguageName;
            
            if (_localLabels.TryGetValue(lang, out var labels))
            {
                // Return formatting options using the local word as the symbol, 
                // but respecting the current culture's patterns and separators.
                return CurrencyFormattingOptions.FromIso4217(
                    Code, 
                    cultureName: culture.Name, 
                    overrideSymbol: labels.Euro);
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
            labels = ("Cent", "Euro");
        }

        return isCoin
            ? [
                new(0.01m, CashType.Coin, "1 Cent Coin", $"1 {labels.Cent}"),
                new(0.02m, CashType.Coin, "2 Cent Coin", $"2 {labels.Cent}"),
                new(0.05m, CashType.Coin, "5 Cent Coin", $"5 {labels.Cent}"),
                new(0.10m, CashType.Coin, "10 Cent Coin", $"10 {labels.Cent}"),
                new(0.20m, CashType.Coin, "20 Cent Coin", $"20 {labels.Cent}"),
                new(0.50m, CashType.Coin, "50 Cent Coin", $"50 {labels.Cent}"),
                new(1.00m, CashType.Coin, "1 Euro Coin", $"1 {labels.Euro}"),
                new(2.00m, CashType.Coin, "2 Euro Coin", $"2 {labels.Euro}"),
            ]
            : [
                new(5.00m, CashType.Bill, "5 Euro Bill", $"5 {labels.Euro}"),
                new(10.00m, CashType.Bill, "10 Euro Bill", $"10 {labels.Euro}"),
                new(20.00m, CashType.Bill, "20 Euro Bill", $"20 {labels.Euro}"),
                new(50.00m, CashType.Bill, "50 Euro Bill", $"50 {labels.Euro}"),
                new(100.00m, CashType.Bill, "100 Euro Bill", $"100 {labels.Euro}"),
                new(200.00m, CashType.Bill, "200 Euro Bill", $"200 {labels.Euro}"),
                new(500.00m, CashType.Bill, "500 Euro Bill", $"500 {labels.Euro}"),
            ];
    }
}
