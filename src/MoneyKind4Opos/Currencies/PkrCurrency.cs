using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Pakistan Rupee Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://www.sbp.org.pk/finance/Pak.asp">Banknotes (State Bank of Pakistan)</seealso></description></item>
/// </list>
/// </remarks>
public class PkrCurrency :
    ICurrency,
    ICashCountFormattable<PkrCurrency>,
    ICurrencyFormattable<PkrCurrency>
{
    private static readonly NumberFormatInfo _nfi = new()
    {
        CurrencySymbol = "Rs.",
        CurrencyPositivePattern = 0, // $n
        CurrencyGroupSeparator = ",",
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 2,
    };

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.PKR;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 1m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } = new(
        Symbol: "PKR",
        NumberFormat: new NumberFormatInfo
        {
            CurrencySymbol = "PKR",
            CurrencyPositivePattern = 0,
            CurrencyGroupSeparator = ",",
            CurrencyDecimalSeparator = ".",
            CurrencyDecimalDigits = 2
        },
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } = new(
        Symbol: "Rs.",
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
        new(1m, CashType.Coin, "1 Rupee Coin", "1 Rs."),
        new(2m, CashType.Coin, "2 Rupees Coin", "2 Rs."),
        new(5m, CashType.Coin, "5 Rupees Coin", "5 Rs."),
        new(10m, CashType.Coin, "10 Rupees Coin", "10 Rs."),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(10m, CashType.Bill, "10 Rupees Bill", "10 Rs."),
        new(20m, CashType.Bill, "20 Rupees Bill", "20 Rs."),
        new(50m, CashType.Bill, "50 Rupees Bill", "50 Rs."),
        new(75m, CashType.Bill, "75 Rupees Bill", "75 Rs."),
        new(100m, CashType.Bill, "100 Rupees Bill", "100 Rs."),
        new(500m, CashType.Bill, "500 Rupees Bill", "500 Rs."),
        new(1000m, CashType.Bill, "1000 Rupees Bill", "1000 Rs."),
        new(5000m, CashType.Bill, "5000 Rupees Bill", "5000 Rs."),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
