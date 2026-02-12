using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Kazakhstani Tenge Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://nationalbank.kz/en/news/banknoty">Banknotes - NBRK</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://nationalbank.kz/en/catalog/coins">Coins - NBRK</seealso></description></item>
/// </list>
/// </remarks>
public class KztCurrency :
    ICurrency,
    ICashCountFormattable<KztCurrency>,
    ICurrencyFormattable<KztCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.KZT;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 1m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("₸", "n$", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("₸", "n$", decimalDigits: 0);

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
        [];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(1m, CashType.Coin, "1 ₸ Coin", "1 ₸", Usage: CashUsagePolicy.NonRecyclable),
        new(2m, CashType.Coin, "2 ₸ Coin", "2 ₸", Usage: CashUsagePolicy.NonRecyclable),
        new(5m, CashType.Coin, "5 ₸ Coin", "5 ₸", Usage: CashUsagePolicy.NonRecyclable),
        new(10m, CashType.Coin, "10 ₸ Coin", "10 ₸", Usage: CashUsagePolicy.NonRecyclable),
        new(20m, CashType.Coin, "20 ₸ Coin", "20 ₸", Usage: CashUsagePolicy.NonRecyclable),
        new(50m, CashType.Coin, "50 ₸ Coin", "50 ₸", Usage: CashUsagePolicy.NonRecyclable),
        new(100m, CashType.Coin, "100 ₸ Coin", "100 ₸"),
        new(200m, CashType.Coin, "200 ₸ Coin", "200 ₸"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(200m, CashType.Bill, "200 ₸ Bill", "200 ₸"),
        new(500m, CashType.Bill, "500 ₸ Bill", "500 ₸"),
        new(1000m, CashType.Bill, "1000 ₸ Bill", "1000 ₸"),
        new(2000m, CashType.Bill, "2000 ₸ Bill", "2000 ₸"),
        new(5000m, CashType.Bill, "5000 ₸ Bill", "5000 ₸"),
        new(10000m, CashType.Bill, "10000 ₸ Bill", "10000 ₸"),
        new(20000m, CashType.Bill, "20000 ₸ Bill", "20000 ₸"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
