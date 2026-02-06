using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Bosnia-Herzegovina Convertible Mark Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://www.cbbh.ba/Content/Read/14?lang=en">Central Bank of Bosnia and Herzegovina - Banknotes and Coins</seealso></description></item>
/// </list>
/// </remarks>
public class BamCurrency :
    ICurrency,
    ICashCountFormattable<BamCurrency>,
    ICurrencyFormattable<BamCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.BAM;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.05m;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Fening", null, 0.01m),
    ];

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("KM", "n $", decimalSep: ",", groupSep: ".");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.05m, CashType.Coin, "5 Feninga Coin", "5 feninga"),
        new(0.10m, CashType.Coin, "10 Feninga Coin", "10 feninga"),
        new(0.20m, CashType.Coin, "20 Feninga Coin", "20 feninga"),
        new(0.50m, CashType.Coin, "50 Feninga Coin", "50 feninga"),
        new(1.0m, CashType.Coin, "1 Marka Coin", "1 KM"),
        new(2.0m, CashType.Coin, "2 Marke Coin", "2 KM"),
        new(5.0m, CashType.Coin, "5 Maraka Coin", "5 KM"),
    ];
    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(10.0m, CashType.Bill, "10 Maraka Bill", "10 KM"),
        new(20.0m, CashType.Bill, "20 Maraka Bill", "20 KM"),
        new(50.0m, CashType.Bill, "50 Maraka Bill", "50 KM"),
        new(100.0m, CashType.Bill, "100 Maraka Bill", "100 KM"),
        new(200.0m, CashType.Bill, "200 Maraka Bill", "200 KM"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
