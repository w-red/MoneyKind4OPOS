using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Lao Kip Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.bol.gov.la/en/newsAll?&start=45">Banknotes (Bank of the Lao PDR)</seealso></description></item>
/// </list>
/// </remarks>
public class LakCurrency :
    ICurrency,
    ICashCountFormattable<LakCurrency>,
    ICurrencyFormattable<LakCurrency>
{
    private static readonly NumberFormatInfo _nfi = new()
    {
        CurrencySymbol = "₭",
        CurrencyPositivePattern = 0, // $n
        CurrencyGroupSeparator = ",",
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 0,
    };

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.LAK;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 500m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } = new(
        Symbol: "LAK",
        NumberFormat: new NumberFormatInfo
        {
            CurrencySymbol = "LAK",
            CurrencyPositivePattern = 0,
            CurrencyGroupSeparator = ",",
            CurrencyDecimalSeparator = ".",
            CurrencyDecimalDigits = 0
        },
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } = new(
        Symbol: "₭",
        NumberFormat: _nfi,
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Att", null, 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins => [];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(500m, CashType.Bill, "500 Kip Bill", "500 ₭"),
        new(1000m, CashType.Bill, "1,000 Kip Bill", "1,000 ₭"),
        new(2000m, CashType.Bill, "2,000 Kip Bill", "2,000 ₭"),
        new(5000m, CashType.Bill, "5,000 Kip Bill", "5,000 ₭"),
        new(10000m, CashType.Bill, "10,000 Kip Bill", "10,000 ₭"),
        new(20000m, CashType.Bill, "20,000 Kip Bill", "20,000 ₭"),
        new(50000m, CashType.Bill, "50,000 Kip Bill", "50,000 ₭"),
        new(100000m, CashType.Bill, "100,000 Kip Bill", "100,000 ₭"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
