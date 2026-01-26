using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Australian Dollar Currency</summary>
public class AudCurrency :
    ICurrency,
    ICashCountFormattable<AudCurrency>,
    ICurrencyFormattable<AudCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.AUD;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.05m;

    /// <summary>Global number format.</summary>
    private static readonly NumberFormatInfo _globalNfi = new()
    {
        CurrencySymbol = "AUD",
        CurrencyPositivePattern = 0,
        CurrencyGroupSeparator = ",",
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 2,
    };

    /// <summary>Local number format.</summary>
    private static readonly NumberFormatInfo _localNfi = new()
    {
        CurrencySymbol = "A$",
        CurrencyPositivePattern = 1,
        CurrencyGroupSeparator = ",",
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 2,
    };

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } = new(
        Symbol: "AUD",
        NumberFormat: _globalNfi,
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } = new(
        Symbol: "A$",
        NumberFormat: _localNfi,
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
        _subsidiaryUnits;

    /// <summary>Subsidiary units definitions.</summary>
    private static readonly ISubsidiaryUnit[] _subsidiaryUnits =
    [
        new SubsidiaryUnit("Cent", "c", 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.05m, CashType.Coin, "5 ¢ Coin", "5 Cent"),
        new(0.10m, CashType.Coin, "10 ¢ Coin", "10 Cent"),
        new(0.20m, CashType.Coin, "20 ¢ Coin", "20 Cent"),
        new(0.50m, CashType.Coin, "50 ¢ Coin", "50 Cent"),
        new(1.00m, CashType.Coin, "$ 1 Coin", "1 Doller"),
        new(2.00m, CashType.Coin, "$ 2 Coin", "2 Doller"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(5.00m, CashType.Bill, "$ 5 Bill", "5 Doller"),
        new(10.00m, CashType.Bill, "$ 10 Bill", "10 Doller"),
        new(20.00m, CashType.Bill, "$ 20 Bill", "20 Doller"),
        new(50.00m, CashType.Bill, "$ 50 Bill", "50 Doller"),
        new(100.00m, CashType.Bill, "$ 100 Bill", "100 Doller"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
