using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Serbian Dinar Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://www.nbs.rs/en/novcanice-i-kovani-novac/index.html">National Bank of Serbia - Banknotes and Coins</seealso></description></item>
/// </list>
/// </remarks>
public class RsdCurrency :
    ICurrency,
    ICashCountFormattable<RsdCurrency>,
    ICurrencyFormattable<RsdCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.RSD;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 1.0m;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Para", null, 0.01m),
    ];

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("din.", "n $", decimalSep: ",", groupSep: ".");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(1.0m, CashType.Coin, "1 Dinar Coin", "1 дин."),
        new(2.0m, CashType.Coin, "2 Dinara Coin", "2 дин."),
        new(5.0m, CashType.Coin, "5 Dinara Coin", "5 дин."),
        new(10.0m, CashType.Coin, "10 Dinara Coin", "10 дин."),
        new(20.0m, CashType.Coin, "20 Dinara Coin", "20 дин."),
    ];
    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(10.0m, CashType.Bill, "10 Dinara Bill", "10 дин."),
        new(20.0m, CashType.Bill, "20 Dinara Bill", "20 дин."),
        new(50.0m, CashType.Bill, "50 Dinara Bill", "50 дин."),
        new(100.0m, CashType.Bill, "100 Dinara Bill", "100 дин."),
        new(200.0m, CashType.Bill, "200 Dinara Bill", "200 дин."),
        new(500.0m, CashType.Bill, "500 Dinara Bill", "500 дин."),
        new(1000.0m, CashType.Bill, "1000 Dinara Bill", "1000 дин."),
        new(2000.0m, CashType.Bill, "2000 Dinara Bill", "2000 дин."),
        new(5000.0m, CashType.Bill, "5000 Dinara Bill", "5000 дин."),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
