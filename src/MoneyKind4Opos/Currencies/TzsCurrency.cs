using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Tanzanian Shilling (TZS).</summary>
public sealed class TzsCurrency : ICurrency, ICashCountFormattable<TzsCurrency>, ICurrencyFormattable<TzsCurrency>
{
    private TzsCurrency() { }

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.TZS;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 50m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("TSh", "$ n", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Senti", "c", 0.01m)
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new CashFaceInfo(50m, CashType.Coin, "50 Shilling Coin", "Sarafu ya Shilingi 50"),
        new CashFaceInfo(100m, CashType.Coin, "100 Shilling Coin", "Sarafu ya Shilingi 100"),
        new CashFaceInfo(200m, CashType.Coin, "200 Shilling Coin", "Sarafu ya Shilingi 200"),
        new CashFaceInfo(500m, CashType.Coin, "500 Shilling Coin", "Sarafu ya Shilingi 500")
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new CashFaceInfo(1000m, CashType.Bill, "1000 Shilling Bill", "Noti ya Shilingi 1000"),
        new CashFaceInfo(2000m, CashType.Bill, "2000 Shilling Bill", "Noti ya Shilingi 2000"),
        new CashFaceInfo(5000m, CashType.Bill, "5000 Shilling Bill", "Noti ya Shilingi 5000"),
        new CashFaceInfo(10000m, CashType.Bill, "10000 Shilling Bill", "Noti ya Shilingi 10000")
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => true;
}
