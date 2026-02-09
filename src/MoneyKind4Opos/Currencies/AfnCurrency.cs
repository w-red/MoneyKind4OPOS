using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Afghani Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description>Banknotes and Coins (Da Afghanistan Bank)</description></item>
/// </list>
/// </remarks>
public class AfnCurrency :
    ICurrency,
    ICashCountFormattable<AfnCurrency>,
    ICurrencyFormattable<AfnCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.AFN;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 1m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("AFN", "n $", decimalDigits: 0);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("؋", "$n");

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Pul", "p", 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(1m, CashType.Coin, "1 Afghani Coin", "1 ؋"),
        new(2m, CashType.Coin, "2 Afghanis Coin", "2 ؋"),
        new(5m, CashType.Coin, "5 Afghanis Coin", "5 ؋"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1m, CashType.Bill, "1 Afghani Bill", "1 ؋"),
        new(2m, CashType.Bill, "2 Afghanis Bill", "2 ؋"),
        new(5m, CashType.Bill, "5 Afghanis Bill", "5 ؋"),
        new(10m, CashType.Bill, "10 Afghanis Bill", "10 ؋"),
        new(20m, CashType.Bill, "20 Afghanis Bill", "20 ؋"),
        new(50m, CashType.Bill, "50 Afghanis Bill", "50 ؋"),
        new(100m, CashType.Bill, "100 Afghanis Bill", "100 ؋"),
        new(500m, CashType.Bill, "500 Afghanis Bill", "500 ؋"),
        new(1000m, CashType.Bill, "1000 Afghanis Bill", "1000 ؋"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
