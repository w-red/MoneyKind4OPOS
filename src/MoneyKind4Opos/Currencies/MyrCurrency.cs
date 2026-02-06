using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Malaysian Ringgit Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.bnm.gov.my/currency/banknotes">Banknotes (Bank Negara Malaysia)</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://www.bnm.gov.my/currency/coins">Coins (Bank Negara Malaysia)</seealso></description></item>
/// </list>
/// </remarks>
public class MyrCurrency :
    ICurrency,
    ICashCountFormattable<MyrCurrency>,
    ICurrencyFormattable<MyrCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.MYR;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.05m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("MYR", "$ n");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("RM", "$ n");

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Sen", "sen", 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.05m, CashType.Coin, "5 Sen Coin", "5 sen"),
        new(0.10m, CashType.Coin, "10 Sen Coin", "10 sen"),
        new(0.20m, CashType.Coin, "20 Sen Coin", "20 sen"),
        new(0.50m, CashType.Coin, "50 Sen Coin", "50 sen"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1m, CashType.Bill, "1 Ringgit Bill", "RM1"),
        new(5m, CashType.Bill, "5 Ringgit Bill", "RM5"),
        new(10m, CashType.Bill, "10 Ringgit Bill", "RM10"),
        new(20m, CashType.Bill, "20 Ringgit Bill", "RM20"),
        new(50m, CashType.Bill, "50 Ringgit Bill", "RM50"),
        new(100m, CashType.Bill, "100 Ringgit Bill", "RM100"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
