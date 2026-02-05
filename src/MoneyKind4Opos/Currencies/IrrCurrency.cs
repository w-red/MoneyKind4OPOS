using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Iranian Rial Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description>Banknotes and Coins (Central Bank of the Islamic Republic of Iran)</description></item>
/// </list>
/// </remarks>
public class IrrCurrency :
    ICurrency,
    ICashCountFormattable<IrrCurrency>,
    ICurrencyFormattable<IrrCurrency>
{
    private static readonly NumberFormatInfo _nfi = new()
    {
        CurrencySymbol = "﷼",
        CurrencyPositivePattern = 0, // $n
        CurrencyGroupSeparator = ",",
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 0,
    };

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.IRR;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 1000m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } = new(
        Symbol: "IRR",
        NumberFormat: new NumberFormatInfo
        {
            CurrencySymbol = "IRR",
            CurrencyGroupSeparator = ",",
            CurrencyDecimalSeparator = ".",
            CurrencyDecimalDigits = 0
        },
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } = new(
        Symbol: "﷼",
        NumberFormat: _nfi,
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Dinar", "d", 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(1000m, CashType.Coin, "1,000 Rials Coin", "1,000 ﷼"),
        new(2000m, CashType.Coin, "2,000 Rials Coin", "2,000 ﷼"),
        new(5000m, CashType.Coin, "5,000 Rials Coin", "5,000 ﷼"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(10000m, CashType.Bill, "10,000 Rials Bill", "10,000 ﷼"),
        new(20000m, CashType.Bill, "20,000 Rials Bill", "20,000 ﷼"),
        new(50000m, CashType.Bill, "50,000 Rials Bill", "50,000 ﷼"),
        new(100000m, CashType.Bill, "100,000 Rials Bill", "100,000 ﷼"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
