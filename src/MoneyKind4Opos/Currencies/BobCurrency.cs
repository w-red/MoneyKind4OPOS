using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Bolivian Boliviano Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://www.bcb.gob.bo/?q=billetes-y-monedas">Banco Central de Bolivia - Billetes y Monedas</seealso></description></item>
/// </list>
/// </remarks>
public class BobCurrency :
    ICurrency,
    ICashCountFormattable<BobCurrency>,
    ICurrencyFormattable<BobCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.BOB;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.10m;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Centavo", "¢", 0.01m),
    ];

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("BOB", "$ n");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("Bs.", "$ n");

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.10m, CashType.Coin, "10 Centavos Coin", "10¢"),
        new(0.20m, CashType.Coin, "20 Centavos Coin", "20¢"),
        new(0.50m, CashType.Coin, "50 Centavos Coin", "50¢"),
        new(1.0m, CashType.Coin, "1 Boliviano Coin", "Bs.1"),
        new(2.0m, CashType.Coin, "2 Bolivianos Coin", "Bs.2"),
        new(5.0m, CashType.Coin, "5 Bolivianos Coin", "Bs.5"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(10.0m, CashType.Bill, "10 Bolivianos Bill", "Bs.10"),
        new(20.0m, CashType.Bill, "20 Bolivianos Bill", "Bs.20"),
        new(50.0m, CashType.Bill, "50 Bolivianos Bill", "Bs.50"),
        new(100.0m, CashType.Bill, "100 Bolivianos Bill", "Bs.100"),
        new(200.0m, CashType.Bill, "200 Bolivianos Bill", "Bs.200"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
