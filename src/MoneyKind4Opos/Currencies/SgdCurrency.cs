using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Singapore Dollar Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://www.mas.gov.sg/currency/Singapores-Currencies">Notes and Coins (Monetary Authority of Singapore)</seealso></description></item>
/// </list>
/// </remarks>
public class SgdCurrency :
    ICurrency,
    ICashCountFormattable<SgdCurrency>,
    ICurrencyFormattable<SgdCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.SGD;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.05m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("S$", "$n");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("$", "$n");

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits => [];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.05m, CashType.Coin, "5 Cents", "5¢"),
        new(0.10m, CashType.Coin, "10 Cents", "10¢"),
        new(0.20m, CashType.Coin, "20 Cents", "20¢"),
        new(0.50m, CashType.Coin, "50 Cents", "50¢"),
        new(1.00m, CashType.Coin, "1 Dollar", "$1"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(2m, CashType.Bill, "2 Dollars", "$2"),
        new(5m, CashType.Bill, "5 Dollars", "$5"),
        new(10m, CashType.Bill, "10 Dollars", "$10"),
        new(50m, CashType.Bill, "50 Dollars", "$50"),
        new(100m, CashType.Bill, "100 Dollars", "$100"),
        new(1000m, CashType.Bill, "1000 Dollars", "$1000", Usage: CashUsagePolicy.CollectionOnly),
        new(10000m, CashType.Bill, "10000 Dollars", "$10000", Usage: CashUsagePolicy.CollectionOnly),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
