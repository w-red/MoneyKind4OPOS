using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Japanese Yen Currency</summary>
/// <seealso href="https://www.boj.or.jp/en/note_tfjgs/note/index.htm">Banknotes and Coins (Bank of Japan)</seealso>
public class JpyCurrency : ICurrency, ICashCountFormattable<JpyCurrency>, ICurrencyFormattable<JpyCurrency>
{
    private static readonly NumberFormatInfo _globalNfi = new()
    {
        CurrencySymbol = "¥",
        CurrencyPositivePattern = 0, // $n
        CurrencyGroupSeparator = ",",
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 0,
    };

    private static readonly NumberFormatInfo _localNfi = new()
    {
        CurrencySymbol = "円",
        CurrencyPositivePattern = 1, // n$
        CurrencyGroupSeparator = ",",
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 0,
    };

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.JPY;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 1m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } = new(
        Symbol: "¥",
        NumberFormat: _globalNfi,
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } = new(
        Symbol: "円",
        NumberFormat: _localNfi,
        DisplayFormat: new(SymbolPlacement.Postfix)
    );

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits => [];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(1m, CashType.Coin, "1 Yen Coin", "一円玉"),
        new(5m, CashType.Coin, "5 Yen Coin", "五円玉"),
        new(10m, CashType.Coin, "10 Yen Coin", "十円玉"),
        new(50m, CashType.Coin, "50 Yen Coin", "五十円玉"),
        new(100m, CashType.Coin, "100 Yen Coin", "百円玉"),
        new(500m, CashType.Coin, "500 Yen Coin", "五百円玉"),
    ];
    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1000m, CashType.Bill, "1000 Yen Bill", "千円札"),
        new(2000m, CashType.Bill, "2000 Yen Bill", "二千円札"),
        new(5000m, CashType.Bill, "5000 Yen Bill", "五千円札"),
        new(10000m, CashType.Bill, "10000 Yen Bill", "一万円札"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
