using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Uzbekistani So'm Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://nationalbank.kz/en/news/banknoty">Banknotes - NBRK</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://nationalbank.kz/en/catalog/coins">Coins - NBRK</seealso></description></item>
/// </list>
/// </remarks>
public class UzsCurrency :
    ICurrency,
    ICashCountFormattable<UzsCurrency>,
    ICurrencyFormattable<UzsCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.UZS;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 50m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("soʻm", "n $", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("soʻm", "n $", decimalDigits: 2);

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
        [
            // new SubsidiaryUnit(Name: "Tiyin", Symbol: "tiyin", Ratio: 0.01m),
        ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(50m, CashType.Coin, "50 Soʻm Coin", "50 Soʻm"),
        new(100m, CashType.Coin, "100 Soʻm Coin", "100 Soʻm"),
        new(200m, CashType.Coin, "200 Soʻm Coin", "200 Soʻm"),
        new(500m, CashType.Coin, "500 Soʻm Coin", "500 Soʻm"),
        new(1000m, CashType.Coin, "1000 Soʻm Coin", "1000 Soʻm"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1000m, CashType.Bill, "1000 Soʻm Bill", "1000 Soʻm"),
        new(2000m, CashType.Bill, "2000 Soʻm Bill", "2000 Soʻm"),
        new(5000m, CashType.Bill, "5000 Soʻm Bill", "5000 Soʻm"),
        new(10000m, CashType.Bill, "10000 Soʻm Bill", "10000 Soʻm"),
        new(20000m, CashType.Bill, "20000 Soʻm Bill", "20000 Soʻm"),
        new(50000m, CashType.Bill, "50000 Soʻm Bill", "50000 Soʻm"),
        new(100000m, CashType.Bill, "100000 Soʻm Bill", "100000 Soʻm"),
        new(200000m, CashType.Bill, "200000 Soʻm Bill", "200000 Soʻm"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
