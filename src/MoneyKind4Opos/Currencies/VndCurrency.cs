using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Vietnamese Dong Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Banknotes</term><description><seealso href="https://sbv.gov.vn/webcenter/portal/vi/menu/sm/chitiet/inbaiviet?dDocName=CNTHWEBAP01162394762">Current Banknotes - SBV</seealso></description></item>
/// </list>
/// </remarks>
public class VndCurrency :
    ICurrency,
    ICashCountFormattable<VndCurrency>,
    ICurrencyFormattable<VndCurrency>
{
    private static readonly NumberFormatInfo _nfi = new()
    {
        CurrencySymbol = "₫",
        CurrencyGroupSeparator = ".",
        CurrencyDecimalSeparator = ",",
        CurrencyDecimalDigits = 0,
        CurrencyPositivePattern = 1, // n $
    };

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.VND;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 1000m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } = new(
        Symbol: "₫",
        NumberFormat: _nfi,
        DisplayFormat: new(SymbolPlacement.Postfix)
    );

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
        [
            new SubsidiaryUnit(Name: "Hào", Symbol: "hao", Ratio: 0.1m),
            new SubsidiaryUnit(Name: "Xu", Symbol: "xu", Ratio: 0.01m),
        ];

    /// <inheritdoc/>
    /// <remarks>Coins are legally valid but practically not used in modern Vietnam.</remarks>
    public static IEnumerable<CashFaceInfo> Coins => [];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1000m, CashType.Bill, "1,000 ₫", "1000"),
        new(2000m, CashType.Bill, "2,000 ₫", "2000"),
        new(5000m, CashType.Bill, "5,000 ₫", "5000"),
        new(10000m, CashType.Bill, "10,000 ₫", "10000"),
        new(20000m, CashType.Bill, "20,000 ₫", "20000"),
        new(50000m, CashType.Bill, "50,000 ₫", "50000"),
        new(100000m, CashType.Bill, "100,000 ₫", "100000"),
        new(200000m, CashType.Bill, "200,000 ₫", "200000"),
        new(500000m, CashType.Bill, "500,000 ₫", "500000"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => true;
}
