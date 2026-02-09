using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>
/// Central African CFA Franc Extension with Multi-language Local Support (FR/ES/PT).
/// Localizes currency names based on the national language.
/// </summary>
public class XafCurrencyEx : 
    XafCurrency,
    ICashCountFormattable<XafCurrencyEx>,
    ICurrencyFormattable<XafCurrencyEx>
{
    // Required by ICurrency interfaces
    public static new Iso4217 Code => XafCurrency.Code;
    public static new decimal MinimumUnit => XafCurrency.MinimumUnit;
    public static new bool IsZeroPadding => XafCurrency.IsZeroPadding;
    public static new IEnumerable<ISubsidiaryUnit> SubsidiaryUnits => XafCurrency.SubsidiaryUnits;

    // Required by ICurrencyFormattable<XafCurrencyEx>
    public static new CurrencyFormattingOptions Global => XafCurrency.Global;

    // Multi-language definitions for Central African CFA Franc
    private static readonly Dictionary<string, (string Sub, string Main)> _localLabels = new()
    {
        { "fr", ("centime", "Franc CFA") },   // French (Cameroon, Central African Republic, Chad, Republic of the Congo, Gabon)
        { "es", ("céntimo", "Franco CFA") },  // Spanish (Equatorial Guinea)
        { "pt", ("cêntimo", "Franco CFA") },  // Portuguese (trade with São Tomé and Príncipe)
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

        if (isCoin)
        {
            return [
                new(1m, CashType.Coin, "1 Franc", "1 FCFA"),
                new(2m, CashType.Coin, "2 Francs", "2 FCFA"),
                new(5m, CashType.Coin, "5 Francs", "5 FCFA"),
                new(10m, CashType.Coin, "10 Francs", "10 FCFA"),
                new(25m, CashType.Coin, "25 Francs", "25 FCFA"),
                new(50m, CashType.Coin, "50 Francs", "50 FCFA"),
                new(100m, CashType.Coin, "100 Francs", "100 FCFA"),
                new(200m, CashType.Coin, "200 Francs", "200 FCFA"),
                new(500m, CashType.Coin, "500 Francs", "500 FCFA"),
            ];
        }
        else
        {
            return [
                new(500m, CashType.Bill, "500 Francs", "500 FCFA"),
                new(1000m, CashType.Bill, "1000 Francs", "1000 FCFA"),
                new(2000m, CashType.Bill, "2000 Francs", "2000 FCFA"),
                new(5000m, CashType.Bill, "5000 Francs", "5000 FCFA"),
                new(10000m, CashType.Bill, "10000 Francs", "10000 FCFA"),
            ];
        }
    }
}
