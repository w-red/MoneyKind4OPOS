using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Mexican Peso Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://www.banxico.org.mx/banknotes-and-coins/currently-banknotes-and-coins.html">Banknotes and Coins - BdM</seealso></description></item>
/// </list>
/// </remarks>
public class MxnCurrency :
    ICurrency,
    ICashCountFormattable<MxnCurrency>,
    ICurrencyFormattable<MxnCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.MXN;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.05m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("Mex$", "$n", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("$", "$n", decimalDigits: 2);

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
        [
            new SubsidiaryUnit(Name: "Centavo", Symbol: "¢", Ratio: 0.01m),
        ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.05m, CashType.Coin, "5¢ Coin", "5¢"),
        new(0.1m, CashType.Coin, "10¢ Coin", "10¢"),
        new(0.2m, CashType.Coin, "20¢ Coin", "20¢"),
        new(0.5m, CashType.Coin, "50¢ Coin", "50¢"),
        new(1m, CashType.Coin, "$ 1 Coin", "$ 1"),
        new(2m, CashType.Coin, "$ 2 Coin", "$ 2"),
        new(5m, CashType.Coin, "$ 5 Coin", "$ 5"),
        new(10m, CashType.Coin, "$ 10 Coin", "$ 10"),
        new(20m, CashType.Coin, "$ 20 Coin", "$ 20"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(20m, CashType.Bill, "$ 20 Bill", "$ 20"),
        new(50m, CashType.Bill, "$ 50 Bill", "$ 50"),
        new(100m, CashType.Bill, "$ 100 Bill", "$ 100"),
        new(200m, CashType.Bill, "$ 200 Bill", "$ 200"),
        new(500m, CashType.Bill, "$ 500 Bill", "$ 500"),
        new(1000m, CashType.Bill, "$ 1000 Bill", "$ 1000"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
