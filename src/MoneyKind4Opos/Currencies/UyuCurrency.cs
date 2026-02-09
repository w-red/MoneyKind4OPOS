using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Uruguayan Peso Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://www.bcu.gub.uy/Billetes-y-Monedas/Paginas/Billetes-Monedas-en-Circulacion.aspx">Banco Central del Uruguay - Billetes y Monedas</seealso></description></item>
/// </list>
/// </remarks>
public class UyuCurrency :
    ICurrency,
    ICashCountFormattable<UyuCurrency>,
    ICurrencyFormattable<UyuCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.UYU;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 1.0m;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Centésimo", null, 0.01m),
    ];

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("UYU", "$n", decimalDigits: 0); // Assuming 1.0 min unit means no decimals typically used or desired

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("$U", "$n", decimalDigits: 0);

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(1.0m, CashType.Coin, "1 Peso Coin", "$U 1"),
        new(2.0m, CashType.Coin, "2 Pesos Coin", "$U 2"),
        new(5.0m, CashType.Coin, "5 Pesos Coin", "$U 5"),
        new(10.0m, CashType.Coin, "10 Pesos Coin", "$U 10"),
        new(50.0m, CashType.Coin, "50 Pesos Coin", "$U 50"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(20.0m, CashType.Bill, "20 Pesos Bill", "$U 20"),
        new(50.0m, CashType.Bill, "50 Pesos Bill", "$U 50"),
        new(100.0m, CashType.Bill, "100 Pesos Bill", "$U 100"),
        new(200.0m, CashType.Bill, "200 Pesos Bill", "$U 200"),
        new(500.0m, CashType.Bill, "500 Pesos Bill", "$U 500"),
        new(1000.0m, CashType.Bill, "1000 Pesos Bill", "$U 1.000"),
        new(2000.0m, CashType.Bill, "2000 Pesos Bill", "$U 2.000"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
