using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Algerian Dinar Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.bank-of-algeria.dz/billets-et-monnaie-metallique/">Banque d'Algérie</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://www.bank-of-algeria.dz/billets-et-monnaie-metallique/">Banque d'Algérie</seealso></description></item>
/// </list>
/// </remarks>
public class DzdCurrency :
    ICurrency,
    ICashCountFormattable<DzdCurrency>,
    ICurrencyFormattable<DzdCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.DZD;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 1.0m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("DA", "n $", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Centime", "c", 0.01m)
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(1m, CashType.Coin, "1 Dinar", "1DA", Usage: CashUsagePolicy.NonRecyclable),
        new(2m, CashType.Coin, "2 Dinars", "2DA", Usage: CashUsagePolicy.NonRecyclable),
        new(5m, CashType.Coin, "5 Dinars", "5DA"),
        new(10m, CashType.Coin, "10 Dinars", "10DA"),
        new(20m, CashType.Coin, "20 Dinars", "20DA"),
        new(50m, CashType.Coin, "50 Dinars", "50DA"),
        new(100m, CashType.Coin, "100 Dinars", "100DA"),
        new(200m, CashType.Coin, "200 Dinars", "200DA"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(200m, CashType.Bill, "200 Dinars", "200DA"),
        new(500m, CashType.Bill, "500 Dinars", "500DA"),
        new(1000m, CashType.Bill, "1000 Dinars", "1000DA"),
        new(2000m, CashType.Bill, "2000 Dinars", "2000DA"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => true;
}
