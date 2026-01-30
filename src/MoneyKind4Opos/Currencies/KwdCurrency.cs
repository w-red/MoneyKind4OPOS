using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;
using System.Text;

namespace MoneyKind4Opos.Currencies;

/// <summary>Kuwaiti Dinar Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bill</term><description><seealso href="https://www.cbk.gov.kw/en/banknotes-and-coins/banknotes/sixth-issue">CBK - banknotes/ Sixth Issue</seealso></description></item>
/// <item><term>Coin</term><description><seealso href="https://www.cbk.gov.kw/en/banknotes-and-coins/coins">CBK - Coins</seealso></description></item>
/// </list>
/// </remarks>
public class KwdCurrency :
    ICurrency,
    ICashCountFormattable<KwdCurrency>,
    ICurrencyFormattable<KwdCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.KWD;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.001m;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Fils", null, 0.001m),
    ];

    private static readonly NumberFormatInfo _nfi = new()
    {
        CurrencySymbol = "Dinars",
        CurrencyPositivePattern = 3, // n $
        CurrencyGroupSeparator = ",",
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 3,
    };

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        new(
            Symbol: "Dinars",
            NumberFormat: _nfi,
            DisplayFormat: new(SymbolPlacement.Postfix)
        );

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.001m, CashType.Coin, "1 fils Coin", "1f"),
        new(0.005m, CashType.Coin, "5 fils Coin", "5f"),
        new(0.01m, CashType.Coin, "10 fils Coin", "10f"),
        new(0.02m, CashType.Coin, "20 fils Coin", "20f"),
        new(0.05m, CashType.Coin, "50 fils Coin", "50f"),
        new(0.1m, CashType.Coin, "100 fils Coin", "100f"),
    ];
    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(0.25m, CashType.Bill, "1/4 Dinars Bill", "1/4 Dinars"),
        new(0.5m, CashType.Bill, "1/2 Dinars Bill", "1/2 Dinars"),
        new(1.0m, CashType.Bill, "1 Dinars Bill", "1 Dinars"),
        new(5.0m, CashType.Bill, "5 Dinars Bill", "5 Dinars"),
        new(10.0m, CashType.Bill, "10 Dinars Bill", "10 Dinars"),
        new(20.0m, CashType.Bill, "20 Dinars Bill", "20 Dinars"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
