using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Canadian Dollar Currency</summary>
/// <seealso href="https://www.bankofcanada.ca/banknotes/">Banknotes (Bank of Canada)</seealso>
public class CadCurrency : ICurrency, ICashCountFormattable<CadCurrency>, ICurrencyFormattable<CadCurrency>
{
    private static readonly NumberFormatInfo _nfi = new()
    {
        CurrencySymbol = "$",
        CurrencyGroupSeparator = ",",
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 2,
    };

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.CAD;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.05m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } = new(
        Symbol: "C$",
        NumberFormat: new NumberFormatInfo 
        { 
            CurrencySymbol = "C$", 
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
        new(0.25m, CashType.Coin, "25 Cents", "25¢"),
        new(1.00m, CashType.Coin, "1 Dollar", "$1"),
        new(2.00m, CashType.Coin, "2 Dollars", "$2"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(5m, CashType.Bill, "5 Dollars", "$5"),
        new(10m, CashType.Bill, "10 Dollars", "$10"),
        new(20m, CashType.Bill, "20 Dollars", "$20"),
        new(50m, CashType.Bill, "50 Dollars", "$50"),
        new(100m, CashType.Bill, "100 Dollars", "$100"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
