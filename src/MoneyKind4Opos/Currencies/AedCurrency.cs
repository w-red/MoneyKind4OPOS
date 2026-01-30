using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>United Arab Emirates Dirham Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bill and Coin</term><description><seealso href="https://www.centralbank.ae/en/our-operations/currency-and-coins/circulated-currency/">CBUAE - Circulated Currency</seealso></description></item>
/// </list>
/// </remarks>
public class AedCurrency :
    ICurrency,
    ICashCountFormattable<AedCurrency>,
    ICurrencyFormattable<AedCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.AED;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.25m;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Fils", null, 0.01m),
    ];

    private static readonly NumberFormatInfo _nfi = new()
    {
        CurrencySymbol = "Dirham",
        CurrencyPositivePattern = 3, // n $
        CurrencyGroupSeparator = ",",
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 3,
    };

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        new(
            Symbol: "Dirham",
            NumberFormat: _nfi,
            DisplayFormat: new(SymbolPlacement.Postfix)
        );

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.25m, CashType.Coin, "25 Fils Coin", "25f"),
        new(0.5m, CashType.Coin, "50 Fils Coin", "50f"),
        new(1.0m, CashType.Coin, "1 Dirham Coin", "100f"),
    ];
    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(5.0m, CashType.Bill, "5 Dirham Bill", "5 Dirham"),
        new(10.0m, CashType.Bill, "10 Dirham Bill", "10 Dirham"),
        new(20.0m, CashType.Bill, "20 Dirham Bill", "20 Dirham"),
        new(50.0m, CashType.Bill, "50 Dirham Bill", "50 Dirham"),
        new(100.0m, CashType.Bill, "100 Dirham Bill", "100 Dirham"),
        new(200.0m, CashType.Bill, "200 Dirham Bill", "200 Dirham"),
        new(500.0m, CashType.Bill, "500 Dirham Bill", "500 Dirham"),
        new(1000.0m, CashType.Bill, "1000 Dirham Bill", "1000 Dirham"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
