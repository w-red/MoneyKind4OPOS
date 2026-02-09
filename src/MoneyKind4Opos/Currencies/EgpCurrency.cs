using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Egyptian Pound Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.cbe.org.eg/">Central Bank of Egypt</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://www.cbe.org.eg/">Central Bank of Egypt</seealso></description></item>
/// </list>
/// </remarks>
public class EgpCurrency :
    ICurrency,
    ICashCountFormattable<EgpCurrency>,
    ICurrencyFormattable<EgpCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.EGP;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.05m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("E£", "$n", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Piastre", "pt", 0.01m)
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.05m, CashType.Coin, "5 Piastres", "5pt"),
        new(0.10m, CashType.Coin, "10 Piastres", "10pt"),
        new(0.20m, CashType.Coin, "20 Piastres", "20pt"),
        new(0.25m, CashType.Coin, "25 Piastres", "25pt"),
        new(0.50m, CashType.Coin, "50 Piastres", "50pt"),
        new(1m, CashType.Coin, "1 Pound", "£1"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(5m, CashType.Bill, "5 Pounds", "£5"),
        new(10m, CashType.Bill, "10 Pounds", "£10"),
        new(20m, CashType.Bill, "20 Pounds", "£20"),
        new(50m, CashType.Bill, "50 Pounds", "£50"),
        new(100m, CashType.Bill, "100 Pounds", "£100"),
        new(200m, CashType.Bill, "200 Pounds", "£200"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => true;
}
