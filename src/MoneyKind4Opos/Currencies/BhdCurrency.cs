using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Bahraini Dinar Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://www.cbb.gov.bh/currency-issue/">CBB - Currency Issue</seealso></description></item>
/// </list>
/// </remarks>
public class BhdCurrency :
    ICurrency,
    ICashCountFormattable<BhdCurrency>,
    ICurrencyFormattable<BhdCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.BHD;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.005m;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Fils", null, 0.001m),
    ];

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("BD", "$ n", decimalDigits: 3);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.005m, CashType.Coin, "5 Fils Coin", "5f"),
        new(0.01m, CashType.Coin, "10 Fils Coin", "10f"),
        new(0.025m, CashType.Coin, "25 Fils Coin", "25f"),
        new(0.05m, CashType.Coin, "50 Fils Coin", "50f"),
        new(0.1m, CashType.Coin, "100 Fils Coin", "100f"),
        new(0.5m, CashType.Coin, "500 Fils Coin", "500f"),
    ];
    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(0.5m, CashType.Bill, "BD 1/2", "BD 1/2"),
        new(1.0m, CashType.Bill, "BD 1", "BD 1"),
        new(5.0m, CashType.Bill, "BD 5", "BD 5"),
        new(10.0m, CashType.Bill, "BD 10", "BD 10"),
        new(20.0m, CashType.Bill, "BD 20", "BD 20"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
