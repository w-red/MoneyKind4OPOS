using MoneyKind4Opos;
using MoneyKind4Opos.Codes;

namespace MoneyKind4OPOS.Currencies;

/// <summary>British Pound Sterling Currency</summary>
public class GbpCurrency : ICurrency
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.GBP;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "One Penny"),
        new(0.02m, CashType.Coin, "Two Pence"),
        new(0.05m, CashType.Coin, "Five Pence"),
        new(0.10m, CashType.Coin, "Ten Pence"),
        new(0.20m, CashType.Coin, "Twenty Pence"),
        new(0.50m, CashType.Coin, "Fifty Pence"),
        new(1.00m, CashType.Coin, "One Pound Coin"),
        new(2.00m, CashType.Coin, "Two Pound Coin"),
    ];
    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(5.00m, CashType.Bill, "Five Pound Note"),
        new(10.00m, CashType.Bill, "Ten Pound Note"),
        new(20.00m, CashType.Bill, "Twenty Pound Note"),
        new(50.00m, CashType.Bill, "Fifty Pound Note"),
    ];
}
