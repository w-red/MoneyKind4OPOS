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
    public static decimal MinimumUnit => 0.001m;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Dirham", null, 0.100m),
        new SubsidiaryUnit("Piastre", null, 0.010m),
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
        new(0.001m, CashType.Coin, "1 Fils Coin", "1f"),
        new(0.005m, CashType.Coin, "5 Fils Coin", "5f"),
        new(0.01m, CashType.Coin, "1 Piastre Coin", "1p"),
        new(0.05m, CashType.Coin, "5 Piastres Coin", "5p"),
        new(0.1m, CashType.Coin, "10 Piastres Coin", "10p"),
        new(0.25m, CashType.Coin, "1/4 JD Coin", "1/4 JD"),
        new(0.5m, CashType.Coin, "1/2 JD Coin", "1/2 JD"),
    ];
    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1.0m, CashType.Bill, "1 JD Bill", "1 JD"),
        new(5.0m, CashType.Bill, "5 JD Bill", "5 JD"),
        new(10.0m, CashType.Bill, "10 JD Bill", "10 JD"),
        new(20.0m, CashType.Bill, "20 JD Bill", "20 JD"),
        new(50.0m, CashType.Bill, "50 JD Bill", "50 JD"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
