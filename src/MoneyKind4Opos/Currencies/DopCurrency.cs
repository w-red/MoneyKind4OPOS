using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Dominican Peso Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://www.bcrd.gov.do/">BCRD (Banco Central de la República Dominicana)</seealso></description></item>
/// </list>
/// </remarks>
public class DopCurrency :
    ICurrency,
    ICashCountFormattable<DopCurrency>,
    ICurrencyFormattable<DopCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.DOP;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 1.0m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("RD$", "$n", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("RD$", "$n", decimalDigits: 2);

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Centavo", "¢", 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(1m, CashType.Coin, "1 Peso", "RD$1"),
        new(5m, CashType.Coin, "5 Pesos", "RD$5"),
        new(10m, CashType.Coin, "10 Pesos", "RD$10"),
        new(25m, CashType.Coin, "25 Pesos", "RD$25"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(50m, CashType.Bill, "50 Pesos", "RD$50"),
        new(100m, CashType.Bill, "100 Pesos", "RD$100"),
        new(200m, CashType.Bill, "200 Pesos", "RD$200"),
        new(500m, CashType.Bill, "500 Pesos", "RD$500"),
        new(1000m, CashType.Bill, "1000 Pesos", "RD$1000"),
        new(2000m, CashType.Bill, "2000 Pesos", "RD$2000"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
