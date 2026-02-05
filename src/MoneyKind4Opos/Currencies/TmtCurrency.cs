using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Turkmenistan New Manat Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description>Banknotes and Coins (Central Bank of Turkmenistan)</description></item>
/// </list>
/// </remarks>
public class TmtCurrency :
    ICurrency,
    ICashCountFormattable<TmtCurrency>,
    ICurrencyFormattable<TmtCurrency>
{
    private static readonly NumberFormatInfo _nfi = new()
    {
        CurrencySymbol = "m",
        CurrencyPositivePattern = 0, // $n
        CurrencyGroupSeparator = ",",
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 2,
    };

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.TMT;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } = new(
        Symbol: "TMT",
        NumberFormat: new NumberFormatInfo
        {
            CurrencySymbol = "TMT",
            CurrencyGroupSeparator = ",",
            CurrencyDecimalSeparator = ".",
            CurrencyDecimalDigits = 2
        },
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } = new(
        Symbol: "m",
        NumberFormat: _nfi,
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Tenge", null, 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "1 Tenge Coin", "0.01 m"),
        new(0.02m, CashType.Coin, "2 Tenge Coin", "0.02 m"),
        new(0.05m, CashType.Coin, "5 Tenge Coin", "0.05 m"),
        new(0.10m, CashType.Coin, "10 Tenge Coin", "0.10 m"),
        new(0.20m, CashType.Coin, "20 Tenge Coin", "0.20 m"),
        new(0.50m, CashType.Coin, "50 Tenge Coin", "0.50 m"),
        new(1m, CashType.Coin, "1 Manat Coin", "1 m"),
        new(2m, CashType.Coin, "2 Manat Coin", "2 m"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1m, CashType.Bill, "1 Manat Bill", "1 m"),
        new(5m, CashType.Bill, "5 Manat Bill", "5 m"),
        new(10m, CashType.Bill, "10 Manat Bill", "10 m"),
        new(20m, CashType.Bill, "20 Manat Bill", "20 m"),
        new(50m, CashType.Bill, "50 Manat Bill", "50 m"),
        new(100m, CashType.Bill, "100 Manat Bill", "100 m"),
        new(500m, CashType.Bill, "500 Manat Bill", "500 m"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
