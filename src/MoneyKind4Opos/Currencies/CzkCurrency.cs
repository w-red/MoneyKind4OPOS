using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Czech Koruna Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.cnb.cz/en/banknotes-and-coins/banknotes/">CNB - Czech Banknotes</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://www.cnb.cz/en/banknotes-and-coins/coins/">CNB - Czech Coins</seealso></description></item>
/// </list>
/// </remarks>
public class CzkCurrency :
    ICurrency,
    ICashCountFormattable<CzkCurrency>,
    ICurrencyFormattable<CzkCurrency>
{
    private static readonly NumberFormatInfo _nfi = new()
    {
        CurrencySymbol = "Kč",
        CurrencyGroupSeparator = ",",
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 2,
    };

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.CZK;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 10m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } = new(
        Symbol: "Kč",
        NumberFormat: new NumberFormatInfo 
        { 
            CurrencySymbol = "Kč", 
            CurrencyGroupSeparator = ",", 
            CurrencyDecimalSeparator = ".", 
            CurrencyDecimalDigits = 0
        },
        DisplayFormat: new(SymbolPlacement.Postfix)
    );

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } = new(
        Symbol: "Kč",
        NumberFormat: _nfi,
        DisplayFormat: new(SymbolPlacement.Postfix)
    );

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
        [
            // new SubsidiaryUnit(Name: "Haléř", Symbol: "h", Ratio: 0.01m),
        ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(1m, CashType.Coin, "1 Kč Coin", "1 Kč"),
        new(2m, CashType.Coin, "2 Kč Coin", "2 Kč"),
        new(5m, CashType.Coin, "5 Kč Coin", "5 Kč"),
        new(10m, CashType.Coin, "10 Kč Coin", "10 Kč"),
        new(20m, CashType.Coin, "20 Kč Coin", "20 Kč"),
        new(50m, CashType.Coin, "50 Kč Coin", "50 Kč"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(100m, CashType.Bill, "100 Kč Bill", "100 Kč"),
        new(200m, CashType.Bill, "200 Kč Bill", "200 Kč"),
        new(500m, CashType.Bill, "500 Kč Bill", "500 Kč"),
        new(1000m, CashType.Bill, "1000 Kč Bill", "1000 Kč"),
        new(2000m, CashType.Bill, "2000 Kč Bill", "2000 Kč"),
        new(5000m, CashType.Bill, "5000 Kč Bill", "5000 Kč"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
