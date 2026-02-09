using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Ethiopian Birr (ETB).</summary>
public sealed class EtbCurrency : ICurrency, ICashCountFormattable<EtbCurrency>, ICurrencyFormattable<EtbCurrency>
{
    private EtbCurrency() { }

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.ETB;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("ብር", "$n", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Santim", "c", 0.01m)
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new CashFaceInfo(0.01m, CashType.Coin, "1 Santim Coin", "1 Santim"),
        new CashFaceInfo(0.05m, CashType.Coin, "5 Santim Coin", "5 Santim"),
        new CashFaceInfo(0.10m, CashType.Coin, "10 Santim Coin", "10 Santim"),
        new CashFaceInfo(0.25m, CashType.Coin, "25 Santim Coin", "25 Santim"),
        new CashFaceInfo(0.50m, CashType.Coin, "50 Santim Coin", "50 Santim")
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new CashFaceInfo(1m, CashType.Bill, "1 Birr Bill", "1 Birr note"),
        new CashFaceInfo(5m, CashType.Bill, "5 Birr Bill", "5 Birr note"),
        new CashFaceInfo(10m, CashType.Bill, "10 Birr Bill", "10 Birr note"),
        new CashFaceInfo(50m, CashType.Bill, "50 Birr Bill", "50 Birr note"),
        new CashFaceInfo(100m, CashType.Bill, "100 Birr Bill", "100 Birr note"),
        new CashFaceInfo(200m, CashType.Bill, "200 Birr Bill", "200 Birr note")
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => true;
}
