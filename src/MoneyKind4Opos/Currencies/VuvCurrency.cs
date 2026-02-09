using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Vanuatu Vatu Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.rbv.gov.vu/index.php/en/currency">Reserve Bank of Vanuatu</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://www.rbv.gov.vu/index.php/en/currency">RBV</seealso></description></item>
/// </list>
/// </remarks>
public class VuvCurrency :
    ICurrency,
    ICashCountFormattable<VuvCurrency>,
    ICurrencyFormattable<VuvCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.VUV;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 5.0m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("VT", "$n", decimalDigits: 0);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local =>
        CultureInfo.CurrentCulture.Name == "fr-VU"
            ? CurrencyFormattingOptions.Create("VT", "n $", decimalDigits: 0, groupSep: "\u202F", decimalSep: ",")
            : Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits => []; // No subsidiary

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(5m, CashType.Coin, "5 Vatu", "5VT"),
        new(10m, CashType.Coin, "10 Vatu", "10VT"),
        new(20m, CashType.Coin, "20 Vatu", "20VT"),
        new(50m, CashType.Coin, "50 Vatu", "50VT"),
        new(100m, CashType.Coin, "100 Vatu", "100VT"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(200m, CashType.Bill, "200 Vatu", "200VT"),
        new(500m, CashType.Bill, "500 Vatu", "500VT"),
        new(1000m, CashType.Bill, "1000 Vatu", "1000VT"),
        new(2000m, CashType.Bill, "2000 Vatu", "2000VT"),
        new(5000m, CashType.Bill, "5000 Vatu", "5000VT"),
        new(10000m, CashType.Bill, "10000 Vatu", "10000VT"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
