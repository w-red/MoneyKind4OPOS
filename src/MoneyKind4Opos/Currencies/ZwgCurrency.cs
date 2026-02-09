using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Zimbabwe Gold (ZWG).</summary>
/// <remarks>Source: Reserve Bank of Zimbabwe (https://www.rbz.co.zw/)</remarks>
public sealed class ZwgCurrency :
    ICurrency,
    ICashCountFormattable<ZwgCurrency>,
    ICurrencyFormattable<ZwgCurrency>
{
    /// <inheritdoc/>
    public static string Name => "Zimbabwe Gold";

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.ZWG;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m; // 1 Cent

    /// <inheritdoc/>
    public static bool IsZeroPadding => true;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("US$", "$n", decimalDigits: 2, decimalSep: ".", groupSep: ",");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Cent", "cent", 0.01m)
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "1 Cent Coin", "1c"),
        new(0.02m, CashType.Coin, "2 Cent Coin", "2c"),
        new(0.05m, CashType.Coin, "5 Cent Coin", "5c"),
        new(0.10m, CashType.Coin, "10 Cent Coin", "10c"),
        new(0.25m, CashType.Coin, "25 Cent Coin", "25c"),
        new(0.50m, CashType.Coin, "50 Cent Coin", "50c"),
        new(1m, CashType.Coin, "1 ZiG Coin", "1 ZiG"),
        new(2m, CashType.Coin, "2 ZiG Coin", "2 ZiG"),
        new(5m, CashType.Coin, "5 ZiG Coin", "5 ZiG"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(10m, CashType.Bill, "10 ZiG Bill", "10 ZiG"),
        new(20m, CashType.Bill, "20 ZiG Bill", "20 ZiG"),
        new(50m, CashType.Bill, "50 ZiG Bill", "50 ZiG"),
        new(100m, CashType.Bill, "100 ZiG Bill", "100 ZiG"),
        new(200m, CashType.Bill, "200 ZiG Bill", "200 ZiG"),
    ];
}
