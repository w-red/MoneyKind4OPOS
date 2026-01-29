using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>West African CFA Franc</summary>
public class XofCurrency : ICurrency, ICashCountFormattable<XofCurrency>, ICurrencyFormattable<XofCurrency>
{
    private static readonly NumberFormatInfo _nfi = new()
    {
        CurrencySymbol = "CFA",
        CurrencyGroupSeparator = " ", // French speaking countries often use space
        CurrencyDecimalSeparator = ",",
        CurrencyDecimalDigits = 0,
        NumberGroupSeparator = " ",
        NumberDecimalSeparator = ",",
    };

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.XOF;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 1m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } = new(
        Symbol: "XOF",
        NumberFormat: (NumberFormatInfo)_nfi.Clone(),
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } = new(
        Symbol: "CFA",
        NumberFormat: _nfi,
        DisplayFormat: new(SymbolPlacement.Postfix) // 100 CFA
    );

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits => [];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(1m, CashType.Coin, "1 Franc", "1 CFA"),
        new(5m, CashType.Coin, "5 Francs", "5 CFA"),
        new(10m, CashType.Coin, "10 Francs", "10 CFA"),
        new(25m, CashType.Coin, "25 Francs", "25 CFA"),
        new(50m, CashType.Coin, "50 Francs", "50 CFA"),
        new(100m, CashType.Coin, "100 Francs", "100 CFA"),
        new(200m, CashType.Coin, "200 Francs", "200 CFA"),
        new(500m, CashType.Coin, "500 Francs", "500 CFA"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(500m, CashType.Bill, "500 Francs", "500 CFA"),
        new(1000m, CashType.Bill, "1000 Francs", "1000 CFA"),
        new(2000m, CashType.Bill, "2000 Francs", "2000 CFA"),
        new(5000m, CashType.Bill, "5000 Francs", "5000 CFA"),
        new(10000m, CashType.Bill, "10000 Francs", "10000 CFA"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
