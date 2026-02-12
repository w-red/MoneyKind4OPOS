using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Rwanda Franc (RWF).</summary>
public sealed class RwfCurrency : ICurrency, ICashCountFormattable<RwfCurrency>, ICurrencyFormattable<RwfCurrency>
{
    private RwfCurrency() { }

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.RWF;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 1m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("FRw", "n $", decimalDigits: 0);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits => [];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new CashFaceInfo(1m, CashType.Coin, "1 Franc Coin", "Igiceri cy'Ifranga 1", Usage: CashUsagePolicy.NonRecyclable),
        new CashFaceInfo(5m, CashType.Coin, "5 Franc Coin", "Igiceri cy'Amafaranga 5", Usage: CashUsagePolicy.NonRecyclable),
        new CashFaceInfo(10m, CashType.Coin, "10 Franc Coin", "Igiceri cy'Amafaranga 10", Usage: CashUsagePolicy.NonRecyclable),
        new CashFaceInfo(20m, CashType.Coin, "20 Franc Coin", "Igiceri cy'Amafaranga 20", Usage: CashUsagePolicy.NonRecyclable),
        new CashFaceInfo(50m, CashType.Coin, "50 Franc Coin", "Igiceri cy'Amafaranga 50", Usage: CashUsagePolicy.NonRecyclable),
        new CashFaceInfo(100m, CashType.Coin, "100 Franc Coin", "Igiceri cy'Amafaranga 100")
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new CashFaceInfo(500m, CashType.Bill, "500 Franc Bill", "Inoti y'Amafaranga 500"),
        new CashFaceInfo(1000m, CashType.Bill, "1000 Franc Bill", "Inoti y'Amafaranga 1000"),
        new CashFaceInfo(2000m, CashType.Bill, "2000 Franc Bill", "Inoti y'Amafaranga 2000"),
        new CashFaceInfo(5000m, CashType.Bill, "5000 Franc Bill", "Inoti y'Amafaranga 5000"),
        new CashFaceInfo(10000m, CashType.Bill, "10000 Franc Bill", "Inoti y'Amafaranga 10000")
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
