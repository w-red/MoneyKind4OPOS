using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Macedonian Denar Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://www.nbrm.mk/banknotes-en.nspx">National Bank of the Republic of North Macedonia - Banknotes and Coins</seealso></description></item>
/// </list>
/// </remarks>
public class MkdCurrency :
    ICurrency,
    ICashCountFormattable<MkdCurrency>,
    ICurrencyFormattable<MkdCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.MKD;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 1.0m;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Deni", null, 0.01m),
    ];

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("den", "n $", decimalSep: ",", groupSep: ".");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(1.0m, CashType.Coin, "1 Denar Coin", "1 ден"),
        new(2.0m, CashType.Coin, "2 Denari Coin", "2 ден"),
        new(5.0m, CashType.Coin, "5 Denari Coin", "5 ден"),
        new(10.0m, CashType.Coin, "10 Denari Coin", "10 ден"),
        new(50.0m, CashType.Coin, "50 Denari Coin", "50 ден"),
    ];
    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(10.0m, CashType.Bill, "10 Denari Bill", "10 ден"),
        new(50.0m, CashType.Bill, "50 Denari Bill", "50 ден"),
        new(100.0m, CashType.Bill, "100 Denari Bill", "100 ден"),
        new(200.0m, CashType.Bill, "200 Denari Bill", "200 ден"),
        new(500.0m, CashType.Bill, "500 Denari Bill", "500 ден"),
        new(1000.0m, CashType.Bill, "1000 Denari Bill", "1000 ден"),
        new(2000.0m, CashType.Bill, "2000 Denari Bill", "2000 ден"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
