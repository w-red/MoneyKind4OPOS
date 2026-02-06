using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Polish Zloty Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://nbp.pl/en/coins-and-banknotes/banknotes-issued/">Banknotes issued by NBP</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://nbp.pl/en/coins-and-banknotes/coins/">Coins issued by NBP</seealso></description></item>
/// </list>
/// </remarks>
public class PlnCurrency :
    ICurrency,
    ICashCountFormattable<PlnCurrency>,
    ICurrencyFormattable<PlnCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.PLN;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("zł", "$n");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("zł", "$n");

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
        [
            new SubsidiaryUnit(Name: "Grosz", Symbol: "gr", Ratio: 0.01m),
        ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "1 gr Coin", "1 gr"),
        new(0.02m, CashType.Coin, "2 gr Coin", "2 gr"),
        new(0.05m, CashType.Coin, "5 gr Coin", "5 gr"),
        new(0.1m, CashType.Coin, "10 gr Coin", "10 gr"),
        new(0.2m, CashType.Coin, "20 gr Coin", "20 gr"),
        new(0.5m, CashType.Coin, "50 gr Coin", "50 gr"),
        new(1m, CashType.Coin, "1 zł Coin", "1 zł"),
        new(2m, CashType.Coin, "2 zł Coin", "2 zł"),
        new(5m, CashType.Coin, "5 zł Coin", "5 zł"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(10m, CashType.Bill, "10 zł Bill", "10 zł"),
        new(20m, CashType.Bill, "20 zł Bill", "20 zł"),
        new(50m, CashType.Bill, "50 zł Bill", "50 zł"),
        new(100m, CashType.Bill, "100 zł Bill", "100 zł"),
        new(200m, CashType.Bill, "200 zł Bill", "200 zł"),
        new(500m, CashType.Bill, "500 zł Bill", "500 zł"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
