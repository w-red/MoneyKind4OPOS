using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Namibian Dollar (NAD).</summary>
/// <remarks>Source: Bank of Namibia (https://www.bon.com.na/)</remarks>
public sealed class NadCurrency :
    ICurrency,
    ICashCountFormattable<NadCurrency>,
    ICurrencyFormattable<NadCurrency>
{
    /// <inheritdoc/>
    public static string Name => "Namibian Dollar";

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.NAD;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.05m;

    /// <inheritdoc/>
    public static bool IsZeroPadding => true;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("$", "$n", decimalDigits: 2, decimalSep: ".", groupSep: ",");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Cent", "cent", 0.01m)
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.05m, CashType.Coin, "5 Cent Coin", "5c", Usage: CashUsagePolicy.NonRecyclable),
        new(0.10m, CashType.Coin, "10 Cent Coin", "10c"),
        new(0.50m, CashType.Coin, "50 Cent Coin", "50c"),
        new(1m, CashType.Coin, "1 Dollar Coin", "$1"),
        new(5m, CashType.Coin, "5 Dollar Coin", "$5"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(10m, CashType.Bill, "10 Dollar Bill", "$10"),
        new(20m, CashType.Bill, "20 Dollar Bill", "$20"),
        new(30m, CashType.Bill, "30 Dollar Bill", "$30"),
        new(50m, CashType.Bill, "50 Dollar Bill", "$50"),
        new(100m, CashType.Bill, "100 Dollar Bill", "$100"),
        new(200m, CashType.Bill, "200 Dollar Bill", "$200"),
    ];
}
