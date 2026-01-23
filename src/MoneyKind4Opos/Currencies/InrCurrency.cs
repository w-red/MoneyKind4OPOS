using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Indian Rupee Currency</summary>
public class InrCurrency :
    ICurrency,
    ICashCountFormattable<InrCurrency>,
    ICurrencyFormattable<InrCurrency>
{
    private static readonly NumberFormatInfo _globalNfi = new()
    {
        CurrencySymbol = "₹",
        CurrencyPositivePattern = 0, // $n
        CurrencyGroupSeparator = ",",
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 2,
        CurrencyGroupSizes = [3, 2],
        NumberGroupSeparator = ",",
        NumberDecimalSeparator = ".",
        NumberDecimalDigits = 2,
        NumberGroupSizes = [3, 2],
    };

    private static readonly NumberFormatInfo _localNfi = new()
    {
        CurrencySymbol = "₹",
        CurrencyPositivePattern = 0, // $n
        CurrencyGroupSeparator = ",",
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 2,
        CurrencyGroupSizes = [3, 2],
        NumberGroupSeparator = ",",
        NumberDecimalSeparator = ".",
        NumberDecimalDigits = 2,
        NumberGroupSizes = [3, 2],
    };

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.INR;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.50m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } = new(
        Symbol: "₹",
        NumberFormat: _globalNfi,
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } = new(
        Symbol: "₹",
        NumberFormat: _localNfi,
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits => [];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.5m, CashType.Coin, "50 Paise", "50パイサ"),
        new(1m, CashType.Coin, "1 Rupee Coin", "1ルピー硬貨"),
        new(2m, CashType.Coin, "2 Rupees Coin", "2ルピー硬貨"),
        new(5m, CashType.Coin, "5 Rupees Coin", "5ルピー硬貨"),
        new(10m, CashType.Coin, "10 Rupees Coin", "10ルピー硬貨"),
        new(20m, CashType.Coin, "20 Rupees Coin", "20ルピー硬貨"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(10m, CashType.Bill, "10 Rupees Bill", "10ルピー紙幣"),
        new(20m, CashType.Bill, "20 Rupees Bill", "20ルピー紙幣"),
        new(50m, CashType.Bill, "50 Rupees Bill", "50ルピー紙幣"),
        new(100m, CashType.Bill, "100 Rupees Bill", "100ルピー紙幣"),
        new(200m, CashType.Bill, "200 Rupees Bill", "200ルピー紙幣"),
        new(500m, CashType.Bill, "500 Rupees Bill", "500ルピー紙幣"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
