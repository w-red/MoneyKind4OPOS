using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Kyrgyzstan Som Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://www.nbkr.kg">Banknotes and Coins (National Bank of the Kyrgyz Republic)</seealso></description></item>
/// </list>
/// </remarks>
public class KgsCurrency :
    ICurrency,
    ICashCountFormattable<KgsCurrency>,
    ICurrencyFormattable<KgsCurrency>
{
    private static readonly NumberFormatInfo _nfi = new()
    {
        CurrencySymbol = "с",
        CurrencyPositivePattern = 3, // n $
        CurrencyGroupSeparator = ",",
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 2,
    };

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.KGS;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 1m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } = new(
        Symbol: "KGS",
        NumberFormat: new NumberFormatInfo
        {
            CurrencySymbol = "KGS",
            CurrencyPositivePattern = 3,
            CurrencyGroupSeparator = ",",
            CurrencyDecimalSeparator = ".",
            CurrencyDecimalDigits = 2
        },
        DisplayFormat: new(SymbolPlacement.Postfix)
    );

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } = new(
        Symbol: "с",
        NumberFormat: _nfi,
        DisplayFormat: new(SymbolPlacement.Postfix)
    );

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Tyiyn", "ty", 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(1m, CashType.Coin, "1 Som Coin", "1 с"),
        new(3m, CashType.Coin, "3 Soms Coin", "3 с"),
        new(5m, CashType.Coin, "5 Soms Coin", "5 с"),
        new(10m, CashType.Coin, "10 Soms Coin", "10 с"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(20m, CashType.Bill, "20 Soms Bill", "20 с"),
        new(50m, CashType.Bill, "50 Soms Bill", "50 с"),
        new(100m, CashType.Bill, "100 Soms Bill", "100 с"),
        new(200m, CashType.Bill, "200 Soms Bill", "200 с"),
        new(500m, CashType.Bill, "500 Soms Bill", "500 с"),
        new(1000m, CashType.Bill, "1000 Soms Bill", "1000 с"),
        new(5000m, CashType.Bill, "5000 Soms Bill", "5000 с"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
