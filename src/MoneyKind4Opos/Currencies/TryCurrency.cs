using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Turkish Lira Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description>Banknotes and Coins (Central Bank of the Republic of Turkey)</description></item>
/// </list>
/// </remarks>
public class TryCurrency :
    ICurrency,
    ICashCountFormattable<TryCurrency>,
    ICurrencyFormattable<TryCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.TRY;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("TRY", "$ n");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("₺", "$ n");

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Kurus", null, 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "1 Kurus Coin", "0.01 ₺", Usage: CashUsagePolicy.NonRecyclable),
        new(0.05m, CashType.Coin, "5 Kurus Coin", "0.05 ₺"),
        new(0.10m, CashType.Coin, "10 Kurus Coin", "0.10 ₺"),
        new(0.25m, CashType.Coin, "25 Kurus Coin", "0.25 ₺"),
        new(0.50m, CashType.Coin, "50 Kurus Coin", "0.50 ₺"),
        new(1m, CashType.Coin, "1 Lira Coin", "1 ₺"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(5m, CashType.Bill, "5 Lira Bill", "5 ₺"),
        new(10m, CashType.Bill, "10 Lira Bill", "10 ₺"),
        new(20m, CashType.Bill, "20 Lira Bill", "20 ₺"),
        new(50m, CashType.Bill, "50 Lira Bill", "50 ₺"),
        new(100m, CashType.Bill, "100 Lira Bill", "100 ₺"),
        new(200m, CashType.Bill, "200 Lira Bill", "200 ₺", Usage: CashUsagePolicy.CollectionOnly),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
