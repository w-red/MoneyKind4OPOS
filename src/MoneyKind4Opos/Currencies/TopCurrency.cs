using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Tonga Pa'anga Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.reservebank.to/currency/">National Reserve Bank of Tonga</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://www.reservebank.to/currency/">NRBT</seealso></description></item>
/// </list>
/// </remarks>
public class TopCurrency :
    ICurrency,
    ICashCountFormattable<TopCurrency>,
    ICurrencyFormattable<TopCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.TOP;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("T$", "$n", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local =>
        CultureInfo.CurrentCulture.Name == "to-TO"
            ? CurrencyFormattingOptions.Create("T$", "$ n", decimalDigits: 2)
            : Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Seniti", "s", 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "1 Seniti", "1s"),
        new(0.05m, CashType.Coin, "5 Seniti", "5s"),
        new(0.10m, CashType.Coin, "10 Seniti", "10s"),
        new(0.20m, CashType.Coin, "20 Seniti", "20s"),
        new(0.50m, CashType.Coin, "50 Seniti", "50s"),
        new(1.00m, CashType.Coin, "1 Pa'anga", "1T$"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(2m, CashType.Bill, "2 Pa'anga", "2T$"),
        new(5m, CashType.Bill, "5 Pa'anga", "5T$"),
        new(10m, CashType.Bill, "10 Pa'anga", "10T$"),
        new(20m, CashType.Bill, "20 Pa'anga", "20T$"),
        new(50m, CashType.Bill, "50 Pa'anga", "50T$"),
        new(100m, CashType.Bill, "100 Pa'anga", "100T$"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
