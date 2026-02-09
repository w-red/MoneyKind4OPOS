using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Panamanian Balboa Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://www.mef.gob.pa/">MEF</seealso></description></item>
/// </list>
/// </remarks>
public class PabCurrency :
    ICurrency,
    ICashCountFormattable<PabCurrency>,
    ICurrencyFormattable<PabCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.PAB;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("B/.", "$n");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("B/.", "$n");

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Centésimo", "¢", 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "1 Centésimo", "1¢"),
        new(0.05m, CashType.Coin, "5 Centésimos", "5¢"),
        new(0.10m, CashType.Coin, "1/10 Balboa (Un Décimo)", "10¢"),
        new(0.25m, CashType.Coin, "1/4 Balboa (Un Cuarto)", "25¢"),
        new(0.50m, CashType.Coin, "1/2 Balboa (Medio Balboa)", "50¢"),
        new(1.00m, CashType.Coin, "1 Balboa", "B/.1"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1m, CashType.Bill, "1 Balboa (USD Equivalent)", "B/.1"),
        new(2m, CashType.Bill, "2 Balboas (USD Equivalent)", "B/.2"),
        new(5m, CashType.Bill, "5 Balboas (USD Equivalent)", "B/.5"),
        new(10m, CashType.Bill, "10 Balboas (USD Equivalent)", "B/.10"),
        new(20m, CashType.Bill, "20 Balboas (USD Equivalent)", "B/.20"),
        new(50m, CashType.Bill, "50 Balboas (USD Equivalent)", "B/.50"),
        new(100m, CashType.Bill, "100 Balboas (USD Equivalent)", "B/.100"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
