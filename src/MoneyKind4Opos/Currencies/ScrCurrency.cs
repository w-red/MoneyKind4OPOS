using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Seychelles Rupee (SCR).</summary>
public sealed class ScrCurrency : ICurrency, ICashCountFormattable<ScrCurrency>, ICurrencyFormattable<ScrCurrency>
{
    private ScrCurrency() { }

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.SCR;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("SR", "n $", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Cent", "¢", 0.01m)
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new CashFaceInfo(0.01m, CashType.Coin, "1 Cent Coin", "1 cent"),
        new CashFaceInfo(0.05m, CashType.Coin, "5 Cent Coin", "5 cents"),
        new CashFaceInfo(0.10m, CashType.Coin, "10 Cent Coin", "10 cents"),
        new CashFaceInfo(0.25m, CashType.Coin, "25 Cent Coin", "25 cents"),
        new CashFaceInfo(0.50m, CashType.Coin, "50 Cent Coin", "50 cents"),
        new CashFaceInfo(1m, CashType.Coin, "1 Rupee Coin", "1 Rupee"),
        new CashFaceInfo(5m, CashType.Coin, "5 Rupee Coin", "5 Rupees")
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new CashFaceInfo(25m, CashType.Bill, "25 Rupee Bill", "25 Rupees note"),
        new CashFaceInfo(50m, CashType.Bill, "50 Rupee Bill", "50 Rupees note"),
        new CashFaceInfo(100m, CashType.Bill, "100 Rupee Bill", "100 Rupees note"),
        new CashFaceInfo(500m, CashType.Bill, "500 Rupee Bill", "500 Rupees note")
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => true;
}
