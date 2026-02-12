using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>South Korean Won Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.bok.or.kr/eng/main/contents.do?menuNo=400112">Introduction to Banknotes - BOK</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://www.bok.or.kr/eng/main/contents.do?menuNo=400113">Introduction to Coins - BOK</seealso></description></item>
/// </list>
/// </remarks>
public class KrwCurrency :
    ICurrency,
    ICashCountFormattable<KrwCurrency>,
    ICurrencyFormattable<KrwCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.KRW;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 1m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("₩", "$n", decimalDigits: 0);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("₩", "$n", decimalDigits: 0);

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
        [
            // new SubsidiaryUnit(Name: "Jeon", Symbol: "jeon", Ratio: 0.001m),
        ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(1m, CashType.Coin, "₩ 1 Coin", "₩ 1", Usage: CashUsagePolicy.NonRecyclable),
        new(5m, CashType.Coin, "₩ 5 Coin", "₩ 5", Usage: CashUsagePolicy.NonRecyclable),
        new(10m, CashType.Coin, "₩ 10 Coin", "₩ 10"),
        new(50m, CashType.Coin, "₩ 50 Coin", "₩ 50"),
        new(100m, CashType.Coin, "₩ 100 Coin", "₩ 100"),
        new(500m, CashType.Coin, "₩ 500 Coin", "₩ 500"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1000m, CashType.Bill, "₩ 1000 Bill", "₩ 1000"),
        new(5000m, CashType.Bill, "₩ 5000 Bill", "₩ 5000"),
        new(10000m, CashType.Bill, "₩ 10000 Bill", "₩ 10000"),
        new(50000m, CashType.Bill, "₩ 50000 Bill", "₩ 50000", Usage: CashUsagePolicy.CollectionOnly),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
