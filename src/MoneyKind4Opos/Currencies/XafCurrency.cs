using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Central African CFA Franc</summary>
/// <seealso href="https://www.bceao.int/fr/content/billets-et-pieces">Les billets et les pièces (BCEAO)</seealso>
public class XafCurrency :
    ICurrency,
    ICashCountFormattable<XafCurrency>,
    ICurrencyFormattable<XafCurrency>
{
    private static readonly NumberFormatInfo _nfi = new()
    {
        CurrencySymbol = "FCFA",
        CurrencyGroupSeparator = " ",
        CurrencyDecimalSeparator = ",",
        CurrencyDecimalDigits = 0,
        NumberGroupSeparator = " ",
        NumberDecimalSeparator = ",",
    };

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.XAF;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 1m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } = new(
        Symbol: "XAF",
        NumberFormat: new NumberFormatInfo 
        { 
            CurrencySymbol = "XAF", 
            CurrencyGroupSeparator = " ", 
            CurrencyDecimalSeparator = ",", 
            CurrencyDecimalDigits = 0 
        },
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } = new(
        Symbol: "FCFA",
        NumberFormat: _nfi,
        DisplayFormat: new(SymbolPlacement.Postfix)
    );

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits => [];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(1m, CashType.Coin, "1 Franc", "1 FCFA"),
        new(2m, CashType.Coin, "2 Francs", "2 FCFA"),
        new(5m, CashType.Coin, "5 Francs", "5 FCFA"),
        new(10m, CashType.Coin, "10 Francs", "10 FCFA"),
        new(25m, CashType.Coin, "25 Francs", "25 FCFA"),
        new(50m, CashType.Coin, "50 Francs", "50 FCFA"),
        new(100m, CashType.Coin, "100 Francs", "100 FCFA"),
        new(200m, CashType.Coin, "200 Francs", "200 FCFA"),
        new(500m, CashType.Coin, "500 Francs", "500 FCFA"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(500m, CashType.Bill, "500 Francs", "500 FCFA"),
        new(1000m, CashType.Bill, "1000 Francs", "1000 FCFA"),
        new(2000m, CashType.Bill, "2000 Francs", "2000 FCFA"),
        new(5000m, CashType.Bill, "5000 Francs", "5000 FCFA"),
        new(10000m, CashType.Bill, "10000 Francs", "10000 FCFA"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
