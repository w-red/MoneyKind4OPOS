using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Eritrean Nakfa (ERN).</summary>
public sealed class ErnCurrency : ICurrency, ICashCountFormattable<ErnCurrency>, ICurrencyFormattable<ErnCurrency>
{
    private ErnCurrency() { }

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.ERN;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("Nfk", "n $", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Cent", "¢", 0.01m)
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new CashFaceInfo(0.01m, CashType.Coin, "1 Cent Coin", "1 cent"),
        new CashFaceInfo(0.05m, CashType.Coin, "5 Cent Coin", "5 cents"),
        new CashFaceInfo(0.10m, CashType.Coin, "10 Cent Coin", "10 cents"),
        new CashFaceInfo(0.25m, CashType.Coin, "25 Cent Coin", "25 cents"),
        new CashFaceInfo(0.50m, CashType.Coin, "50 Cent Coin", "50 cents"),
        new CashFaceInfo(1.00m, CashType.Coin, "1 Nakfa Coin", "1 Nakfa")
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new CashFaceInfo(1m, CashType.Bill, "1 Nakfa Bill", "1 Nakfa note"),
        new CashFaceInfo(5m, CashType.Bill, "5 Nakfa Bill", "5 Nakfa note"),
        new CashFaceInfo(10m, CashType.Bill, "10 Nakfa Bill", "10 Nakfa note"),
        new CashFaceInfo(20m, CashType.Bill, "20 Nakfa Bill", "20 Nakfa note"),
        new CashFaceInfo(50m, CashType.Bill, "50 Nakfa Bill", "50 Nakfa note"),
        new CashFaceInfo(100m, CashType.Bill, "100 Nakfa Bill", "100 Nakfa note")
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => true;
}
