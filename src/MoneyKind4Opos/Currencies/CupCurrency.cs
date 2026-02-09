using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Cuban Peso Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://www.bc.gob.cu/">BCC (Banco Central de Cuba)</seealso></description></item>
/// </list>
/// </remarks>
public class CupCurrency :
    ICurrency,
    ICashCountFormattable<CupCurrency>,
    ICurrencyFormattable<CupCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.CUP;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("$", "$n", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("$", "$n", decimalDigits: 2);

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Centavo", "¢", 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "1 Centavo", "1¢"),
        new(0.02m, CashType.Coin, "2 Centavos", "2¢"),
        new(0.05m, CashType.Coin, "5 Centavos", "5¢"),
        new(0.20m, CashType.Coin, "20 Centavos", "20¢"),
        new(1.00m, CashType.Coin, "1 Peso", "$1"),
        new(3.00m, CashType.Coin, "3 Pesos", "$3"),
        new(5.00m, CashType.Coin, "5 Pesos", "$5"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1m, CashType.Bill, "1 Peso", "$1"),
        new(3m, CashType.Bill, "3 Pesos", "$3"),
        new(5m, CashType.Bill, "5 Pesos", "$5"),
        new(10m, CashType.Bill, "10 Pesos", "$10"),
        new(20m, CashType.Bill, "20 Pesos", "$20"),
        new(50m, CashType.Bill, "50 Pesos", "$50"),
        new(100m, CashType.Bill, "100 Pesos", "$100"),
        new(200m, CashType.Bill, "200 Pesos", "$200"),
        new(500m, CashType.Bill, "500 Pesos", "$500"),
        new(1000m, CashType.Bill, "1000 Pesos", "$1000"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
