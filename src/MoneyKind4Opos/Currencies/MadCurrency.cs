using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Moroccan Dirham Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.bkam.ma/en/Currency/Banknotes/Banknote-series">Bank Al-Maghrib</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://www.bkam.ma/en/Currency/Coins/Coins-in-circulation">Bank Al-Maghrib</seealso></description></item>
/// </list>
/// </remarks>
public class MadCurrency :
    ICurrency,
    ICashCountFormattable<MadCurrency>,
    ICurrencyFormattable<MadCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.MAD;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.10m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("DH", "n $", decimalDigits: 2);

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
        new(0.10m, CashType.Coin, "10 Santimat", "10c", Usage: CashUsagePolicy.NonRecyclable),
        new(0.20m, CashType.Coin, "20 Santimat", "20c", Usage: CashUsagePolicy.NonRecyclable),
        new(0.50m, CashType.Coin, "1/2 Dirham", "1/2DH"),
        new(1m, CashType.Coin, "1 Dirham", "1DH"),
        new(2m, CashType.Coin, "2 Dirhams", "2DH"),
        new(5m, CashType.Coin, "5 Dirhams", "5DH"),
        new(10m, CashType.Coin, "10 Dirhams", "10DH"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(20m, CashType.Bill, "20 Dirhams", "20DH"),
        new(50m, CashType.Bill, "50 Dirhams", "50DH"),
        new(100m, CashType.Bill, "100 Dirhams", "100DH"),
        new(200m, CashType.Bill, "200 Dirhams", "200DH"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => true;
}
