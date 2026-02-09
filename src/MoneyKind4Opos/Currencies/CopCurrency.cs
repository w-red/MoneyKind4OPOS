using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Colombian Peso Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://www.banrep.gov.co/es/billetes-y-monedas">Banco de la República - Billetes y Monedas</seealso></description></item>
/// </list>
/// </remarks>
public class CopCurrency :
    ICurrency,
    ICashCountFormattable<CopCurrency>,
    ICurrencyFormattable<CopCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.COP;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 50.0m;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Centavo", null, 0.01m),
    ];

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("COP", "$n", decimalDigits: 2); // COP typically uses 2 decimals even if small cents are not physical

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("$", "$n", decimalDigits: 0); // Local often omits decimals for large amounts

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(50.0m, CashType.Coin, "50 Pesos Coin", "$50"),
        new(100.0m, CashType.Coin, "100 Pesos Coin", "$100"),
        new(200.0m, CashType.Coin, "200 Pesos Coin", "$200"),
        new(500.0m, CashType.Coin, "500 Pesos Coin", "$500"),
        new(1000.0m, CashType.Coin, "1000 Pesos Coin", "$1000"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(2000.0m, CashType.Bill, "2000 Pesos Bill", "$2.000"),
        new(5000.0m, CashType.Bill, "5000 Pesos Bill", "$5.000"),
        new(10000.0m, CashType.Bill, "10000 Pesos Bill", "$10.000"),
        new(20000.0m, CashType.Bill, "20000 Pesos Bill", "$20.000"),
        new(50000.0m, CashType.Bill, "50000 Pesos Bill", "$50.000"),
        new(100000.0m, CashType.Bill, "100000 Pesos Bill", "$100.000"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
