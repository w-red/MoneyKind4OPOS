using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Belarusian Ruble Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Banknotes and Coins</term><description><seealso href="https://president.gov.by/en/belarus/economics/banking-system/national-currency">National Currency - President of the Republic of Belarus</seealso></description></item>
/// </list>
/// </remarks>
public class BynCurrency :
    ICurrency,
    ICashCountFormattable<BynCurrency>,
    ICurrencyFormattable<BynCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.BYN;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("Br", "n$");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
        [
            new SubsidiaryUnit(Name: "Kopek", Symbol: "k", Ratio: 0.01m),
        ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "1 Kopek Coin", "1K"),
        new(0.02m, CashType.Coin, "2 Kopek Coin", "2K"),
        new(0.05m, CashType.Coin, "5 Kopek Coin", "5K"),
        new(0.10m, CashType.Coin, "10 Kopek Coin", "10K"),
        new(0.20m, CashType.Coin, "20 Kopek Coin", "20K"),
        new(0.50m, CashType.Coin, "50 Kopek Coin", "50K"),
        new(1m, CashType.Coin, "1 Br Coin", "1 Br"),
        new(2m, CashType.Coin, "2 Br Coin", "2 Br"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(5m, CashType.Bill, "5 Br Bill", "5 Br"),
        new(10m, CashType.Bill, "10 Br Bill", "10 Br"),
        new(20m, CashType.Bill, "20 Br Bill", "20 Br"),
        new(50m, CashType.Bill, "50 Br Bill", "50 Br"),
        new(100m, CashType.Bill, "100 Br Bill", "100 Br"),
        new(200m, CashType.Bill, "200 Br Bill", "200 Br"),
        new(500m, CashType.Bill, "500 Br Bill", "500 Br"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
