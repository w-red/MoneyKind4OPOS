using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;
using System.Collections.Generic;

namespace MoneyKind4Opos.Currencies;

/// <summary>
/// Singapore Dollar Extension with Multi-language Local Support (EN/ZH/MS/TA).
/// Localizes currency names based on Singapore's four official languages.
/// </summary>
public class SgdCurrencyEx : 
    SgdCurrency,
    ICashCountFormattable<SgdCurrencyEx>,
    ICurrencyFormattable<SgdCurrencyEx>
{
    // Required by ICurrency interfaces
    public static new Iso4217 Code => SgdCurrency.Code;
    public static new decimal MinimumUnit => SgdCurrency.MinimumUnit;
    public static new bool IsZeroPadding => SgdCurrency.IsZeroPadding;
    public static new IEnumerable<ISubsidiaryUnit> SubsidiaryUnits => SgdCurrency.SubsidiaryUnits;

    // Required by ICurrencyFormattable<SgdCurrencyEx>
    public static new CurrencyFormattingOptions Global => SgdCurrency.Global;

    // Multi-language definitions for Singapore Dollar
    private static readonly Dictionary<string, (string Sub, string Main)> _localLabels = new()
    {
        { "en", ("Cent", "Dollar") },       // English
        { "zh", ("分", "元") },              // Chinese (Mandarin)
        { "ms", ("Sen", "Ringgit") },        // Malay
        { "ta", ("சதம்", "டாலர்") },         // Tamil
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
                // Use OS culture-based formatting
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
                new(0.05m, CashType.Coin, "5 Cents", $"5 {labels.Sub}"),
                new(0.10m, CashType.Coin, "10 Cents", $"10 {labels.Sub}"),
                new(0.20m, CashType.Coin, "20 Cents", $"20 {labels.Sub}"),
                new(0.50m, CashType.Coin, "50 Cents", $"50 {labels.Sub}"),
                new(1.00m, CashType.Coin, "1 Dollar", $"1 {labels.Main}"),
            ];
        }
        else
        {
            return [
                new(2m, CashType.Bill, "2 Dollars", $"2 {labels.Main}"),
                new(5m, CashType.Bill, "5 Dollars", $"5 {labels.Main}"),
                new(10m, CashType.Bill, "10 Dollars", $"10 {labels.Main}"),
                new(50m, CashType.Bill, "50 Dollars", $"50 {labels.Main}"),
                new(100m, CashType.Bill, "100 Dollars", $"100 {labels.Main}"),
                new(1000m, CashType.Bill, "1000 Dollars", $"1000 {labels.Main}"),
            ];
        }
    }
}
