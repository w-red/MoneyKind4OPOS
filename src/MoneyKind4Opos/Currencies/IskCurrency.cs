using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Iceland Krona Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://www.cb.is/notes-and-coins/banknotes/">CBI (Central Bank of Iceland)</seealso></description></item>
/// </list>
/// <para>※ The auxiliary unit "eyrir" (1/100) is no longer in circulation.</para>
/// </remarks>
public class IskCurrency :
    ICurrency,
    ICashCountFormattable<IskCurrency>,
    ICurrencyFormattable<IskCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.ISK;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 1.0m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("kr.", "n $", decimalDigits: 0, groupSep: ".", decimalSep: ",");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Eyrir", null, 0.01m), // No longer in circulation
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(1m, CashType.Coin, "1 Króna", "1 kr"),
        new(5m, CashType.Coin, "5 Krónur", "5 kr", Usage: CashUsagePolicy.NonRecyclable),
        new(10m, CashType.Coin, "10 Krónur", "10 kr", Usage: CashUsagePolicy.NonRecyclable),
        new(50m, CashType.Coin, "50 Krónur", "50 kr", Usage: CashUsagePolicy.NonRecyclable),
        new(100m, CashType.Coin, "100 Krónur", "100 kr", Usage: CashUsagePolicy.NonRecyclable),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(500m, CashType.Bill, "500 Krónur", "500 kr"),
        new(1000m, CashType.Bill, "1000 Krónur", "1000 kr"),
        new(2000m, CashType.Bill, "2000 Krónur", "2000 kr"),
        new(5000m, CashType.Bill, "5000 Krónur", "5000 kr"),
        new(10000m, CashType.Bill, "10000 Krónur", "10000 kr", Usage: CashUsagePolicy.CollectionOnly),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
