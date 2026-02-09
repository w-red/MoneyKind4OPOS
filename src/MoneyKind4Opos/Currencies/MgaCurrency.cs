using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Malagasy Ariary (MGA).</summary>
/// <remarks>Source: Banky Foiben'i Madagasikara (https://www.banky-foibe.mg/)</remarks>
public sealed class MgaCurrency :
    ICurrency,
    ICashCountFormattable<MgaCurrency>,
    ICurrencyFormattable<MgaCurrency>
{
    /// <inheritdoc/>
    public static string Name => "Malagasy Ariary";

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.MGA;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 1m;

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("Ar", "n $", decimalDigits: 0, groupSep: "\u202F");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Iraimbilanja", "iraimbilanja", 0.2m) // 1/5 of Ariary
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(1m, CashType.Coin, "1 Ariary Coin", "1 Ariary"),
        new(2m, CashType.Coin, "2 Ariary Coin", "2 Ariary"),
        new(5m, CashType.Coin, "5 Ariary Coin", "5 Ariary"),
        new(10m, CashType.Coin, "10 Ariary Coin", "10 Ariary"),
        new(20m, CashType.Coin, "20 Ariary Coin", "20 Ariary"),
        new(50m, CashType.Coin, "50 Ariary Coin", "50 Ariary"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(100m, CashType.Bill, "100 Ariary Bill", "100 Ariary"),
        new(200m, CashType.Bill, "200 Ariary Bill", "200 Ariary"),
        new(500m, CashType.Bill, "500 Ariary Bill", "500 Ariary"),
        new(1000m, CashType.Bill, "1000 Ariary Bill", "1000 Ariary"),
        new(2000m, CashType.Bill, "2000 Ariary Bill", "2000 Ariary"),
        new(5000m, CashType.Bill, "5000 Ariary Bill", "5000 Ariary"),
        new(10000m, CashType.Bill, "10000 Ariary Bill", "10000 Ariary"),
        new(20000m, CashType.Bill, "20000 Ariary Bill", "20000 Ariary"),
    ];
}
