using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Ghanaian Cedi Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.bog.gov.gh/currency/">Bank of Ghana</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://www.bog.gov.gh/currency/">Bank of Ghana</seealso></description></item>
/// </list>
/// </remarks>
public class GhsCurrency :
    ICurrency,
    ICashCountFormattable<GhsCurrency>,
    ICurrencyFormattable<GhsCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.GHS;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("GH\u20B5", "$n", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Pesewa", "p", 0.01m)
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "1 Pesewa", "1p"),
        new(0.05m, CashType.Coin, "5 Pesewas", "5p"),
        new(0.10m, CashType.Coin, "10 Pesewas", "10p"),
        new(0.20m, CashType.Coin, "20 Pesewas", "20p"),
        new(0.50m, CashType.Coin, "50 Pesewas", "50p"),
        new(1m, CashType.Coin, "1 Cedi", "GH\u20B51"),
        new(2m, CashType.Coin, "2 Cedis", "GH\u20B52"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1m, CashType.Bill, "1 Cedi", "GH\u20B51"),
        new(2m, CashType.Bill, "2 Cedis", "GH\u20B52"),
        new(5m, CashType.Bill, "5 Cedis", "GH\u20B55"),
        new(10m, CashType.Bill, "10 Cedis", "GH\u20B510"),
        new(20m, CashType.Bill, "20 Cedis", "GH\u20B520"),
        new(50m, CashType.Bill, "50 Cedis", "GH\u20B550"),
        new(100m, CashType.Bill, "100 Cedis", "GH\u20B5100"),
        new(200m, CashType.Bill, "200 Cedis", "GH\u20B5200"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => true;
}
