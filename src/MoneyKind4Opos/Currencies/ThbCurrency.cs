using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Thai Baht Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Banknotes</term><description><seealso href="https://www.bot.or.th/en/our-roles/banknotes/History-and-Series-of-Banknote-And-Commemorative/current-series-of-banknotes.html">Current Banknotes - BOT</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://www.royalthaimint.net/ewtadmin/ewt/mint_en/mobile_detail.php?cid=21&nid=302">Current Coins - Royal Thai Mint</seealso></description></item>
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
        CurrencyGroupSeparator = ",",
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 2,
        CurrencyPositivePattern = 0, // $n
    };

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.THB;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.25m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } = new(
        Symbol: "฿",
        NumberFormat: _nfi,
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
        [
            new SubsidiaryUnit(Name: "Satang", Symbol: "s", Ratio: 0.01m),
        ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.25m, CashType.Coin, "25 Satang Coin", "25s"),
        new(0.50m, CashType.Coin, "50 Satang Coin", "50s"),
        new(1m, CashType.Coin, "1 Baht Coin", "1฿"),
        new(2m, CashType.Coin, "2 Baht Coin", "2฿"),
        new(5m, CashType.Coin, "5 Baht Coin", "5฿"),
        new(10m, CashType.Coin, "10 Baht Coin", "10฿"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(20m, CashType.Bill, "20 Baht Bill", "20฿"),
        new(50m, CashType.Bill, "50 Baht Bill", "50฿"),
        new(100m, CashType.Bill, "100 Baht Bill", "100฿"),
        new(500m, CashType.Bill, "500 Baht Bill", "500฿"),
        new(1000m, CashType.Bill, "1000 Baht Bill", "1000฿"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
