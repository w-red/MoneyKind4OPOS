using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Tunisian Dinar Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.bct.gov.tn/bct/siteprod/index.jsp">Banque Centrale de Tunisie</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://www.bct.gov.tn/bct/siteprod/index.jsp">Banque Centrale de Tunisie</seealso></description></item>
/// </list>
/// </remarks>
public class TndCurrency :
    ICurrency,
    ICashCountFormattable<TndCurrency>,
    ICurrencyFormattable<TndCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.TND;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.010m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("DT", "n $", decimalDigits: 3);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Milim", "m", 0.001m)
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.010m, CashType.Coin, "10 Milim", "10m", Usage: CashUsagePolicy.NonRecyclable),
        new(0.020m, CashType.Coin, "20 Milim", "20m", Usage: CashUsagePolicy.NonRecyclable),
        new(0.050m, CashType.Coin, "50 Milim", "50m"),
        new(0.100m, CashType.Coin, "100 Milim", "100m"),
        new(0.200m, CashType.Coin, "200 Milim", "200m"),
        new(0.500m, CashType.Coin, "1/2 Dinar", "1/2DT"),
        new(1m, CashType.Coin, "1 Dinar", "1DT"),
        new(2m, CashType.Coin, "2 Dinars", "2DT"),
        new(5m, CashType.Coin, "5 Dinars", "5DT"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(5m, CashType.Bill, "5 Dinars", "5DT"),
        new(10m, CashType.Bill, "10 Dinars", "10DT"),
        new(20m, CashType.Bill, "20 Dinars", "20DT"),
        new(50m, CashType.Bill, "50 Dinars", "50DT"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => true;
}
