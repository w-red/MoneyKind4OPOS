using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Malawian Kwacha (MWK).</summary>
/// <remarks>Source: Reserve Bank of Malawi (https://www.rbm.mw/)</remarks>
public sealed class MwkCurrency :
    ICurrency,
    ICashCountFormattable<MwkCurrency>,
    ICurrencyFormattable<MwkCurrency>
{
    /// <inheritdoc/>
    public static string Name => "Malawian Kwacha";

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.MWK;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 1m;

    /// <inheritdoc/>
    public static bool IsZeroPadding => true;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("MK", "$n", decimalDigits: 2, decimalSep: ".", groupSep: ",");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Tambala", "tambala", 0.01m)
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(1m, CashType.Coin, "1 Kwacha Coin", "MK1"),
        new(5m, CashType.Coin, "5 Kwacha Coin", "MK5"),
        new(10m, CashType.Coin, "10 Kwacha Coin", "MK10"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(20m, CashType.Bill, "20 Kwacha Bill", "MK20"),
        new(50m, CashType.Bill, "50 Kwacha Bill", "MK50"),
        new(100m, CashType.Bill, "100 Kwacha Bill", "MK100"),
        new(200m, CashType.Bill, "200 Kwacha Bill", "MK200"),
        new(500m, CashType.Bill, "500 Kwacha Bill", "MK500"),
        new(1000m, CashType.Bill, "1000 Kwacha Bill", "MK1000"),
        new(2000m, CashType.Bill, "2000 Kwacha Bill", "MK2000"),
        new(5000m, CashType.Bill, "5000 Kwacha Bill", "MK5000"),
    ];
}
