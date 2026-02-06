using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Georgian Lari Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description>Banknotes and Coins (National Bank of Georgia)</description></item>
/// </list>
/// </remarks>
public class GelCurrency :
    ICurrency,
    ICashCountFormattable<GelCurrency>,
    ICurrencyFormattable<GelCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.GEL;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.05m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("GEL", "$n");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("₾", "$ n");

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Tetri", null, 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.05m, CashType.Coin, "5 Tetri Coin", "0.05 ₾"),
        new(0.10m, CashType.Coin, "10 Tetri Coin", "0.10 ₾"),
        new(0.20m, CashType.Coin, "20 Tetri Coin", "0.20 ₾"),
        new(0.50m, CashType.Coin, "50 Tetri Coin", "0.50 ₾"),
        new(1m, CashType.Coin, "1 Lari Coin", "1 ₾"),
        new(2m, CashType.Coin, "2 Lari Coin", "2 ₾"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(5m, CashType.Bill, "5 Lari Bill", "5 ₾"),
        new(10m, CashType.Bill, "10 Lari Bill", "10 ₾"),
        new(20m, CashType.Bill, "20 Lari Bill", "20 ₾"),
        new(50m, CashType.Bill, "50 Lari Bill", "50 ₾"),
        new(100m, CashType.Bill, "100 Lari Bill", "100 ₾"),
        new(200m, CashType.Bill, "200 Lari Bill", "200 ₾"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
