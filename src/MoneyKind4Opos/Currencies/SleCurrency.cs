using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Sierra Leonean Leone Currency (Re-denominated 2022)</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.bsl.gov.sl/banknotes.html">Bank of Sierra Leone</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://www.bsl.gov.sl/coins.html">Bank of Sierra Leone</seealso></description></item>
/// </list>
/// </remarks>
public class SleCurrency :
    ICurrency,
    ICashCountFormattable<SleCurrency>,
    ICurrencyFormattable<SleCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.SLE;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("Le", "$n", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Cent", "c", 0.01m)
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "1 Cent", "1c", Usage: CashUsagePolicy.NonRecyclable),
        new(0.05m, CashType.Coin, "5 Cents", "5c", Usage: CashUsagePolicy.NonRecyclable),
        new(0.10m, CashType.Coin, "10 Cents", "10c", Usage: CashUsagePolicy.NonRecyclable),
        new(0.25m, CashType.Coin, "25 Cents", "25c", Usage: CashUsagePolicy.NonRecyclable),
        new(0.50m, CashType.Coin, "50 Cents", "50c", Usage: CashUsagePolicy.NonRecyclable),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1m, CashType.Bill, "1 Leone", "Le1"),
        new(2m, CashType.Bill, "2 Leones", "Le2"),
        new(5m, CashType.Bill, "5 Leones", "Le5"),
        new(10m, CashType.Bill, "10 Leones", "Le10"),
        new(20m, CashType.Bill, "20 Leones", "Le20"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => true;
}
