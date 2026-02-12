using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>West African CFA Franc</summary>
/// <seealso href="https://www.bceao.int/fr/content/billets-et-pieces">Les billets et les pièces (BCEAO)</seealso>
public class XofCurrency :
    ICurrency,
    ICashCountFormattable<XofCurrency>,
    ICurrencyFormattable<XofCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.XOF;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 1m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("XOF", "n $", decimalDigits: 0, groupSep: " ");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("CFA", "n $", decimalDigits: 0, groupSep: " ");

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits => [];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(1m, CashType.Coin, "1 Franc", "1 CFA", Usage: CashUsagePolicy.NonRecyclable),
        new(5m, CashType.Coin, "5 Francs", "5 CFA", Usage: CashUsagePolicy.NonRecyclable),
        new(10m, CashType.Coin, "10 Francs", "10 CFA", Usage: CashUsagePolicy.NonRecyclable),
        new(25m, CashType.Coin, "25 Francs", "25 CFA", Usage: CashUsagePolicy.NonRecyclable),
        new(50m, CashType.Coin, "50 Francs", "50 CFA"),
        new(100m, CashType.Coin, "100 Francs", "100 CFA"),
        new(200m, CashType.Coin, "200 Francs", "200 CFA"),
        new(500m, CashType.Coin, "500 Francs", "500 CFA"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(500m, CashType.Bill, "500 Francs", "500 CFA"),
        new(1000m, CashType.Bill, "1000 Francs", "1000 CFA"),
        new(2000m, CashType.Bill, "2000 Francs", "2000 CFA"),
        new(5000m, CashType.Bill, "5000 Francs", "5000 CFA"),
        new(10000m, CashType.Bill, "10000 Francs", "10000 CFA", Usage: CashUsagePolicy.CollectionOnly),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
