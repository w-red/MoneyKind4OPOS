using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Liberian Dollar Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.cbl.org.lr/currency-management">Central Bank of Liberia</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://www.cbl.org.lr/currency-management">Central Bank of Liberia</seealso></description></item>
/// </list>
/// </remarks>
public class LrdCurrency :
    ICurrency,
    ICashCountFormattable<LrdCurrency>,
    ICurrencyFormattable<LrdCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.LRD;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.05m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("L$", "$n", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Cent", "c", 0.01m)
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.05m, CashType.Coin, "5 Cents", "5c"),
        new(0.10m, CashType.Coin, "10 Cents", "10c"),
        new(0.25m, CashType.Coin, "25 Cents", "25c"),
        new(0.50m, CashType.Coin, "50 Cents", "50c"),
        new(1m, CashType.Coin, "1 Dollar", "$1"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(5m, CashType.Bill, "5 Dollars", "$5"),
        new(10m, CashType.Bill, "10 Dollars", "$10"),
        new(20m, CashType.Bill, "20 Dollars", "$20"),
        new(50m, CashType.Bill, "50 Dollars", "$50"),
        new(100m, CashType.Bill, "100 Dollars", "$100"),
        new(500m, CashType.Bill, "500 Dollars", "$500"),
        new(1000m, CashType.Bill, "1000 Dollars", "$1000"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => true;
}
