using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Singapore Dollar Currency</summary>
/// <seealso href="https://www.mas.gov.sg/currency/Singapores-Currencies">Notes and Coins (Monetary Authority of Singapore)</seealso>
public class SgdCurrency : ICurrency, ICashCountFormattable<SgdCurrency>, ICurrencyFormattable<SgdCurrency>
{
    private static readonly NumberFormatInfo _nfi = new()
    {
        CurrencySymbol = "$",
        CurrencyGroupSeparator = ",",
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 2,
    };

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.SGD;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.05m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } = new(
        Symbol: "S$",
        NumberFormat: new NumberFormatInfo 
        { 
            CurrencySymbol = "S$", 
            CurrencyGroupSeparator = ",", 
            CurrencyDecimalSeparator = ".", 
            CurrencyDecimalDigits = 2 
        },
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } = new(
        Symbol: "$",
        NumberFormat: _nfi,
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits => [];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.05m, CashType.Coin, "5 Cents", "5¢"),
        new(0.10m, CashType.Coin, "10 Cents", "10¢"),
        new(0.20m, CashType.Coin, "20 Cents", "20¢"),
        new(0.50m, CashType.Coin, "50 Cents", "50¢"),
        new(1.00m, CashType.Coin, "1 Dollar", "$1"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(2m, CashType.Bill, "2 Dollars", "$2"),
        new(5m, CashType.Bill, "5 Dollars", "$5"),
        new(10m, CashType.Bill, "10 Dollars", "$10"),
        new(50m, CashType.Bill, "50 Dollars", "$50"),
        new(100m, CashType.Bill, "100 Dollars", "$100"),
        new(1000m, CashType.Bill, "1000 Dollars", "$1000"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
