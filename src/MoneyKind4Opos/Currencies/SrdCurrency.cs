using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Suriname Dollar Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://www.cbvs.sr/en/financial-system/currency/security-features">Centrale Bank van Suriname - Banknotes and Coins</seealso></description></item>
/// </list>
/// </remarks>
public class SrdCurrency :
    ICurrency,
    ICashCountFormattable<SrdCurrency>,
    ICurrencyFormattable<SrdCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.SRD;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Cent", null, 0.01m),
    ];

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("SRD", "$n");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("$", "$n");

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "1 Cent Coin", "1 cent"),
        new(0.05m, CashType.Coin, "5 Cents Coin", "5 cents"),
        new(0.10m, CashType.Coin, "10 Cents Coin", "10 cents"),
        new(0.25m, CashType.Coin, "25 Cents Coin", "25 cents"),
        new(1.00m, CashType.Coin, "100 Cents Coin", "100 cents"), // or 1 Dollar
        new(2.50m, CashType.Coin, "250 Cents Coin", "250 cents"), // or 2 1/2 Dollars
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(5.0m, CashType.Bill, "5 Dollars Bill", "$5"),
        new(10.0m, CashType.Bill, "10 Dollars Bill", "$10"),
        new(20.0m, CashType.Bill, "20 Dollars Bill", "$20"),
        new(50.0m, CashType.Bill, "50 Dollars Bill", "$50"),
        new(100.0m, CashType.Bill, "100 Dollars Bill", "$100"),
        new(200.0m, CashType.Bill, "200 Dollars Bill", "$200"),
        new(500.0m, CashType.Bill, "500 Dollars Bill", "$500"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
