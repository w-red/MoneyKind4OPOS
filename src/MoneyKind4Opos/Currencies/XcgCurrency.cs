using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Caribbean Guilder Currency (Curaçao / Sint Maarten)</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.centralbank.cw/functions/banknotes-coins/caribbean-guilder-banknotes">CBCS</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://www.centralbank.cw/functions/banknotes-coins/caribbean-guilder-coins">CBCS</seealso></description></item>
/// </list>
/// <para>※ New currency introduced March 31, 2025 replacing ANG.</para>
/// </remarks>
public class XcgCurrency :
    ICurrency,
    ICashCountFormattable<XcgCurrency>,
    ICurrencyFormattable<XcgCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.XCG;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("NAf.", "$ n", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("Cg", "$ n", decimalDigits: 2);

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Cent", "c", 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "1 Cent", "1c"),
        new(0.05m, CashType.Coin, "5 Cents", "5c"),
        new(0.10m, CashType.Coin, "10 Cents", "10c"),
        new(0.25m, CashType.Coin, "25 Cents", "25c"),
        new(0.50m, CashType.Coin, "50 Cents", "50c"),
        new(1m, CashType.Coin, "1 Guilder", "Cg 1"),
        new(5m, CashType.Coin, "5 Guilders", "Cg 5"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(10m, CashType.Bill, "10 Guilders", "Cg 10"),
        new(20m, CashType.Bill, "20 Guilders", "Cg 20"),
        new(50m, CashType.Bill, "50 Guilders", "Cg 50"),
        new(100m, CashType.Bill, "100 Guilders", "Cg 100"),
        new(200m, CashType.Bill, "200 Guilders", "Cg 200"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
