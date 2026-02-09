using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Syrian Pound Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description>Banknotes and Coins (Central Bank of Syria)</description></item>
/// </list>
/// </remarks>
public class SypCurrency :
    ICurrency,
    ICashCountFormattable<SypCurrency>,
    ICurrencyFormattable<SypCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.SYP;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 1.0m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("SYP", "n $", decimalDigits: 0);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("LS", "$ n");

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Piastre", null, 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(1m, CashType.Coin, "1 Pound Coin", "1 LS"),
        new(2m, CashType.Coin, "2 Pound Coin", "2 LS"),
        new(5m, CashType.Coin, "5 Pound Coin", "5 LS"),
        new(10m, CashType.Coin, "10 Pound Coin", "10 LS"),
        new(25m, CashType.Coin, "25 Pound Coin", "25 LS"),
        new(50m, CashType.Coin, "50 Pound Coin", "50 LS"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(50m, CashType.Bill, "50 Pound Bill", "50 LS"),
        new(100m, CashType.Bill, "100 Pound Bill", "100 LS"),
        new(200m, CashType.Bill, "200 Pound Bill", "200 LS"),
        new(500m, CashType.Bill, "500 Pound Bill", "500 LS"),
        new(1000m, CashType.Bill, "1000 Pound Bill", "1000 LS"),
        new(2000m, CashType.Bill, "2000 Pound Bill", "2000 LS"),
        new(5000m, CashType.Bill, "5000 Pound Bill", "5000 LS"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
