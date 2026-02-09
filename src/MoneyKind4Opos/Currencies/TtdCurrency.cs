using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Trinidad and Tobago Dollar Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.central-bank.org.tt/bank-notes-and-coins/current-bank-notes/">CBTT (Central Bank of Trinidad &amp; Tobago)</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://www.central-bank.org.tt/bank-notes-and-coins/">CBTT</seealso></description></item>
/// </list>
/// <para>※ The 5-cent coin was discontinued as of March 1, 2026. Cash rounding to 10 cents applies.</para>
/// </remarks>
public class TtdCurrency :
    ICurrency,
    ICashCountFormattable<TtdCurrency>,
    ICurrencyFormattable<TtdCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.TTD;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.10m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("$", "$n", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("TT$", "$n", decimalDigits: 2);

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Cent", "¢", 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.10m, CashType.Coin, "10 Cents", "10¢"),
        new(0.25m, CashType.Coin, "25 Cents", "25¢"),
        new(0.50m, CashType.Coin, "50 Cents", "50¢"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1m, CashType.Bill, "1 Dollar", "TT$1"),
        new(5m, CashType.Bill, "5 Dollars", "TT$5"),
        new(10m, CashType.Bill, "10 Dollars", "TT$10"),
        new(20m, CashType.Bill, "20 Dollars", "TT$20"),
        new(50m, CashType.Bill, "50 Dollars", "TT$50"),
        new(100m, CashType.Bill, "100 Dollars", "TT$100"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
