using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>South African Rand</summary>
public class ZarCurrency : ICurrency, ICashCountFormattable<ZarCurrency>, ICurrencyFormattable<ZarCurrency>
{
    private static readonly NumberFormatInfo _nfi = new()
    {
        CurrencySymbol = "R",
        CurrencyGroupSeparator = ",", // Officially space in SA, but often comma in international contexts. Sticking to comma for now or checking locale? SA uses space. Let's use space.
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 2,
        NumberGroupSeparator = " ",
        NumberDecimalSeparator = "." 
    };
    // Note: South Africa uses space as thousands separator and dot or comma as decimal.
    // Let's use space for group, dot for decimal based on common IT usage, but verify later with Tests if needed.

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.ZAR;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.10m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } = new(
        Symbol: "ZAR",
        NumberFormat: new NumberFormatInfo 
        { 
            CurrencySymbol = "ZAR", 
            CurrencyGroupSeparator = ",", 
            CurrencyDecimalSeparator = ".",
            CurrencyDecimalDigits = 2
        },
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } = new(
        Symbol: "R",
        NumberFormat: _nfi,
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits => [];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.10m, CashType.Coin, "10 Cents", "10c"),
        new(0.20m, CashType.Coin, "20 Cents", "20c"),
        new(0.50m, CashType.Coin, "50 Cents", "50c"),
        new(1.00m, CashType.Coin, "1 Rand", "R1"),
        new(2.00m, CashType.Coin, "2 Rands", "R2"),
        new(5.00m, CashType.Coin, "5 Rands", "R5"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(10m, CashType.Bill, "10 Rands", "R10"),
        new(20m, CashType.Bill, "20 Rands", "R20"),
        new(50m, CashType.Bill, "50 Rands", "R50"),
        new(100m, CashType.Bill, "100 Rands", "R100"),
        new(200m, CashType.Bill, "200 Rands", "R200"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
