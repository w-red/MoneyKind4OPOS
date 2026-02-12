using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Mozambique Metical (MZN).</summary>
/// <remarks>Source: Banco de Moçambique (https://www.bancomoc.mz/)</remarks>
public sealed class MznCurrency :
    ICurrency,
    ICashCountFormattable<MznCurrency>,
    ICurrencyFormattable<MznCurrency>
{
    /// <inheritdoc/>
    public static string Name => "Mozambique Metical";

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.MZN;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static bool IsZeroPadding => true;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("MTn", "n $", decimalDigits: 2, decimalSep: ",", groupSep: "\u00A0");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Centavo", "centavo", 0.01m)
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "1 Centavo Coin", "1 centavo", Usage: CashUsagePolicy.NonRecyclable),
        new(0.05m, CashType.Coin, "5 Centavo Coin", "5 centavos", Usage: CashUsagePolicy.NonRecyclable),
        new(0.10m, CashType.Coin, "10 Centavo Coin", "10 centavos", Usage: CashUsagePolicy.NonRecyclable),
        new(0.20m, CashType.Coin, "20 Centavo Coin", "20 centavos"),
        new(0.50m, CashType.Coin, "50 Centavo Coin", "50 centavos"),
        new(1m, CashType.Coin, "1 Metical Coin", "1 metical"),
        new(2m, CashType.Coin, "2 Metical Coin", "2 meticais"),
        new(5m, CashType.Coin, "5 Metical Coin", "5 meticais"),
        new(10m, CashType.Coin, "10 Metical Coin", "10 meticais"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(20m, CashType.Bill, "20 Metical Bill", "20 meticais"),
        new(50m, CashType.Bill, "50 Metical Bill", "50 meticais"),
        new(100m, CashType.Bill, "100 Metical Bill", "100 meticais"),
        new(200m, CashType.Bill, "200 Metical Bill", "200 meticais"),
        new(500m, CashType.Bill, "500 Metical Bill", "500 meticais"),
        new(1000m, CashType.Bill, "1000 Metical Bill", "1000 meticais"),
    ];
}
