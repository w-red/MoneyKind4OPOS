using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Maldives Rufiyaa Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="http://www.mma.gov.mv/#/currency/notesincirculation">Notes in Circulation (Maldives Monetary Authority)</seealso></description></item>
/// </list>
/// </remarks>
public class MvrCurrency :
    ICurrency,
    ICashCountFormattable<MvrCurrency>,
    ICurrencyFormattable<MvrCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.MVR;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("MVR", "$ n");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("Rf", "$ n");

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Laari", "L", 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "1 Laari Coin", "1 L", Usage: CashUsagePolicy.NonRecyclable),
        new(0.05m, CashType.Coin, "5 Laari Coin", "5 L", Usage: CashUsagePolicy.NonRecyclable),
        new(0.10m, CashType.Coin, "10 Laari Coin", "10 L", Usage: CashUsagePolicy.NonRecyclable),
        new(0.25m, CashType.Coin, "25 Laari Coin", "25 L", Usage: CashUsagePolicy.NonRecyclable),
        new(0.50m, CashType.Coin, "50 Laari Coin", "50 L", Usage: CashUsagePolicy.NonRecyclable),
        new(1m, CashType.Coin, "1 Rufiyaa Coin", "Rf 1"),
        new(2m, CashType.Coin, "2 Rufiyaa Coin", "Rf 2"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(5m, CashType.Bill, "5 Rufiyaa Bill", "Rf 5"),
        new(10m, CashType.Bill, "10 Rufiyaa Bill", "Rf 10"),
        new(20m, CashType.Bill, "20 Rufiyaa Bill", "Rf 20"),
        new(50m, CashType.Bill, "50 Rufiyaa Bill", "Rf 50"),
        new(100m, CashType.Bill, "100 Rufiyaa Bill", "Rf 100"),
        new(500m, CashType.Bill, "500 Rufiyaa Bill", "Rf 500"),
        new(1000m, CashType.Bill, "1000 Rufiyaa Bill", "Rf 1000"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
