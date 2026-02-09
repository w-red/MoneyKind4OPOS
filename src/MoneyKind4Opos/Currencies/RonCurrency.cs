using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Romanian Leu Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://www.bnr.ro/Coins-and-banknotes-in-circulation-3165.aspx">National Bank of Romania - Banknotes and Coins</seealso></description></item>
/// </list>
/// </remarks>
public class RonCurrency :
    ICurrency,
    ICashCountFormattable<RonCurrency>,
    ICurrencyFormattable<RonCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.RON;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Ban", null, 0.01m),
    ];

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("lei", "n $", decimalSep: ",", groupSep: ".");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "1 Ban Coin", "1 ban"),
        new(0.05m, CashType.Coin, "5 Bani Coin", "5 bani"),
        new(0.10m, CashType.Coin, "10 Bani Coin", "10 bani"),
        new(0.50m, CashType.Coin, "50 Bani Coin", "50 bani"),
    ];
    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1.0m, CashType.Bill, "1 Leu Bill", "1 leu"),
        new(5.0m, CashType.Bill, "5 Lei Bill", "5 lei"),
        new(10.0m, CashType.Bill, "10 Lei Bill", "10 lei"),
        new(50.0m, CashType.Bill, "50 Lei Bill", "50 lei"),
        new(100.0m, CashType.Bill, "100 Lei Bill", "100 lei"),
        new(200.0m, CashType.Bill, "200 Lei Bill", "200 lei"),
        new(500.0m, CashType.Bill, "500 Lei Bill", "500 lei"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
