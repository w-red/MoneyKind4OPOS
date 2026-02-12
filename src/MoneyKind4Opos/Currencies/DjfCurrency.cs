using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Djibouti Franc (DJF).</summary>
public sealed class DjfCurrency : ICurrency, ICashCountFormattable<DjfCurrency>, ICurrencyFormattable<DjfCurrency>
{
    private DjfCurrency() { }

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.DJF;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 1m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("Fdj", "n $", decimalDigits: 0, groupSep: "\u202F");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits => [];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new CashFaceInfo(1m, CashType.Coin, "1 Franc Coin", "1 Franc", Usage: CashUsagePolicy.NonRecyclable),
        new CashFaceInfo(2m, CashType.Coin, "2 Franc Coin", "2 Francs", Usage: CashUsagePolicy.NonRecyclable),
        new CashFaceInfo(5m, CashType.Coin, "5 Franc Coin", "5 Francs", Usage: CashUsagePolicy.NonRecyclable),
        new CashFaceInfo(10m, CashType.Coin, "10 Franc Coin", "10 Francs", Usage: CashUsagePolicy.NonRecyclable),
        new CashFaceInfo(20m, CashType.Coin, "20 Franc Coin", "20 Francs", Usage: CashUsagePolicy.NonRecyclable),
        new CashFaceInfo(50m, CashType.Coin, "50 Franc Coin", "50 Francs", Usage: CashUsagePolicy.NonRecyclable),
        new CashFaceInfo(100m, CashType.Coin, "100 Franc Coin", "100 Francs"),
        new CashFaceInfo(250m, CashType.Coin, "250 Franc Coin", "250 Francs"),
        new CashFaceInfo(500m, CashType.Coin, "500 Franc Coin", "500 Francs")
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new CashFaceInfo(1000m, CashType.Bill, "1000 Franc Bill", "1000 Francs"),
        new CashFaceInfo(2000m, CashType.Bill, "2000 Franc Bill", "2000 Francs"),
        new CashFaceInfo(5000m, CashType.Bill, "5000 Franc Bill", "5000 Francs"),
        new CashFaceInfo(10000m, CashType.Bill, "10000 Franc Bill", "10000 Francs")
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
