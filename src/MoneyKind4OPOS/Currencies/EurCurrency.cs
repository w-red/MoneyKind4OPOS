using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Euro Currency</summary>
public class EurCurrency :
    ICurrency,
    ICashCountFormattable<EurCurrency>,
    ICurrencyFormattable<EurCurrency>
{
    private static readonly NumberFormatInfo _nfi = new()
    {
        CurrencySymbol = "€",
        CurrencyPositivePattern = 3, // n €
        CurrencyGroupSeparator = ".",
        CurrencyDecimalSeparator = ",",
        CurrencyDecimalDigits = 2,
    };

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.EUR;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } = new(
        Symbol: "€",
        NumberFormat: _nfi,
        DisplayFormat: new(SymbolPlacement.Postfix)
    );

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Cent", "c", 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "1 Cent Coin", "1 Cent"),
        new(0.02m, CashType.Coin, "2 Cent Coin", "2 Cent"),
        new(0.05m, CashType.Coin, "5 Cent Coin", "5 Cent"),
        new(0.10m, CashType.Coin, "10 Cent Coin", "10 Cent"),
        new(0.20m, CashType.Coin, "20 Cent Coin", "20 Cent"),
        new(0.50m, CashType.Coin, "50 Cent Coin", "50 Cent"),
        new(1.00m, CashType.Coin, "1 Euro Coin", "1 Euro"),
        new(2.00m, CashType.Coin, "2 Euro Coin", "2 Euro"),
    ];
    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(5.00m, CashType.Bill, "5 Euro Bill", "5 Euro"),
        new(10.00m, CashType.Bill, "10 Euro Bill", "10 Euro"),
        new(20.00m, CashType.Bill, "20 Euro Bill", "20 Euro"),
        new(50.00m, CashType.Bill, "50 Euro Bill", "50 Euro"),
        new(100.00m, CashType.Bill, "100 Euro Bill", "100 Euro"),
        new(200.00m, CashType.Bill, "200 Euro Bill", "200 Euro"),
        new(500.00m, CashType.Bill, "500 Euro Bill", "500 Euro"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
