using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Saudi Riyal Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Currency</term><description><seealso href="https://www.sama.gov.sa/en-US/Currency/pages/sixthissue.aspx">SAMA - Sixth Issue</seealso></description></item>
/// </list>
/// </remarks>
public class KydCurrency :
    ICurrency,
    ICashCountFormattable<KydCurrency>,
    ICurrencyFormattable<KydCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.KYD;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Cent", "¢", 0.01m),
    ];

    private static readonly NumberFormatInfo _nfi = new()
    {
        CurrencySymbol = "$",
        CurrencyPositivePattern = 1, // $ n
        CurrencyGroupSeparator = ",",
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 2,
    };

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        new(
            Symbol: "$",
            NumberFormat: _nfi,
            DisplayFormat: new(SymbolPlacement.Prefix)
        );

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "1 Cent Coin", "1¢"),
        new(0.05m, CashType.Coin, "5 Cent Coin", "5¢"),
        new(0.10m, CashType.Coin, "10 Cent Coin", "10¢"),
        new(0.25m, CashType.Coin, "25 Cent Coin", "25¢"),
    ];
    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1.0m, CashType.Bill, "1 Dollar Bill", "$ 1"),
        new(5.0m, CashType.Bill, "5 Dollar Bill", "$ 5"),
        new(10.0m, CashType.Bill, "10 Dollar Bill", "$ 10"),
        new(25.0m, CashType.Bill, "25 Dollar Bill", "$ 25"),
        new(50.0m, CashType.Bill, "50 Dollar Bill", "$ 50"),
        new(100.0m, CashType.Bill, "100 Dollar Bill", "$ 100"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
