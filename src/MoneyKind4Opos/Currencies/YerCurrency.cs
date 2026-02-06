using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Yemeni Rial Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description>Banknotes and Coins (Central Bank of Yemen)</description></item>
/// </list>
/// </remarks>
public class YerCurrency :
    ICurrency,
    ICashCountFormattable<YerCurrency>,
    ICurrencyFormattable<YerCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.YER;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 1.0m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("YER", "n $", decimalDigits: 0);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("﷼", "$ n");

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Fils", null, 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(1m, CashType.Coin, "1 Rial Coin", "1 ﷼"),
        new(5m, CashType.Coin, "5 Rial Coin", "5 ﷼"),
        new(10m, CashType.Coin, "10 Rial Coin", "10 ﷼"),
        new(20m, CashType.Coin, "20 Rial Coin", "20 ﷼"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(50m, CashType.Bill, "50 Rial Bill", "50 ﷼"),
        new(100m, CashType.Bill, "100 Rial Bill", "100 ﷼"),
        new(200m, CashType.Bill, "200 Rial Bill", "200 ﷼"),
        new(250m, CashType.Bill, "250 Rial Bill", "250 ﷼"),
        new(500m, CashType.Bill, "500 Rial Bill", "500 ﷼"),
        new(1000m, CashType.Bill, "1000 Rial Bill", "1000 ﷼"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
