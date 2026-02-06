using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Norwegian Krone Currency</summary>
/// <seealso href="https://www.norges-bank.no/en/topics/notes-and-coins/">Notes and coins (Norges Bank)</seealso>
public class NokCurrency :
    ICurrency,
    ICashCountFormattable<NokCurrency>,
    ICurrencyFormattable<NokCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.NOK;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 1m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("NOK", "n $", groupSep: " ", decimalSep: ",");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("kr", "n $", groupSep: " ", decimalSep: ",");

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits => [];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(1m, CashType.Coin, "1 Krone", "1 kr"),
        new(5m, CashType.Coin, "5 Kroner", "5 kr"),
        new(10m, CashType.Coin, "10 Kroner", "10 kr"),
        new(20m, CashType.Coin, "20 Kroner", "20 kr"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(50m, CashType.Bill, "50 Kroner", "50 kr"),
        new(100m, CashType.Bill, "100 Kroner", "100 kr"),
        new(200m, CashType.Bill, "200 Kroner", "200 kr"),
        new(500m, CashType.Bill, "500 Kroner", "500 kr"),
        new(1000m, CashType.Bill, "1000 Kroner", "1000 kr"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
