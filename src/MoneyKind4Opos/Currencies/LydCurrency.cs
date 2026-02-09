using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Libyan Dinar Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://cbl.gov.ly/en/category/banknotes/">Central Bank of Libya</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://cbl.gov.ly/en/category/coins/">Central Bank of Libya</seealso></description></item>
/// </list>
/// </remarks>
public class LydCurrency :
    ICurrency,
    ICashCountFormattable<LydCurrency>,
    ICurrencyFormattable<LydCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.LYD;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.050m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("LD", "n $", decimalDigits: 3);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Dirham", "dirham", 0.001m)
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.050m, CashType.Coin, "50 Dirhams", "50dirhams"),
        new(0.100m, CashType.Coin, "100 Dirhams", "100dirhams"),
        new(0.250m, CashType.Coin, "1/4 Dinar", "1/4LD"),
        new(0.500m, CashType.Coin, "1/2 Dinar", "1/2LD"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1m, CashType.Bill, "1 Dinar", "1LD"),
        new(5m, CashType.Bill, "5 Dinars", "5LD"),
        new(10m, CashType.Bill, "10 Dinars", "10LD"),
        new(20m, CashType.Bill, "20 Dinars", "20LD"),
        new(50m, CashType.Bill, "50 Dinars", "50LD"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => true;
}
