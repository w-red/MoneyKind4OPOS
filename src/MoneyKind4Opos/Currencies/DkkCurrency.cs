using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Danish Krone Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.nationalbanken.dk/en/the-future-of-cash/valid-banknotes">Which banknotes are still valid? - Danmarks Nationalbank</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://www.nationalbanken.dk/en/what-we-do/notes-and-coins/new-coins/the-coin-sequence">Danmarks Nationalbank - Danish coin</seealso></description></item>
/// </list>
/// </remarks>
public class DkkCurrency :
    ICurrency,
    ICashCountFormattable<DkkCurrency>,
    ICurrencyFormattable<DkkCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.DKK;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.5m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("Kr", "n $", decimalDigits: 1);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
        [
            new SubsidiaryUnit(Name: "øre", Symbol: "ø", Ratio: 0.01m),
        ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.5m, CashType.Coin, "50 øre Coin", "50 øre"),
        new(1m, CashType.Coin, "1 Kr Coin", "1 Kr"),
        new(2m, CashType.Coin, "2 Kr Coin", "2 Kr"),
        new(5m, CashType.Coin, "5 Kr Coin", "5 Kr"),
        new(10m, CashType.Coin, "10 Kr Coin", "10 Kr"),
        new(20m, CashType.Coin, "20 Kr Coin", "20 Kr"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(50m, CashType.Bill, "50 Kr Bill", "50 Kr"),
        new(100m, CashType.Bill, "100 Kr Bill", "100 Kr"),
        new(200m, CashType.Bill, "200 Kr Bill", "200 Kr"),
        new(500m, CashType.Bill, "500 Kr Bill", "500 Kr"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
