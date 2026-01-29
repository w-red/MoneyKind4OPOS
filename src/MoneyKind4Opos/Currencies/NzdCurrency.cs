using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>New Zealand Dollar</summary>
public class NzdCurrency : ICurrency, ICashCountFormattable<NzdCurrency>, ICurrencyFormattable<NzdCurrency>
{
    private static readonly NumberFormatInfo _nfi = new()
    {
        CurrencySymbol = "$",
        CurrencyGroupSeparator = ",",
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 2,
    };

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.NZD;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.10m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } = new(
        Symbol: "NZ$",
        NumberFormat: (NumberFormatInfo)_nfi.Clone(),
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
        new(0.10m, CashType.Coin, "10 Cents", "10c"),
        new(0.20m, CashType.Coin, "20 Cents", "20c"),
        new(0.50m, CashType.Coin, "50 Cents", "50c"),
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
