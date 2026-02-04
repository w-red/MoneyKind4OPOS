using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Belarusian Ruble Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Banknotes and Coins</term><description><seealso href="https://president.gov.by/en/belarus/economics/banking-system/national-currency">National Currency - President of the Republic of Belarus</seealso></description></item>
/// </list>
/// </remarks>
public class KztCurrency :
    ICurrency,
    ICashCountFormattable<KztCurrency>,
    ICurrencyFormattable<KztCurrency>
{
    private static readonly NumberFormatInfo _nfi = new()
    {
        CurrencySymbol = "₸",
        CurrencyPositivePattern = 1, // n $
        CurrencyGroupSeparator = ",",
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 0,
    };

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.KZT;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 1m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } = new(
        Symbol: "₸",
        NumberFormat: new NumberFormatInfo
        {
            CurrencySymbol = "₸",
            CurrencyPositivePattern = 1, // n ₸
            CurrencyGroupSeparator = ",",
            CurrencyDecimalSeparator = ".",
            CurrencyDecimalDigits = 2
        },
        DisplayFormat: new(SymbolPlacement.Postfix)
    );

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } = new(
        Symbol: "₸",
        NumberFormat: _nfi,
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
        [];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(1m, CashType.Coin, "1 ₸ Coin", "1 ₸"),
        new(2m, CashType.Coin, "2 ₸ Coin", "2 ₸"),
        new(5m, CashType.Coin, "5 ₸ Coin", "5 ₸"),
        new(10m, CashType.Coin, "10 ₸ Coin", "10 ₸"),
        new(20m, CashType.Coin, "20 ₸ Coin", "20 ₸"),
        new(50m, CashType.Coin, "50 ₸ Coin", "50 ₸"),
        new(100m, CashType.Coin, "100 ₸ Coin", "100 ₸"),
        new(200m, CashType.Coin, "200 ₸ Coin", "200 ₸"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(200m, CashType.Bill, "200 ₸ Bill", "200 ₸"),
        new(500m, CashType.Bill, "500 ₸ Bill", "500 ₸"),
        new(1000m, CashType.Bill, "1000 ₸ Bill", "1000 ₸"),
        new(2000m, CashType.Bill, "2000 ₸ Bill", "2000 ₸"),
        new(5000m, CashType.Bill, "5000 ₸ Bill", "5000 ₸"),
        new(10000m, CashType.Bill, "10000 ₸ Bill", "10000 ₸"),
        new(20000m, CashType.Bill, "20000 ₸ Bill", "20000 ₸"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
