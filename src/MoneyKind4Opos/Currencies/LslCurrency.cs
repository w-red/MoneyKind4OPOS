using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Lesotho Loti (LSL).</summary>
/// <remarks>Source: Central Bank of Lesotho (https://www.centralbank.org.ls/)</remarks>
public sealed class LslCurrency :
    ICurrency,
    ICashCountFormattable<LslCurrency>,
    ICurrencyFormattable<LslCurrency>
{
    /// <inheritdoc/>
    public static string Name => "Loti";

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.LSL;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.10m;

    /// <inheritdoc/>
    public static bool IsZeroPadding => true;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("R", "$n", decimalDigits: 2, decimalSep: ".", groupSep: ",");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Sente", "sente", 0.01m)
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.10m, CashType.Coin, "10 Sente Coin", "10s"),
        new(0.20m, CashType.Coin, "20 Sente Coin", "20s"),
        new(0.50m, CashType.Coin, "50 Sente Coin", "50s"),
        new(1m, CashType.Coin, "1 Loti Coin", "L1"),
        new(2m, CashType.Coin, "2 Maloti Coin", "M2"),
        new(5m, CashType.Coin, "5 Maloti Coin", "M5"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(10m, CashType.Bill, "10 Maloti Bill", "M10"),
        new(20m, CashType.Bill, "20 Maloti Bill", "M20"),
        new(50m, CashType.Bill, "50 Maloti Bill", "M50"),
        new(100m, CashType.Bill, "100 Maloti Bill", "M100"),
        new(200m, CashType.Bill, "200 Maloti Bill", "M200"),
    ];
}
