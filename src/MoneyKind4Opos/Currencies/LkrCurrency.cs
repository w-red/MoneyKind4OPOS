using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Sri Lanka Rupee Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.cbsl.gov.lk/en/notes-coins/notes-and-coins/current-note-series">Current Note Series (Central Bank of Sri Lanka)</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://www.cbsl.gov.lk/en/notes-coins/notes-and-coins/coins-in-circulation">Coins in Circulation (Central Bank of Sri Lanka)</seealso></description></item>
/// </list>
/// </remarks>
public class LkrCurrency :
    ICurrency,
    ICashCountFormattable<LkrCurrency>,
    ICurrencyFormattable<LkrCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.LKR;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 1m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("LKR", "$ n");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("Rs.", "$ n");

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Cent", "cts", 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(1m, CashType.Coin, "1 Rupee Coin", "Rs. 1"),
        new(2m, CashType.Coin, "2 Rupees Coin", "Rs. 2"),
        new(5m, CashType.Coin, "5 Rupees Coin", "Rs. 5"),
        new(10m, CashType.Coin, "10 Rupees Coin", "Rs. 10"),
        new(20m, CashType.Coin, "20 Rupees Coin", "Rs. 20"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(10m, CashType.Bill, "10 Rupees Bill", "Rs. 10"),
        new(20m, CashType.Bill, "20 Rupees Bill", "Rs. 20"),
        new(50m, CashType.Bill, "50 Rupees Bill", "Rs. 50"),
        new(100m, CashType.Bill, "100 Rupees Bill", "Rs. 100"),
        new(200m, CashType.Bill, "200 Rupees Bill", "Rs. 200"),
        new(500m, CashType.Bill, "500 Rupees Bill", "Rs. 500"),
        new(1000m, CashType.Bill, "1000 Rupees Bill", "Rs. 1000"),
        new(2000m, CashType.Bill, "2000 Rupees Bill", "Rs. 2000"),
        new(5000m, CashType.Bill, "5000 Rupees Bill", "Rs. 5000"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
