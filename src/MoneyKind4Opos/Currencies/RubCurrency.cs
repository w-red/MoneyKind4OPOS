using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Russian Ruble Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Banknotes and Coins</term><description><seealso href="https://www.cbr.ru/eng/cash_circulation/">Cash Circulation - BOR</seealso></description></item>
/// </list>
/// </remarks>
public class RubCurrency :
    ICurrency,
    ICashCountFormattable<RubCurrency>,
    ICurrencyFormattable<RubCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.RUB;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("₽", "n$", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("₽", "n$", decimalDigits: 2);

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
        [
            new SubsidiaryUnit(Name: "Kopek", Symbol: "k", Ratio: 0.01m),
        ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "1 Kopek Coin", "1K", Usage: CashUsagePolicy.NonRecyclable),
        new(0.05m, CashType.Coin, "5 Kopek Coin", "5K", Usage: CashUsagePolicy.NonRecyclable),
        new(0.10m, CashType.Coin, "10 Kopek Coin", "10K", Usage: CashUsagePolicy.NonRecyclable),
        new(0.50m, CashType.Coin, "50 Kopek Coin", "50K", Usage: CashUsagePolicy.NonRecyclable),
        new(1m, CashType.Coin, "1 ₽ Coin", "1 ₽"),
        new(2m, CashType.Coin, "2 ₽ Coin", "2 ₽"),
        new(5m, CashType.Coin, "5 ₽ Coin", "5 ₽"),
        new(10m, CashType.Coin, "10 ₽ Coin", "10 ₽"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(5m, CashType.Bill, "5 ₽ Bill", "5 ₽", Usage: CashUsagePolicy.NonRecyclable),
        new(10m, CashType.Bill, "10 ₽ Bill", "10 ₽", Usage: CashUsagePolicy.NonRecyclable),
        new(50m, CashType.Bill, "50 ₽ Bill", "50 ₽"),
        new(100m, CashType.Bill, "100 ₽ Bill", "100 ₽"),
        new(200m, CashType.Bill, "200 ₽ Bill", "200 ₽"),
        new(500m, CashType.Bill, "500 ₽ Bill", "500 ₽"),
        new(1000m, CashType.Bill, "1000 ₽ Bill", "1000 ₽"),
        new(2000m, CashType.Bill, "2000 ₽ Bill", "2000 ₽"),
        new(5000m, CashType.Bill, "5000 ₽ Bill", "5000 ₽", Usage: CashUsagePolicy.CollectionOnly),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
