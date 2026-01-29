using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Norwegian Krone Currency</summary>
/// <seealso href="https://www.norges-bank.no/en/topics/notes-and-coins/">Notes and coins (Norges Bank)</seealso>
public class NokCurrency : ICurrency, ICashCountFormattable<NokCurrency>, ICurrencyFormattable<NokCurrency>
{
    private static readonly NumberFormatInfo _nfi = new()
    {
        CurrencySymbol = "kr",
        CurrencyGroupSeparator = " ",
        CurrencyDecimalSeparator = ",",
        CurrencyDecimalDigits = 2,
    };

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.NOK;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 1m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } = new(
        Symbol: "NOK",
        NumberFormat: new NumberFormatInfo 
        { 
            CurrencySymbol = "NOK", 
            CurrencyGroupSeparator = " ", 
            CurrencyDecimalSeparator = ",", 
            CurrencyDecimalDigits = 2 
        },
        DisplayFormat: new(SymbolPlacement.Postfix)
    );

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } = new(
        Symbol: "kr",
        NumberFormat: _nfi,
        DisplayFormat: new(SymbolPlacement.Postfix)
    );

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
