using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Haitian Gourde Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://www.brh.ht/">BRH (Banque de la République d'Haïti)</seealso></description></item>
/// </list>
/// <para>※ Subsidiary unit (centime) is no longer in practical circulation.</para>
/// </remarks>
public class HtgCurrency :
    ICurrency,
    ICashCountFormattable<HtgCurrency>,
    ICurrencyFormattable<HtgCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.HTG;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.05m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("G", "n $", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("G", "n $", decimalDigits: 2);

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Centime", "c", 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.05m, CashType.Coin, "5 Centimes", "5c"),
        new(0.10m, CashType.Coin, "10 Centimes", "10c"),
        new(0.20m, CashType.Coin, "20 Centimes", "20c"),
        new(0.50m, CashType.Coin, "50 Centimes", "50c"),
        new(1m, CashType.Coin, "1 Gourde", "G1"),
        new(5m, CashType.Coin, "5 Gourdes", "G5"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(10m, CashType.Bill, "10 Gourdes", "G10"),
        new(20m, CashType.Bill, "20 Gourdes", "G20"),
        new(25m, CashType.Bill, "25 Gourdes", "G25"),
        new(50m, CashType.Bill, "50 Gourdes", "G50"),
        new(100m, CashType.Bill, "100 Gourdes", "G100"),
        new(250m, CashType.Bill, "250 Gourdes", "G250"),
        new(500m, CashType.Bill, "500 Gourdes", "G500"),
        new(1000m, CashType.Bill, "1000 Gourdes", "G1000"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
