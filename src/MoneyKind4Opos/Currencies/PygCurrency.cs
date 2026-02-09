using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Paraguayan Guarani Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://www.bcp.gov.py/billetes-y-monedas-i54">Banco Central del Paraguay - Billetes y Monedas</seealso></description></item>
/// </list>
/// </remarks>
public class PygCurrency :
    ICurrency,
    ICashCountFormattable<PygCurrency>,
    ICurrencyFormattable<PygCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.PYG;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 50.0m;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Céntimo", null, 0.01m),
    ];

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("PYG", "$ n", decimalDigits: 0); // Traditionally no decimals in use

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("₲", "$ n", decimalDigits: 0);

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(50.0m, CashType.Coin, "50 Guaranies Coin", "50 ₲"),
        new(100.0m, CashType.Coin, "100 Guaranies Coin", "100 ₲"),
        new(500.0m, CashType.Coin, "500 Guaranies Coin", "500 ₲"),
        new(1000.0m, CashType.Coin, "1000 Guaranies Coin", "1000 ₲"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(2000.0m, CashType.Bill, "2000 Guaranies Bill", "2000 ₲"),
        new(5000.0m, CashType.Bill, "5000 Guaranies Bill", "5000 ₲"),
        new(10000.0m, CashType.Bill, "10000 Guaranies Bill", "10000 ₲"),
        new(20000.0m, CashType.Bill, "20000 Guaranies Bill", "20000 ₲"),
        new(50000.0m, CashType.Bill, "50000 Guaranies Bill", "50000 ₲"),
        new(100000.0m, CashType.Bill, "100000 Guaranies Bill", "100000 ₲"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
