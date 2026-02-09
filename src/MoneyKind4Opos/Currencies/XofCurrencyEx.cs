using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>
/// West African CFA Franc Extension with Multi-language Local Support (FR/PT).
/// Localizes currency names based on the national language (French or Portuguese for Guinea-Bissau).
/// </summary>
public class XofCurrencyEx : 
    XofCurrency,
    ICashCountFormattable<XofCurrencyEx>,
    ICurrencyFormattable<XofCurrencyEx>
{
    // Required by ICurrency interfaces
    public static new Iso4217 Code => XofCurrency.Code;
    public static new decimal MinimumUnit => XofCurrency.MinimumUnit;
    public static new bool IsZeroPadding => XofCurrency.IsZeroPadding;
    public static new IEnumerable<ISubsidiaryUnit> SubsidiaryUnits => XofCurrency.SubsidiaryUnits;

    // Required by ICurrencyFormattable<XofCurrencyEx>
    public static new CurrencyFormattingOptions Global => XofCurrency.Global;

    // Multi-language definitions for West African CFA Franc
    private static readonly Dictionary<string, (string Sub, string Main)> _localLabels = new()
    {
        { "fr", ("centime", "Franc CFA") },   // French (Benin, Burkina Faso, Côte d'Ivoire, Mali, Niger, Senegal, Togo)
        { "pt", ("cêntimo", "Franco CFA") },  // Portuguese (Guinea-Bissau)
    };

    /// <summary>
    /// Returns localized formatting options using the national language name.
    /// </summary>
    public static new CurrencyFormattingOptions Local
    {
        get
        {
            var culture = CultureInfo.CurrentCulture;
            var lang = culture.TwoLetterISOLanguageName;
            
            if (_localLabels.TryGetValue(lang, out var labels))
            {
                return CurrencyFormattingOptions.Create(
                    labels.Main, "n $", 
                    decimalDigits: 0, 
                    groupSep: " ");
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
            labels = ("centime", "Franc CFA");
        }

        var abbr = lang == "pt" ? "FCFA" : "CFA";

        if (isCoin)
        {
            return [
                new(1m, CashType.Coin, "1 Franc", $"1 {abbr}"),
                new(5m, CashType.Coin, "5 Francs", $"5 {abbr}"),
                new(10m, CashType.Coin, "10 Francs", $"10 {abbr}"),
                new(25m, CashType.Coin, "25 Francs", $"25 {abbr}"),
                new(50m, CashType.Coin, "50 Francs", $"50 {abbr}"),
                new(100m, CashType.Coin, "100 Francs", $"100 {abbr}"),
                new(200m, CashType.Coin, "200 Francs", $"200 {abbr}"),
                new(500m, CashType.Coin, "500 Francs", $"500 {abbr}"),
            ];
        }
        else
        {
            return [
                new(500m, CashType.Bill, "500 Francs", $"500 {abbr}"),
                new(1000m, CashType.Bill, "1000 Francs", $"1000 {abbr}"),
                new(2000m, CashType.Bill, "2000 Francs", $"2000 {abbr}"),
                new(5000m, CashType.Bill, "5000 Francs", $"5000 {abbr}"),
                new(10000m, CashType.Bill, "10000 Francs", $"10000 {abbr}"),
            ];
        }
    }
}
