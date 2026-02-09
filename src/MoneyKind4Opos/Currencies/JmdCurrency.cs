using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Jamaican Dollar Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://boj.org.jm/core-functions/currency/bank-notes/">BOJ (Bank of Jamaica)</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://boj.org.jm/core-functions/currency/">BOJ</seealso></description></item>
/// </list>
/// <para>※ As of 2025, only the new polymer banknote series (2023) is valid.</para>
/// </remarks>
public class JmdCurrency :
    ICurrency,
    ICashCountFormattable<JmdCurrency>,
    ICurrencyFormattable<JmdCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.JMD;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 1.0m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("$", "$n", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("J$", "$n", decimalDigits: 2);

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Cent", "¢", 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(1m, CashType.Coin, "1 Dollar", "J$1"),
        new(5m, CashType.Coin, "5 Dollars", "J$5"),
        new(10m, CashType.Coin, "10 Dollars", "J$10"),
        new(20m, CashType.Coin, "20 Dollars", "J$20"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(50m, CashType.Bill, "50 Dollars", "J$50"),
        new(100m, CashType.Bill, "100 Dollars", "J$100"),
        new(500m, CashType.Bill, "500 Dollars", "J$500"),
        new(1000m, CashType.Bill, "1000 Dollars", "J$1000"),
        new(2000m, CashType.Bill, "2000 Dollars", "J$2000"),
        new(5000m, CashType.Bill, "5000 Dollars", "J$5000"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
