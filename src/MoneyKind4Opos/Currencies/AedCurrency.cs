using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>United Arab Emirates Dirham Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://www.centralbank.ae/en/our-operations/currency-and-coins/circulated-currency/">CBUAE - Circulated Currency</seealso></description></item>
/// </list>
/// </remarks>
public class AedCurrency :
    ICurrency,
    ICashCountFormattable<AedCurrency>,
    ICurrencyFormattable<AedCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.AED;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Fils", null, 0.01m),
    ];

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("Dirham", "n $");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "1 Fils Coin", "1f", Usage: CashUsagePolicy.NonRecyclable),
        new(0.05m, CashType.Coin, "5 Fils Coin", "5f", Usage: CashUsagePolicy.NonRecyclable),
        new(0.10m, CashType.Coin, "10 Fils Coin", "10f", Usage: CashUsagePolicy.NonRecyclable),
        new(0.25m, CashType.Coin, "25 Fils Coin", "25f"),
        new(0.5m, CashType.Coin, "50 Fils Coin", "50f"),
        new(1.0m, CashType.Coin, "1 Dirham Coin", "100f"),
    ];
    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(5.0m, CashType.Bill, "5 Dirham Bill", "5 Dirham"),
        new(10.0m, CashType.Bill, "10 Dirham Bill", "10 Dirham"),
        new(20.0m, CashType.Bill, "20 Dirham Bill", "20 Dirham"),
        new(50.0m, CashType.Bill, "50 Dirham Bill", "50 Dirham"),
        new(100.0m, CashType.Bill, "100 Dirham Bill", "100 Dirham"),
        new(200.0m, CashType.Bill, "200 Dirham Bill", "200 Dirham"),
        new(500.0m, CashType.Bill, "500 Dirham Bill", "500 Dirham", Usage: CashUsagePolicy.CollectionOnly),
        new(1000.0m, CashType.Bill, "1000 Dirham Bill", "1000 Dirham", Usage: CashUsagePolicy.CollectionOnly),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
