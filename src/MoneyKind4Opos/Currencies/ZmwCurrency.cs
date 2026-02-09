using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Zambian Kwacha (ZMW).</summary>
/// <remarks>Source: Bank of Zambia (https://www.boz.zm/)</remarks>
public sealed class ZmwCurrency :
    ICurrency,
    ICashCountFormattable<ZmwCurrency>,
    ICurrencyFormattable<ZmwCurrency>
{
    /// <inheritdoc/>
    public static string Name => "Zambian Kwacha";

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.ZMW;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.05m;

    /// <inheritdoc/>
    public static bool IsZeroPadding => true;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("K", "$n", decimalDigits: 2, decimalSep: ".", groupSep: ",");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Ngwee", "ngwee", 0.01m)
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.05m, CashType.Coin, "5 Ngwee Coin", "5 Ngwee"),
        new(0.10m, CashType.Coin, "10 Ngwee Coin", "10 Ngwee"),
        new(0.50m, CashType.Coin, "50 Ngwee Coin", "50 Ngwee"),
        new(1m, CashType.Coin, "1 Kwacha Coin", "1 Kwacha"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(2m, CashType.Bill, "2 Kwacha Bill", "2 Kwacha"),
        new(5m, CashType.Bill, "5 Kwacha Bill", "5 Kwacha"),
        new(10m, CashType.Bill, "10 Kwacha Bill", "10 Kwacha"),
        new(20m, CashType.Bill, "20 Kwacha Bill", "20 Kwacha"),
        new(50m, CashType.Bill, "50 Kwacha Bill", "50 Kwacha"),
        new(100m, CashType.Bill, "100 Kwacha Bill", "100 Kwacha"),
    ];
}
