using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Saudi Riyal Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Currency</term><description><seealso href="https://www.sama.gov.sa/en-US/Currency/pages/sixthissue.aspx">SAMA - Sixth Issue</seealso></description></item>
/// </list>
/// </remarks>
public class SarCurrency :
    ICurrency,
    ICashCountFormattable<SarCurrency>,
    ICurrencyFormattable<SarCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.SAR;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Halala", null, 0.01m),
    ];

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("SR", "$ n", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "1 Halala Coin", "1h", Usage: CashUsagePolicy.NonRecyclable),
        new(0.05m, CashType.Coin, "5 Halala Coin", "5h", Usage: CashUsagePolicy.NonRecyclable),
        new(0.10m, CashType.Coin, "10 Halala Coin", "10h", Usage: CashUsagePolicy.NonRecyclable),
        new(0.25m, CashType.Coin, "25 Halala Coin", "25h", Usage: CashUsagePolicy.NonRecyclable),
        new(0.50m, CashType.Coin, "50 Halala Coin", "50h", Usage: CashUsagePolicy.NonRecyclable),
        new(1.00m, CashType.Coin, "1 Riyal Coin", "SR 1"),
        new(2.00m, CashType.Coin, "2 Riyal Coin", "SR 2"),
    ];
    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(5.0m, CashType.Bill, "5 Riyal Bill", "SR 5"),
        new(10.0m, CashType.Bill, "10 Riyal Bill", "SR 10"),
        new(50.0m, CashType.Bill, "50 Riyal Bill", "SR 50"),
        new(100.0m, CashType.Bill, "100 Riyal Bill", "SR 100"),
        new(200.0m, CashType.Bill, "200 Riyal Bill", "SR 200"),
        new(500.0m, CashType.Bill, "500 Riyal Bill", "SR 500"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
