using MoneyKind4Opos.Codes;

namespace MoneyKind4Opos.Jpy;

/// <summary>Japanese Yen Currency</summary>
public class JpyCurrency : ICurrency
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.JPY;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 1m;

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(1m, CashType.Coin, "一円玉"),
        new(5m, CashType.Coin, "五円玉"),
        new(10m, CashType.Coin, "十円玉"),
        new(50m, CashType.Coin, "五十円玉"),
        new(100m, CashType.Coin, "百円玉"),
        new(500m, CashType.Coin, "五百円玉"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1000m, CashType.Bill, "千円札"),
        new(2000m, CashType.Bill, "二千円札"),
        new(5000m, CashType.Bill, "五千円札"),
        new(10000m, CashType.Bill, "一万円札"),
    ];
}
