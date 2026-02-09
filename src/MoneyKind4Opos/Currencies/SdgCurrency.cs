using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Sudanese Pound (SDG).</summary>
public sealed class SdgCurrency : ICurrency, ICashCountFormattable<SdgCurrency>, ICurrencyFormattable<SdgCurrency>
{
    private SdgCurrency() { }

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.SDG;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create(symbol: "\u062C.\u0633.", pattern: "n $", decimalDigits: 2, decimalSep: "\u066B", groupSep: "\u066C");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Piastre", "c", 0.01m)
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new CashFaceInfo(0.01m, CashType.Coin, "1 Piastre Coin", "1 piastre"),
        new CashFaceInfo(0.05m, CashType.Coin, "5 Piastre Coin", "5 piastres"),
        new CashFaceInfo(0.10m, CashType.Coin, "10 Piastre Coin", "10 piastres"),
        new CashFaceInfo(0.20m, CashType.Coin, "20 Piastre Coin", "20 piastres"),
        new CashFaceInfo(0.50m, CashType.Coin, "50 Piastre Coin", "50 piastres"),
        new CashFaceInfo(1.00m, CashType.Coin, "1 Pound Coin", "1 Pound")
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new CashFaceInfo(1m, CashType.Bill, "1 Pound Bill", "1 Pound note"),
        new CashFaceInfo(2m, CashType.Bill, "2 Pound Bill", "2 Pounds note"),
        new CashFaceInfo(5m, CashType.Bill, "5 Pound Bill", "5 Pounds note"),
        new CashFaceInfo(10m, CashType.Bill, "10 Pound Bill", "10 Pounds note"),
        new CashFaceInfo(20m, CashType.Bill, "20 Pound Bill", "20 Pounds note"),
        new CashFaceInfo(50m, CashType.Bill, "50 Pound Bill", "50 Pounds note"),
        new CashFaceInfo(100m, CashType.Bill, "100 Pound Bill", "100 Pounds note"),
        new CashFaceInfo(200m, CashType.Bill, "200 Pound Bill", "200 Pounds note"),
        new CashFaceInfo(500m, CashType.Bill, "500 Pound Bill", "500 Pounds note"),
        new CashFaceInfo(1000m, CashType.Bill, "1000 Pound Bill", "1000 Pounds note")
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => true;
}
