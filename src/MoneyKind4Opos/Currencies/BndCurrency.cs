using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Brunei Dollar Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Currency</term><description><seealso href="https://www.bdcb.gov.bn/currency/circulation">BDCB - Currency in Circulation</seealso></description></item>
/// </list>
/// </remarks>
public class BndCurrency :
    ICurrency,
    ICashCountFormattable<BndCurrency>,
    ICurrencyFormattable<BndCurrency>
{
    private static readonly NumberFormatInfo _nfi = new()
    {
        CurrencySymbol = "$",
        CurrencyGroupSeparator = ",",
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 2,
    };

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.BND;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } = new(
        Symbol: "BN$",
        NumberFormat: new NumberFormatInfo 
        { 
            CurrencySymbol = "BN$", 
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
        new(0.01m, CashType.Coin, "1 Cents", "1¢"),
        new(0.05m, CashType.Coin, "5 Cents", "10¢"),
        new(0.10m, CashType.Coin, "10 Cents", "10¢"),
        new(0.20m, CashType.Coin, "20 Cents", "20¢"),
        new(0.50m, CashType.Coin, "50 Cents", "50¢"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1m, CashType.Bill, "1 Dollars", "$1"),
        new(5m, CashType.Bill, "5 Dollars", "$5"),
        new(10m, CashType.Bill, "10 Dollars", "$10"),
        new(50m, CashType.Bill, "50 Dollars", "$50"),
        new(100m, CashType.Bill, "100 Dollars", "$100"),
        new(500m, CashType.Bill, "500 Dollars", "$500"),
        new(1000m, CashType.Bill, "1000 Dollars", "$1000"),
        new(10000m, CashType.Bill, "10000 Dollars", "$10000"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
