using MoneyKind4Opos.Codes;

namespace MoneyKind4Opos.Currencies;

/// <summary>US Dollar Currency</summary>
public class UsdCurrency : ICurrency
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.USD;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static string Symbol => "$";
    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Cent", "¢", 0.01m),
    ];

    /// <inheritdoc/>
    public static CurrencyDisplayFormat DisplayFormat => new(
        Placement: SymbolPlacement.Prefix,
        DecimalZeroReplacement: ".",
        GroupSeparator: ",",
        DecimalSeparator: "."
    );

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "1 Cent Coin", "Penny"),
        new(0.05m, CashType.Coin, "5 Cent Coin", "Nickel"),
        new(0.10m, CashType.Coin, "10 Cent Coin", "Dime"),
        new(0.25m, CashType.Coin, "25 Cent Coin", "Quarter"),
        new(0.50m, CashType.Coin, "50 Cent Coin", "Half Dollar"),
        new(1.00m, CashType.Coin, "1 Dollar Coin", "Dollar Coin"),
    ];
    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1.00m, CashType.Bill, "1 Dollar Bill", "One Dollar Bill"),
        new(2.00m, CashType.Bill, "2 Dollar Bill", "Two Dollar Bill"),
        new(5.00m, CashType.Bill, "5 Dollar Bill", "Five Dollar Bill"),
        new(10.00m, CashType.Bill, "10 Dollar Bill", "Ten Dollar Bill"),
        new(20.00m, CashType.Bill, "20 Dollar Bill", "Twenty Dollar Bill"),
        new(50.00m, CashType.Bill, "50 Dollar Bill", "Fifty Dollar Bill"),
        new(100.00m, CashType.Bill, "100 Dollar Bill", "One Hundred Dollar Bill"),
    ];
}
