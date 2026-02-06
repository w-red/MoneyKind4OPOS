using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Bangladesh Taka Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://www.bb.org.bd/en/index.php/currency/index">Currency (Bangladesh Bank)</seealso></description></item>
/// </list>
/// </remarks>
public class BdtCurrency :
    ICurrency,
    ICashCountFormattable<BdtCurrency>,
    ICurrencyFormattable<BdtCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.BDT;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 1m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("BDT", "$n", groupSizes: [3, 2]);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("৳", "$n", groupSizes: [3, 2]);

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Poisha", "p", 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(1m, CashType.Coin, "1 Taka Coin", "১ ৳"),
        new(2m, CashType.Coin, "2 Taka Coin", "২ ৳"),
        new(5m, CashType.Coin, "5 Taka Coin", "৫ ৳"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(2m, CashType.Bill, "2 Taka Bill", "২ ৳"),
        new(5m, CashType.Bill, "5 Taka Bill", "৫ ৳"),
        new(10m, CashType.Bill, "10 Taka Bill", "১০ ৳"),
        new(20m, CashType.Bill, "20 Taka Bill", "২০ ৳"),
        new(50m, CashType.Bill, "50 Taka Bill", "৫০ ৳"),
        new(100m, CashType.Bill, "100 Taka Bill", "১০০ ৳"),
        new(200m, CashType.Bill, "200 Taka Bill", "২০০ ৳"),
        new(500m, CashType.Bill, "500 Taka Bill", "৫০০ ৳"),
        new(1000m, CashType.Bill, "1000 Taka Bill", "১০০০ ৳"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
