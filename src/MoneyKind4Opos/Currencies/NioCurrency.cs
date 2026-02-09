using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Nicaraguan Córdoba Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://www.bcn.gob.ni/">BCN</seealso></description></item>
/// </list>
/// </remarks>
public class NioCurrency :
    ICurrency,
    ICashCountFormattable<NioCurrency>,
    ICurrencyFormattable<NioCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.NIO;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.05m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("C$", "$n");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("C$", "$n");

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits => [];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.05m, CashType.Coin, "5 Centavos", "5¢"),
        new(0.10m, CashType.Coin, "10 Centavos", "10¢"),
        new(0.25m, CashType.Coin, "25 Centavos", "25¢"),
        new(0.50m, CashType.Coin, "50 Centavos", "50¢"),
        new(1.00m, CashType.Coin, "1 Córdoba", "C$1"),
        new(5.00m, CashType.Coin, "5 Córdobas", "C$5"),
        new(10.00m, CashType.Coin, "10 Córdobas", "C$10"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(10m, CashType.Bill, "10 Córdobas", "C$10"),
        new(20m, CashType.Bill, "20 Córdobas", "C$20"),
        new(50m, CashType.Bill, "50 Córdobas", "C$50"),
        new(100m, CashType.Bill, "100 Córdobas", "C$100"),
        new(200m, CashType.Bill, "200 Córdobas", "C$200"),
        new(500m, CashType.Bill, "500 Córdobas", "C$500"),
        new(1000m, CashType.Bill, "1000 Córdobas", "C$1000"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
