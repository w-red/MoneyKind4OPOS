using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Bahraini Dinar Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bill</term><description><seealso href="https://www.cbb.gov.bh/currency-issue/">CBB - Currency Issue</seealso></description></item>
/// <item><term>Coin</term><description><seealso href="https://www.cbb.gov.bh/current-coins/">Current Coins</seealso></description></item>
/// </list>
/// </remarks>
public class BhdCurrency :
    ICurrency,
    ICashCountFormattable<BhdCurrency>,
    ICurrencyFormattable<BhdCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.BHD;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.005m;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Fils", null, 0.001m),
    ];

    private static readonly NumberFormatInfo _nfi = new()
    {
        CurrencySymbol = "BD",
        CurrencyPositivePattern = 2, // $ n
        CurrencyGroupSeparator = ",",
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 3,
    };

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        new(
            Symbol: "BD",
            NumberFormat: _nfi,
            DisplayFormat: new(SymbolPlacement.Prefix)
        );

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.005m, CashType.Coin, "5 fils Coin", "5f"),
        new(0.01m, CashType.Coin, "10 fils Coin", "10f"),
        new(0.025m, CashType.Coin, "25 fils Coin", "25f"),
        new(0.05m, CashType.Coin, "50 fils Coin", "50f"),
        new(0.1m, CashType.Coin, "100 fils Coin", "100f"),
        new(0.5m, CashType.Coin, "500 fils Coin", "500f"),
    ];
    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(0.5m, CashType.Bill, "BD 1/2", "BD 1/2"),
        new(1.0m, CashType.Bill, "BD 1", "BD 1"),
        new(5.0m, CashType.Bill, "BD 5", "BD 5"),
        new(10.0m, CashType.Bill, "BD 10", "BD 10"),
        new(25.0m, CashType.Bill, "BD 25", "BD 25"),
        new(50.0m, CashType.Bill, "BD 50", "BD 50"),
        new(100.0m, CashType.Bill, "BD 100", "BD 100"),
        new(500.0m, CashType.Bill, "BD 500", "BD 500"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
