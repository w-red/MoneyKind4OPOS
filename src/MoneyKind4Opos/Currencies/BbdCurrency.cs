using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Barbados Dollar Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.centralbank.org.bb/banknotes">CBB (Central Bank of Barbados)</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://www.centralbank.org.bb/">CBB</seealso></description></item>
/// </list>
/// <para>※ The 1-cent coin has been discontinued.</para>
/// </remarks>
public class BbdCurrency :
    ICurrency,
    ICashCountFormattable<BbdCurrency>,
    ICurrencyFormattable<BbdCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.BBD;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.05m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("$", "$n", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("Bds$", "$n", decimalDigits: 2);

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Cent", "¢", 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.05m, CashType.Coin, "5 Cents", "5¢"),
        new(0.10m, CashType.Coin, "10 Cents", "10¢"),
        new(0.25m, CashType.Coin, "25 Cents", "25¢"),
        new(1.00m, CashType.Coin, "1 Dollar", "Bds$1"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(2m, CashType.Bill, "2 Dollars", "Bds$2"),
        new(5m, CashType.Bill, "5 Dollars", "Bds$5"),
        new(10m, CashType.Bill, "10 Dollars", "Bds$10"),
        new(20m, CashType.Bill, "20 Dollars", "Bds$20"),
        new(50m, CashType.Bill, "50 Dollars", "Bds$50"),
        new(100m, CashType.Bill, "100 Dollars", "Bds$100"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
