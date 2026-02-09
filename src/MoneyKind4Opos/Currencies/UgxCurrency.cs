using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Uganda Shilling (UGX).</summary>
public sealed class UgxCurrency : ICurrency, ICashCountFormattable<UgxCurrency>, ICurrencyFormattable<UgxCurrency>
{
    private UgxCurrency() { }

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.UGX;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 1m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("USh", "$n", decimalDigits: 0);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits => [];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new CashFaceInfo(1m, CashType.Coin, "1 Shilling Coin", "1 Shilling coin"),
        new CashFaceInfo(2m, CashType.Coin, "2 Shilling Coin", "2 Shilling coin"),
        new CashFaceInfo(5m, CashType.Coin, "5 Shilling Coin", "5 Shilling coin"),
        new CashFaceInfo(10m, CashType.Coin, "10 Shilling Coin", "10 Shilling coin"),
        new CashFaceInfo(50m, CashType.Coin, "50 Shilling Coin", "50 Shilling coin"),
        new CashFaceInfo(100m, CashType.Coin, "100 Shilling Coin", "100 Shilling coin"),
        new CashFaceInfo(200m, CashType.Coin, "200 Shilling Coin", "200 Shilling coin"),
        new CashFaceInfo(500m, CashType.Coin, "500 Shilling Coin", "500 Shilling coin"),
        new CashFaceInfo(1000m, CashType.Coin, "1000 Shilling Coin", "1000 Shilling coin")
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new CashFaceInfo(1000m, CashType.Bill, "1000 Shilling Bill", "1000 Shilling note"),
        new CashFaceInfo(2000m, CashType.Bill, "2000 Shilling Bill", "2000 Shilling note"),
        new CashFaceInfo(5000m, CashType.Bill, "5000 Shilling Bill", "5000 Shilling note"),
        new CashFaceInfo(10000m, CashType.Bill, "10000 Shilling Bill", "10000 Shilling note"),
        new CashFaceInfo(20000m, CashType.Bill, "20000 Shilling Bill", "20000 Shilling note"),
        new CashFaceInfo(50000m, CashType.Bill, "50000 Shilling Bill", "50000 Shilling note")
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
