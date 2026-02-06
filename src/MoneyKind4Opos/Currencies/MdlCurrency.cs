using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Moldovan Leu Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://www.bnm.md/en/content/national-currency">National Bank of Moldova - National Currency</seealso></description></item>
/// </list>
/// </remarks>
public class MdlCurrency :
    ICurrency,
    ICashCountFormattable<MdlCurrency>,
    ICurrencyFormattable<MdlCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.MDL;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Ban", null, 0.01m),
    ];

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("L", "n $");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "1 Ban Coin", "1 ban"),
        new(0.05m, CashType.Coin, "5 Bani Coin", "5 bani"),
        new(0.10m, CashType.Coin, "10 Bani Coin", "10 bani"),
        new(0.25m, CashType.Coin, "25 Bani Coin", "25 bani"),
        new(0.50m, CashType.Coin, "50 Bani Coin", "50 bani"),
        new(1.0m, CashType.Coin, "1 Leu Coin", "1 leu"),
        new(2.0m, CashType.Coin, "2 Lei Coin", "2 lei"),
        new(5.0m, CashType.Coin, "5 Lei Coin", "5 lei"),
        new(10.0m, CashType.Coin, "10 Lei Coin", "10 lei"),
    ];
    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1.0m, CashType.Bill, "1 Leu Bill", "1 leu"),
        new(5.0m, CashType.Bill, "5 Lei Bill", "5 lei"),
        new(10.0m, CashType.Bill, "10 Lei Bill", "10 lei"),
        new(20.0m, CashType.Bill, "20 Lei Bill", "20 lei"),
        new(50.0m, CashType.Bill, "50 Lei Bill", "50 lei"),
        new(100.0m, CashType.Bill, "100 Lei Bill", "100 lei"),
        new(200.0m, CashType.Bill, "200 Lei Bill", "200 lei"),
        new(500.0m, CashType.Bill, "500 Lei Bill", "500 lei"),
        new(1000.0m, CashType.Bill, "1000 Lei Bill", "1000 lei"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
