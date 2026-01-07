using MoneyKind4Opos.Codes;

namespace MoneyKind4Opos.Currencies;

/// <summary>Chinese Yuan Currency</summary>
public class CnyCurrency : ICurrency
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.CNY;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "1分硬币"),
        new(0.02m, CashType.Coin, "2分硬币"),
        new(0.05m, CashType.Coin, "5分硬币"),
        new(0.10m, CashType.Coin, "1角硬币"),
        new(0.20m, CashType.Coin, "2角硬币"),
        new(0.50m, CashType.Coin, "5角硬币"),
        new(1.00m, CashType.Coin, "1元硬币"),
    ];
    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(0.10m, CashType.Bill, "1角券"),
        new(0.50m, CashType.Bill, "5角券"),
        new(1.00m, CashType.Bill, "1元券"),
        new(5.00m, CashType.Bill, "5元券"),
        new(10.00m, CashType.Bill, "10元券"),
        new(20.00m, CashType.Bill, "20元券"),
        new(50.00m, CashType.Bill, "50元券"),
        new(100.00m, CashType.Bill, "100元券"),
    ];
}
