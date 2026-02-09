using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Azerbaijan Manat Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://www.cbar.az/page-44/national-currency">National Currency (Central Bank of the Republic of Azerbaijan)</seealso></description></item>
/// </list>
/// </remarks>
public class AznCurrency :
    ICurrency,
    ICashCountFormattable<AznCurrency>,
    ICurrencyFormattable<AznCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.AZN;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("AZN", "$n");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("₼", "$ n");

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Qapik", null, 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "1 Qapik Coin", "0.01 ₼"),
        new(0.03m, CashType.Coin, "3 Qapik Coin", "0.03 ₼"),
        new(0.05m, CashType.Coin, "5 Qapik Coin", "0.05 ₼"),
        new(0.10m, CashType.Coin, "10 Qapik Coin", "0.10 ₼"),
        new(0.20m, CashType.Coin, "20 Qapik Coin", "0.20 ₼"),
        new(0.50m, CashType.Coin, "50 Qapik Coin", "0.50 ₼"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1m, CashType.Bill, "1 Manat Bill", "1 ₼"),
        new(5m, CashType.Bill, "5 Manat Bill", "5 ₼"),
        new(10m, CashType.Bill, "10 Manat Bill", "10 ₼"),
        new(20m, CashType.Bill, "20 Manat Bill", "20 ₼"),
        new(50m, CashType.Bill, "50 Manat Bill", "50 ₼"),
        new(100m, CashType.Bill, "100 Manat Bill", "100 ₼"),
        new(200m, CashType.Bill, "200 Manat Bill", "200 ₼"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
