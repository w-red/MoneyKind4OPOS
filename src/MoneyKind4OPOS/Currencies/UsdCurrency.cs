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
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "Penny"),
        new(0.05m, CashType.Coin, "Nickel"),
        new(0.10m, CashType.Coin, "Dime"),
        new(0.25m, CashType.Coin, "Quarter"),
        new(0.50m, CashType.Coin, "Half Dollar"),
        new(1.00m, CashType.Coin, "Dollar Coin"),
    ];
    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1.00m, CashType.Bill, "One Dollar Bill"),
        new(2.00m, CashType.Bill, "Two Dollar Bill"),
        new(5.00m, CashType.Bill, "Five Dollar Bill"),
        new(10.00m, CashType.Bill, "Ten Dollar Bill"),
        new(20.00m, CashType.Bill, "Twenty Dollar Bill"),
        new(50.00m, CashType.Bill, "Fifty Dollar Bill"),
        new(100.00m, CashType.Bill, "One Hundred Dollar Bill"),
    ];
}
