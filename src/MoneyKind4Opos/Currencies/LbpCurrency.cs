using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Lebanese Pound Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description>Banknotes and Coins (Banque du Liban)</description></item>
/// </list>
/// </remarks>
public class LbpCurrency :
    ICurrency,
    ICashCountFormattable<LbpCurrency>,
    ICurrencyFormattable<LbpCurrency>
{
    private static readonly NumberFormatInfo _nfi = new()
    {
        CurrencySymbol = "LL",
        CurrencyPositivePattern = 2, // $ n
        CurrencyGroupSeparator = ",",
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 0,
    };

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.LBP;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 250.0m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } = new(
        Symbol: "LBP",
        NumberFormat: new NumberFormatInfo
        {
            CurrencySymbol = "LBP",
            CurrencyGroupSeparator = ",",
            CurrencyDecimalSeparator = ".",
            CurrencyDecimalDigits = 0
        },
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } = new(
        Symbol: "LL",
        NumberFormat: _nfi,
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Piastre", null, 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(250m, CashType.Coin, "250 Pound Coin", "250 LL"),
        new(500m, CashType.Coin, "500 Pound Coin", "500 LL"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1000m, CashType.Bill, "1000 Pound Bill", "1000 LL"),
        new(5000m, CashType.Bill, "5000 Pound Bill", "5000 LL"),
        new(10000m, CashType.Bill, "10000 Pound Bill", "10000 LL"),
        new(20000m, CashType.Bill, "20000 Pound Bill", "20000 LL"),
        new(50000m, CashType.Bill, "50000 Pound Bill", "50000 LL"),
        new(100000m, CashType.Bill, "100000 Pound Bill", "100000 LL"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
