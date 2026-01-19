using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Euro Currency</summary>
public class EurCurrency : ICurrency
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.EUR;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static string Symbol => "€";
    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Cent", "¢", 0.01m),
    ];

    /// <inheritdoc/>
    public static CurrencyDisplayFormat DisplayFormat => new(
        Placement: SymbolPlacement.Prefix,
        DecimalZeroReplacement: "."
    );

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "1 Cent"),
        new(0.02m, CashType.Coin, "2 Cents"),
        new(0.05m, CashType.Coin, "5 Cents"),
        new(0.10m, CashType.Coin, "10 Cents"),
        new(0.20m, CashType.Coin, "20 Cents"),
        new(0.50m, CashType.Coin, "50 Cents"),
        new(1.00m, CashType.Coin, "1 Euro"),
        new(2.00m, CashType.Coin, "2 Euros"),
    ];
    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(5.00m, CashType.Bill, "5 Euro Bill"),
        new(10.00m, CashType.Bill, "10 Euro Bill"),
        new(20.00m, CashType.Bill, "20 Euro Bill"),
        new(50.00m, CashType.Bill, "50 Euro Bill"),
        new(100.00m, CashType.Bill, "100 Euro Bill"),
        new(200.00m, CashType.Bill, "200 Euro Bill"),
        new(500.00m, CashType.Bill, "500 Euro Bill"),
    ];
}
