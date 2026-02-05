using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Thai Baht Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.bot.or.th/en/our-roles/banknotes/History-and-Series-of-Banknote-And-Commemorative/current-series-of-banknotes.html">Banknotes (Bank of Thailand)</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://www.royalthaimint.net/ewtadmin/ewt/mint_en/mobile_detail.php?cid=21&nid=302">Coins (Royal Thai Mint)</seealso></description></item>
/// </list>
/// </remarks>
public class ThbCurrency :
    ICurrency,
    ICashCountFormattable<ThbCurrency>,
    ICurrencyFormattable<ThbCurrency>
{
    private static readonly NumberFormatInfo _nfi = new()
    {
        CurrencySymbol = "฿",
        CurrencyPositivePattern = 0, // $n
        CurrencyGroupSeparator = ",",
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 2,
    };

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.THB;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.25m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } = new(
        Symbol: "THB",
        NumberFormat: new NumberFormatInfo
        {
            CurrencySymbol = "THB",
            CurrencyPositivePattern = 0,
            CurrencyGroupSeparator = ",",
            CurrencyDecimalSeparator = ".",
            CurrencyDecimalDigits = 2
        },
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } = new(
        Symbol: "฿",
        NumberFormat: _nfi,
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Satang", "s", 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.25m, CashType.Coin, "25 Satang Coin", "25 สตางค์"),
        new(0.50m, CashType.Coin, "50 Satang Coin", "50 สตางค์"),
        new(1m, CashType.Coin, "1 Baht Coin", "1 บาท"),
        new(2m, CashType.Coin, "2 Bahts Coin", "2 บาท"),
        new(5m, CashType.Coin, "5 Bahts Coin", "5 บาท"),
        new(10m, CashType.Coin, "10 Bahts Coin", "10 บาท"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(20m, CashType.Bill, "20 Bahts Bill", "20 บาท"),
        new(50m, CashType.Bill, "50 Bahts Bill", "50 บาท"),
        new(100m, CashType.Bill, "100 Bahts Bill", "100 บาท"),
        new(500m, CashType.Bill, "500 Bahts Bill", "500 บาท"),
        new(1000m, CashType.Bill, "1000 Bahts Bill", "1000 บาท"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
