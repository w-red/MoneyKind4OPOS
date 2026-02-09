using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Angolan Kwanza (AOA).</summary>
/// <remarks>Source: Banco Nacional de Angola (https://www.bna.ao/)</remarks>
public sealed class AoaCurrency :
    ICurrency,
    ICashCountFormattable<AoaCurrency>,
    ICurrencyFormattable<AoaCurrency>
{
    /// <inheritdoc/>
    public static string Name => "Angolan Kwanza";

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.AOA;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 1m;

    /// <inheritdoc/>
    public static bool IsZeroPadding => true;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("Kz", "n $", decimalDigits: 2, decimalSep: ",", groupSep: "\u00A0");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Lwei", "lwei", 0.01m)
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(1m, CashType.Coin, "1 Kwanza Coin", "1 Kwanza"),
        new(5m, CashType.Coin, "5 Kwanza Coin", "5 Kwanzas"),
        new(10m, CashType.Coin, "10 Kwanza Coin", "10 Kwanzas"),
        new(20m, CashType.Coin, "20 Kwanza Coin", "20 Kwanzas"),
        new(50m, CashType.Coin, "50 Kwanza Coin", "50 Kwanzas"),
        new(100m, CashType.Coin, "100 Kwanza Coin", "100 Kwanzas"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(200m, CashType.Bill, "200 Kwanza Bill", "200 Kwanzas"),
        new(500m, CashType.Bill, "500 Kwanza Bill", "500 Kwanzas"),
        new(1000m, CashType.Bill, "1000 Kwanza Bill", "1000 Kwanzas"),
        new(2000m, CashType.Bill, "2000 Kwanza Bill", "2000 Kwanzas"),
        new(5000m, CashType.Bill, "5000 Kwanza Bill", "5000 Kwanzas"),
    ];
}
