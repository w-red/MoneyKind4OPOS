using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Jordanian Dinar Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bill and Coin</term><description><seealso href="https://www.cbj.gov.jo/EN/List/Issuance_of_Banknotes">CBJ - Issuance of Banknotes</seealso></description></item>
/// </list>
/// </remarks>
public class JodCurrency :
    ICurrency,
    ICashCountFormattable<JodCurrency>,
    ICurrencyFormattable<JodCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.JOD;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.010m;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Piastres", null, 0.010m),
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
        new(0.01m, CashType.Coin, "1 Piastres Coin", "1p"),
        new(0.05m, CashType.Coin, "5 Piastres Coin", "5p"),
        new(0.1m, CashType.Coin, "10 Piastres Coin", "10p"),
        new(0.25m, CashType.Coin, "1/4 Dinars Coin", "1/4 Dinars"),
        new(0.5m, CashType.Coin, "1/2 Dinars Coin", "1/2 Dinars"),
    ];
    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1.0m, CashType.Bill, "1 Dinars Bill", "1 Dinars"),
        new(5.0m, CashType.Bill, "5 Dinars Bill", "5 Dinars"),
        new(10.0m, CashType.Bill, "10 Dinars Bill", "10 Dinars"),
        new(25.0m, CashType.Bill, "25 Dinars Bill", "25 Dinars"),
        new(50.0m, CashType.Bill, "50 Dinars Bill", "50 Dinars"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
