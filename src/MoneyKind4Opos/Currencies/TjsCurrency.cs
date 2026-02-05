using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Tajikistan Somoni Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description>Banknotes and Coins (National Bank of Tajikistan)</description></item>
/// </list>
/// </remarks>
public class TjsCurrency :
    ICurrency,
    ICashCountFormattable<TjsCurrency>,
    ICurrencyFormattable<TjsCurrency>
{
    private static readonly NumberFormatInfo _nfi = new()
    {
        CurrencySymbol = "SM",
        CurrencyPositivePattern = 0, // $n
        CurrencyGroupSeparator = ",",
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 2,
    };

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.TJS;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } = new(
        Symbol: "TJS",
        NumberFormat: new NumberFormatInfo
        {
            CurrencySymbol = "TJS",
            CurrencyGroupSeparator = ",",
            CurrencyDecimalSeparator = ".",
            CurrencyDecimalDigits = 2
        },
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } = new(
        Symbol: "SM",
        NumberFormat: _nfi,
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Diram", null, 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "1 Diram Coin", "0.01 SM"),
        new(0.05m, CashType.Coin, "5 Diram Coin", "0.05 SM"),
        new(0.10m, CashType.Coin, "10 Diram Coin", "0.10 SM"),
        new(0.20m, CashType.Coin, "20 Diram Coin", "0.20 SM"),
        new(0.25m, CashType.Coin, "25 Diram Coin", "0.25 SM"),
        new(0.50m, CashType.Coin, "50 Diram Coin", "0.50 SM"),
        new(1m, CashType.Coin, "1 Somoni Coin", "1 SM"),
        new(3m, CashType.Coin, "3 Somoni Coin", "3 SM"),
        new(5m, CashType.Coin, "5 Somoni Coin", "5 SM"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1m, CashType.Bill, "1 Somoni Bill", "1 SM"),
        new(3m, CashType.Bill, "3 Somoni Bill", "3 SM"),
        new(5m, CashType.Bill, "5 Somoni Bill", "5 SM"),
        new(10m, CashType.Bill, "10 Somoni Bill", "10 SM"),
        new(20m, CashType.Bill, "20 Somoni Bill", "20 SM"),
        new(50m, CashType.Bill, "50 Somoni Bill", "50 SM"),
        new(100m, CashType.Bill, "100 Somoni Bill", "100 SM"),
        new(200m, CashType.Bill, "200 Somoni Bill", "200 SM"),
        new(500m, CashType.Bill, "500 Somoni Bill", "500 SM"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
