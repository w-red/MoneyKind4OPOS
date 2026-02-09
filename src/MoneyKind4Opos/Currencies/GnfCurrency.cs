using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Guinean Franc Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.bcrg-guinee.org/">Banque Centrale de la République de Guinée</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://www.bcrg-guinee.org/">Banque Centrale de la République de Guinée</seealso></description></item>
/// </list>
/// </remarks>
public class GnfCurrency :
    ICurrency,
    ICashCountFormattable<GnfCurrency>,
    ICurrencyFormattable<GnfCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.GNF;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 1.0m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("FG", "n $", decimalDigits: 0);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits => []; // Centime deprecated

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(1m, CashType.Coin, "1 Franc", "1FG"),
        new(5m, CashType.Coin, "5 Francs", "5FG"),
        new(10m, CashType.Coin, "10 Francs", "10FG"),
        new(25m, CashType.Coin, "25 Francs", "25FG"),
        new(50m, CashType.Coin, "50 Francs", "50FG"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(100m, CashType.Bill, "100 Francs", "100FG"),
        new(500m, CashType.Bill, "500 Francs", "500FG"),
        new(1000m, CashType.Bill, "1000 Francs", "1000FG"),
        new(2000m, CashType.Bill, "2000 Francs", "2000FG"),
        new(5000m, CashType.Bill, "5000 Francs", "5000FG"),
        new(10000m, CashType.Bill, "10000 Francs", "10000FG"),
        new(20000m, CashType.Bill, "20000 Francs", "20000FG"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
