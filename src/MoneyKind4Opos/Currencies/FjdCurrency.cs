using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Fiji Dollar Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.rbf.gov.fj/currency/">Reserve Bank of Fiji</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://www.rbf.gov.fj/currency/">RBF</seealso></description></item>
/// </list>
/// </remarks>
public class FjdCurrency :
    ICurrency,
    ICashCountFormattable<FjdCurrency>,
    ICurrencyFormattable<FjdCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.FJD;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.05m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("FJ$", "$n", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Cent", "c", 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.05m, CashType.Coin, "5 Cents", "5c"),
        new(0.10m, CashType.Coin, "10 Cents", "10c"),
        new(0.20m, CashType.Coin, "20 Cents", "20c"),
        new(0.50m, CashType.Coin, "50 Cents", "50c"),
        new(1.00m, CashType.Coin, "1 Dollar", "$1"),
        new(2.00m, CashType.Coin, "2 Dollars", "$2"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(5m, CashType.Bill, "5 Dollars", "$5"),
        new(7m, CashType.Bill, "7 Dollars", "$7"),
        new(10m, CashType.Bill, "10 Dollars", "$10"),
        new(20m, CashType.Bill, "20 Dollars", "$20"),
        new(50m, CashType.Bill, "50 Dollars", "$50"),
        new(100m, CashType.Bill, "100 Dollars", "$100"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
