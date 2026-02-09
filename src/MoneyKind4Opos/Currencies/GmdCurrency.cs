using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Gambian Dalasi Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.cbg.gm/currency">Central Bank of The Gambia</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://www.cbg.gm/currency">Central Bank of The Gambia</seealso></description></item>
/// </list>
/// </remarks>
public class GmdCurrency :
    ICurrency,
    ICashCountFormattable<GmdCurrency>,
    ICurrencyFormattable<GmdCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.GMD;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("D", "$n", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Butut", "b", 0.01m)
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "1 Butut", "1b"),
        new(0.05m, CashType.Coin, "5 Bututs", "5b"),
        new(0.10m, CashType.Coin, "10 Bututs", "10b"),
        new(0.25m, CashType.Coin, "25 Bututs", "25b"),
        new(0.50m, CashType.Coin, "50 Bututs", "50b"),
        new(1m, CashType.Coin, "1 Dalasi", "D1"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(5m, CashType.Bill, "5 Dalasis", "D5"),
        new(10m, CashType.Bill, "10 Dalasis", "D10"),
        new(20m, CashType.Bill, "20 Dalasis", "D20"),
        new(50m, CashType.Bill, "50 Dalasis", "D50"),
        new(100m, CashType.Bill, "100 Dalasis", "D100"),
        new(200m, CashType.Bill, "200 Dalasis", "D200"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => true;
}
