using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Omani Rial Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Currency</term><description><seealso href="https://cbo.gov.om/Pages/Currency.aspx">CBO - currency</seealso></description></item>
/// </list>
/// </remarks>
public class OmrCurrency :
    ICurrency,
    ICashCountFormattable<OmrCurrency>,
    ICurrencyFormattable<OmrCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.OMR;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.005m;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Baisa", null, 0.001m),
    ];

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("Rials", "n $", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.005m, CashType.Coin, "5 Baisa Coin", "5b", Usage: CashUsagePolicy.NonRecyclable),
        new(0.01m, CashType.Coin, "10 Baisa Coin", "10b", Usage: CashUsagePolicy.NonRecyclable),
        new(0.025m, CashType.Coin, "25 Baisa Coin", "25b", Usage: CashUsagePolicy.NonRecyclable),
        new(0.05m, CashType.Coin, "50 Baisa Coin", "50b", Usage: CashUsagePolicy.NonRecyclable),
    ];
    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(0.1m, CashType.Bill, "100 Baisa Coin", "100b"),
        new(0.5m, CashType.Bill, "1/2 Rial Bill", "1/2 Rial"),
        new(1.0m, CashType.Bill, "1 Rial Bill", "1 Rial"),
        new(5.0m, CashType.Bill, "5 Rials Bill", "5 Rials"),
        new(10.0m, CashType.Bill, "10 Rials Bill", "10 Rials"),
        new(20.0m, CashType.Bill, "20 Rials Bill", "20 Rials"),
        new(50.0m, CashType.Bill, "50 Rials Bill", "50 Rials"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
