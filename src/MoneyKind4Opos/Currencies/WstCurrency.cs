using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Samoa Tala Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.cbs.gov.ws/currency/">Central Bank of Samoa</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://www.cbs.gov.ws/currency/">CBS</seealso></description></item>
/// </list>
/// </remarks>
public class WstCurrency :
    ICurrency,
    ICashCountFormattable<WstCurrency>,
    ICurrencyFormattable<WstCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.WST;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.10m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("WS$", "$n", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Sene", "s", 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.10m, CashType.Coin, "10 Sene", "10s"),
        new(0.20m, CashType.Coin, "20 Sene", "20s"),
        new(0.50m, CashType.Coin, "50 Sene", "50s"),
        new(1.00m, CashType.Coin, "1 Tala", "1T"),
        new(2.00m, CashType.Coin, "2 Tala", "2T"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(5m, CashType.Bill, "5 Tala", "5T"),
        new(10m, CashType.Bill, "10 Tala", "10T"),
        new(20m, CashType.Bill, "20 Tala", "20T"),
        new(50m, CashType.Bill, "50 Tala", "50T"),
        new(100m, CashType.Bill, "100 Tala", "100T"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
