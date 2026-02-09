using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Kenyan Shilling (KES).</summary>
public sealed class KesCurrency : ICurrency, ICashCountFormattable<KesCurrency>, ICurrencyFormattable<KesCurrency>
{
    private KesCurrency() { }

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.KES;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 1m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("KSh", "n $", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Cent", "c", 0.01m)
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new CashFaceInfo(1m, CashType.Coin, "1 Shilling Coin", "1 Shilling coin"),
        new CashFaceInfo(5m, CashType.Coin, "5 Shilling Coin", "5 Shilling coin"),
        new CashFaceInfo(10m, CashType.Coin, "10 Shilling Coin", "10 Shilling coin"),
        new CashFaceInfo(20m, CashType.Coin, "20 Shilling Coin", "20 Shilling coin"),
        new CashFaceInfo(40m, CashType.Coin, "40 Shilling Coin", "40 Shilling coin")
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new CashFaceInfo(50m, CashType.Bill, "50 Shilling Bill", "50 Shilling note"),
        new CashFaceInfo(100m, CashType.Bill, "100 Shilling Bill", "100 Shilling note"),
        new CashFaceInfo(200m, CashType.Bill, "200 Shilling Bill", "200 Shilling note"),
        new CashFaceInfo(500m, CashType.Bill, "500 Shilling Bill", "500 Shilling note"),
        new CashFaceInfo(1000m, CashType.Bill, "1000 Shilling Bill", "1000 Shilling note")
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => true;
}
