using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Honduran Lempira Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://www.bch.hn/">BCH</seealso></description></item>
/// </list>
/// </remarks>
public class HnlCurrency :
    ICurrency,
    ICashCountFormattable<HnlCurrency>,
    ICurrencyFormattable<HnlCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.HNL;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.05m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("L", "$n");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("L", "$n");

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Centavo", "¢", 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.05m, CashType.Coin, "5 Centavos", "5¢"),
        new(0.10m, CashType.Coin, "10 Centavos", "10¢"),
        new(0.20m, CashType.Coin, "20 Centavos", "20¢"),
        new(0.50m, CashType.Coin, "50 Centavos", "50¢"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1m, CashType.Bill, "1 Lempira", "L1"),
        new(2m, CashType.Bill, "2 Lempiras", "L2"),
        new(5m, CashType.Bill, "5 Lempiras", "L5"),
        new(10m, CashType.Bill, "10 Lempiras", "L10"),
        new(20m, CashType.Bill, "20 Lempiras", "L20"),
        new(50m, CashType.Bill, "50 Lempiras", "L50"),
        new(100m, CashType.Bill, "100 Lempiras", "L100"),
        new(200m, CashType.Bill, "200 Lempiras", "L200"),
        new(500m, CashType.Bill, "500 Lempiras", "L500"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
