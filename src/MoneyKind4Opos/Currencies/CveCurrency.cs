using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Cape Verdean Escudo Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.bcv.cv/">Banco de Cabo Verde</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://www.bcv.cv/">Banco de Cabo Verde</seealso></description></item>
/// </list>
/// </remarks>
public class CveCurrency :
    ICurrency,
    ICashCountFormattable<CveCurrency>,
    ICurrencyFormattable<CveCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.CVE;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 1.0m; // Often 0.50 or 1.00

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("Esc", "n $", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Centavo", "c", 0.01m)
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(1m, CashType.Coin, "1 Escudo", "1$"), // Escudo symbol often used as decimal separator
        new(5m, CashType.Coin, "5 Escudos", "5$"),
        new(10m, CashType.Coin, "10 Escudos", "10$"),
        new(20m, CashType.Coin, "20 Escudos", "20$"),
        new(50m, CashType.Coin, "50 Escudos", "50$"),
        new(100m, CashType.Coin, "100 Escudos", "100$"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(200m, CashType.Bill, "200 Escudos", "200$"),
        new(500m, CashType.Bill, "500 Escudos", "500$"),
        new(1000m, CashType.Bill, "1000 Escudos", "1000$"),
        new(2000m, CashType.Bill, "2000 Escudos", "2000$"),
        new(5000m, CashType.Bill, "5000 Escudos", "5000$"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => true;
}
