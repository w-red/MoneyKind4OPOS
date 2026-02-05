using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Nepalese Rupee Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://www.nrb.org.np/banknotes-security-features/">Banknotes (Nepal Rastra Bank)</seealso></description></item>
/// </list>
/// </remarks>
public class NprCurrency :
    ICurrency,
    ICashCountFormattable<NprCurrency>,
    ICurrencyFormattable<NprCurrency>
{
    private static readonly NumberFormatInfo _nfi = new()
    {
        CurrencySymbol = "Rs",
        CurrencyPositivePattern = 0, // $n
        CurrencyGroupSeparator = ",",
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 2,
    };

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.NPR;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 1m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } = new(
        Symbol: "NPR",
        NumberFormat: new NumberFormatInfo
        {
            CurrencySymbol = "NPR",
            CurrencyPositivePattern = 0,
            CurrencyGroupSeparator = ",",
            CurrencyDecimalSeparator = ".",
            CurrencyDecimalDigits = 2
        },
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } = new(
        Symbol: "Rs",
        NumberFormat: _nfi,
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Paisa", "p", 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(1m, CashType.Coin, "1 Rupee Coin", "Rs 1"),
        new(2m, CashType.Coin, "2 Rupees Coin", "Rs 2"),
        new(5m, CashType.Coin, "5 Rupees Coin", "Rs 5"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1m, CashType.Bill, "1 Rupee Bill", "Rs 1"),
        new(2m, CashType.Bill, "2 Rupees Bill", "Rs 2"),
        new(5m, CashType.Bill, "5 Rupees Bill", "Rs 5"),
        new(10m, CashType.Bill, "10 Rupees Bill", "Rs 10"),
        new(20m, CashType.Bill, "20 Rupees Bill", "Rs 20"),
        new(50m, CashType.Bill, "50 Rupees Bill", "Rs 50"),
        new(100m, CashType.Bill, "100 Rupees Bill", "Rs 100"),
        new(500m, CashType.Bill, "500 Rupees Bill", "Rs 500"),
        new(1000m, CashType.Bill, "1000 Rupees Bill", "Rs 1000"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
