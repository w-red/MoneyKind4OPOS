using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Swiss Franc Currency</summary>
public class ChfCurrency :
    ICurrency,
    ICashCountFormattable<ChfCurrency>,
    ICurrencyFormattable<ChfCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.CHF;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.05m;

    /// <summary>Global number format.</summary>
    private static readonly NumberFormatInfo _globalNfi = new()
    {
        CurrencySymbol = "CHF",
        CurrencyPositivePattern = 0,
        CurrencyGroupSeparator = ",",
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 2,
    };

    /// <summary>Local number format.</summary>
    private static readonly NumberFormatInfo _localNfi = new()
    {
        CurrencySymbol = "CHF",
        CurrencyPositivePattern = 1,
        CurrencyGroupSeparator = ",",
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 2,
    };

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } = new(
        Symbol: "CHF",
        NumberFormat: _globalNfi,
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } = new(
        Symbol: "CHF",
        NumberFormat: _localNfi,
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits => _subsidiaryUnits;

    /// <summary>Subsidiary units definitions.</summary>
    private static readonly ISubsidiaryUnit[] _subsidiaryUnits =
    [
        new SubsidiaryUnit("Rappen", "R", 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.05m, CashType.Coin, "0.05", "CHF 0.05"),
        new(0.10m, CashType.Coin, "0.10", "CHF 0.10"),
        new(0.20m, CashType.Coin, "0.20", "CHF 0.20"),
        new(0.50m, CashType.Coin, "1/2", "CHF 1/2"),
        new(1.00m, CashType.Coin, "1", "CHF 1.--"),
        new(2.00m, CashType.Coin, "2", "CHF 2.--"),
        new(5.00m, CashType.Coin, "5", "CHF 5.--"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(10.00m, CashType.Bill, "CHF 10 Bill", "CHF 10"),
        new(20.00m, CashType.Bill, "CHF 20 Bill", "CHF 20"),
        new(50.00m, CashType.Bill, "CHF 50 Bill", "CHF 50"),
        new(100.00m, CashType.Bill, "CHF 100 Bill", "CHF 100"),
        new(200.00m, CashType.Bill, "CHF 200 Bill", "CHF 200"),
        new(1000.00m, CashType.Bill, "CHF 1000 Bill", "CHF 1000"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
