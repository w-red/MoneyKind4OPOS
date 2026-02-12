using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Myanmar Kyat Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.cbm.gov.mm/content/history-bank-notes">Banknotes (Central Bank of Myanmar)</seealso></description></item>
/// </list>
/// </remarks>
public class MmkCurrency :
    ICurrency,
    ICashCountFormattable<MmkCurrency>,
    ICurrencyFormattable<MmkCurrency>
{
    private static readonly NumberFormatInfo _nfi = new()
    {
        CurrencySymbol = "K",
        CurrencyPositivePattern = 0, // $n
        CurrencyGroupSeparator = ",",
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 0,
    };

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.MMK;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 100m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } = new(
        Symbol: "MMK",
        NumberFormat: new NumberFormatInfo
        {
            CurrencySymbol = "MMK",
            CurrencyPositivePattern = 0,
            CurrencyGroupSeparator = ",",
            CurrencyDecimalSeparator = ".",
            CurrencyDecimalDigits = 0
        },
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } = new(
        Symbol: "K",
        NumberFormat: _nfi,
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Pya", "p", 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins => [];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(100m, CashType.Bill, "100 Kyats Bill", "K 100"),
        new(200m, CashType.Bill, "200 Kyats Bill", "K 200"),
        new(500m, CashType.Bill, "500 Kyats Bill", "K 500"),
        new(1000m, CashType.Bill, "1000 Kyats Bill", "K 1000"),
        new(5000m, CashType.Bill, "5000 Kyats Bill", "K 5000"),
        new(10000m, CashType.Bill, "10000 Kyats Bill", "K 10000"),
        new(20000m, CashType.Bill, "20000 Kyats Bill", "K 20000", Usage: CashUsagePolicy.CollectionOnly),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
