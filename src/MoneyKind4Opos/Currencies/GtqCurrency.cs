using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Guatemalan Quetzal Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://banguat.gob.gt/">Banguat</seealso></description></item>
/// </list>
/// </remarks>
public class GtqCurrency :
    ICurrency,
    ICashCountFormattable<GtqCurrency>,
    ICurrencyFormattable<GtqCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.GTQ;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("Q", "$n");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("Q", "$n");

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits => [];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "1 Centavo", "1¢"),
        new(0.05m, CashType.Coin, "5 Centavos", "5¢"),
        new(0.10m, CashType.Coin, "10 Centavos", "10¢"),
        new(0.25m, CashType.Coin, "25 Centavos", "25¢"),
        new(0.50m, CashType.Coin, "50 Centavos", "50¢"),
        new(1.00m, CashType.Coin, "1 Quetzal", "Q1"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1m, CashType.Bill, "1 Quetzal", "Q1"),
        new(5m, CashType.Bill, "5 Quetzales", "Q5"),
        new(10m, CashType.Bill, "10 Quetzales", "Q10"),
        new(20m, CashType.Bill, "20 Quetzales", "Q20"),
        new(50m, CashType.Bill, "50 Quetzales", "Q50"),
        new(100m, CashType.Bill, "100 Quetzales", "Q100"),
        new(200m, CashType.Bill, "200 Quetzales", "Q200"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
