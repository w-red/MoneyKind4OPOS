using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Danish Krone Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.riksbank.se/en-gb/payments--cash/notes--coins/notes/valid-banknotes/">Valid banknotes - Sveriges Riksbank</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://www.riksbank.se/en-gb/payments--cash/notes--coins/coins/valid-coins/">Valid coins - Sveriges Riksbank</seealso></description></item>
/// </list>
/// </remarks>
public class SekCurrency :
    ICurrency,
    ICashCountFormattable<SekCurrency>,
    ICurrencyFormattable<SekCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.SEK;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 1m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("kr", "n $", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("kr", "n $", decimalDigits: 2);

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
        [
            // new SubsidiaryUnit(Name: "öre", Symbol: "ø", Ratio: 0.01m),
        ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(1m, CashType.Coin, "1 kr Coin", "1 kr"),
        new(2m, CashType.Coin, "2 kr Coin", "2 kr"),
        new(5m, CashType.Coin, "5 kr Coin", "5 kr"),
        new(10m, CashType.Coin, "10 kr Coin", "10 kr"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(20m, CashType.Bill, "20 kr Bill", "20 kr"),
        new(50m, CashType.Bill, "50 kr Bill", "50 kr"),
        new(100m, CashType.Bill, "100 kr Bill", "100 kr"),
        new(200m, CashType.Bill, "200 kr Bill", "200 kr"),
        new(500m, CashType.Bill, "500 kr Bill", "500 kr"),
        new(1000m, CashType.Bill, "1000 kr Bill", "1000 kr"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
