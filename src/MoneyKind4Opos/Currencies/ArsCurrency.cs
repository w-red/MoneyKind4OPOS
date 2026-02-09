using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Argentine Peso Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://www.bcra.gob.ar/MediosPago/Emisiones_vigentes.asp">Banco Central de la República Argentina - Legal Tender</seealso></description></item>
/// </list>
/// </remarks>
public class ArsCurrency :
    ICurrency,
    ICashCountFormattable<ArsCurrency>,
    ICurrencyFormattable<ArsCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.ARS;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 1.0m;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Centavo", "¢", 0.01m),
    ];

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("ARS", "$n");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("$", "$n");

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(1.0m, CashType.Coin, "1 Peso Coin", "$1"),
        new(2.0m, CashType.Coin, "2 Pesos Coin", "$2"),
        new(5.0m, CashType.Coin, "5 Pesos Coin", "$5"),
        new(10.0m, CashType.Coin, "10 Pesos Coin", "$10"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(10.0m, CashType.Bill, "10 Pesos Bill", "$10"),
        new(20.0m, CashType.Bill, "20 Pesos Bill", "$20"),
        new(50.0m, CashType.Bill, "50 Pesos Bill", "$50"),
        new(100.0m, CashType.Bill, "100 Pesos Bill", "$100"),
        new(200.0m, CashType.Bill, "200 Pesos Bill", "$200"),
        new(500.0m, CashType.Bill, "500 Pesos Bill", "$500"),
        new(1000.0m, CashType.Bill, "1000 Pesos Bill", "$1000"),
        new(2000.0m, CashType.Bill, "2000 Pesos Bill", "$2000"),
        new(10000.0m, CashType.Bill, "10000 Pesos Bill", "$10000"),
        new(20000.0m, CashType.Bill, "20000 Pesos Bill", "$20000"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
