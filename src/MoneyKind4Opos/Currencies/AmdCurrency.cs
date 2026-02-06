using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Armenian Dram Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://www.cba.am/en/SitePages/nccbanknotes.aspx">Banknotes and Coins (Central Bank of Armenia)</seealso></description></item>
/// </list>
/// </remarks>
public class AmdCurrency :
    ICurrency,
    ICashCountFormattable<AmdCurrency>,
    ICurrencyFormattable<AmdCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.AMD;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 10.0m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("AMD", "$n", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("֏", "$ n", decimalDigits: 2);

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Luma", null, 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(10m, CashType.Coin, "10 Dram Coin", "10 ֏"),
        new(20m, CashType.Coin, "20 Dram Coin", "20 ֏"),
        new(50m, CashType.Coin, "50 Dram Coin", "50 ֏"),
        new(100m, CashType.Coin, "100 Dram Coin", "100 ֏"),
        new(200m, CashType.Coin, "200 Dram Coin", "200 ֏"),
        new(500m, CashType.Coin, "500 Dram Coin", "500 ֏"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1000m, CashType.Bill, "1000 Dram Bill", "1000 ֏"),
        new(2000m, CashType.Bill, "2000 Dram Bill", "2000 ֏"),
        new(5000m, CashType.Bill, "5000 Dram Bill", "5000 ֏"),
        new(10000m, CashType.Bill, "10000 Dram Bill", "10000 ֏"),
        new(20000m, CashType.Bill, "20000 Dram Bill", "20000 ֏"),
        new(50000m, CashType.Bill, "50000 Dram Bill", "50000 ֏"),
        new(100000m, CashType.Bill, "100000 Dram Bill", "100000 ֏"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
