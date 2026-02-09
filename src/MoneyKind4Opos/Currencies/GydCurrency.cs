using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Guyanese Dollar Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://bankofguyana.org.gy/bog/index.php/currencies/notes">Bank of Guyana - Notes</seealso></description></item>
/// </list>
/// </remarks>
public class GydCurrency :
    ICurrency,
    ICashCountFormattable<GydCurrency>,
    ICurrencyFormattable<GydCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.GYD;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 1.0m;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Cent", "¢", 0.01m),
    ];

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("G$", "$n", decimalDigits: 0);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("$", "$n", decimalDigits: 0);

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(1.0m, CashType.Coin, "1 Dollar Coin", "$1"),
        new(5.0m, CashType.Coin, "5 Dollars Coin", "$5"),
        new(10.0m, CashType.Coin, "10 Dollars Coin", "$10"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(20.0m, CashType.Bill, "20 Dollars Bill", "$20"),
        new(50.0m, CashType.Bill, "50 Dollars Bill", "$50"),
        new(100.0m, CashType.Bill, "100 Dollars Bill", "$100"),
        new(500.0m, CashType.Bill, "500 Dollars Bill", "$500"),
        new(1000.0m, CashType.Bill, "1000 Dollars Bill", "$1000"),
        new(2000.0m, CashType.Bill, "2000 Dollars Bill", "$2000"),
        new(5000.0m, CashType.Bill, "5000 Dollars Bill", "$5000"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
