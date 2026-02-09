using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Peruvian Sol Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://www.bcrp.gob.pe/billetes-y-monedas/familia-de-billetes-y-monedas.html">Banco Central de Reserva del Perú - Billetes y Monedas</seealso></description></item>
/// </list>
/// </remarks>
public class PenCurrency :
    ICurrency,
    ICashCountFormattable<PenCurrency>,
    ICurrencyFormattable<PenCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.PEN;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.10m;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Céntimo", "¢", 0.01m),
    ];

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("PEN", "$ n");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("S/", "$ n");

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.10m, CashType.Coin, "10 Céntimos Coin", "10¢"),
        new(0.20m, CashType.Coin, "20 Céntimos Coin", "20¢"),
        new(0.50m, CashType.Coin, "50 Céntimos Coin", "50¢"),
        new(1.0m, CashType.Coin, "1 Sol Coin", "S/ 1"),
        new(2.0m, CashType.Coin, "2 Soles Coin", "S/ 2"),
        new(5.0m, CashType.Coin, "5 Soles Coin", "S/ 5"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(10.0m, CashType.Bill, "10 Soles Bill", "S/ 10"),
        new(20.0m, CashType.Bill, "20 Soles Bill", "S/ 20"),
        new(50.0m, CashType.Bill, "50 Soles Bill", "S/ 50"),
        new(100.0m, CashType.Bill, "100 Soles Bill", "S/ 100"),
        new(200.0m, CashType.Bill, "200 Soles Bill", "S/ 200"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
