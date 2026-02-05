using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Vietnamese Dong Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://sbv.gov.vn/webcenter/portal/vi/menu/sm/chitiet/inbaiviet?dDocName=CNTHWEBAP01162394762">Banknotes (State Bank of Vietnam)</seealso></description></item>
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
        CurrencyPositivePattern = 3, // n $
        CurrencyGroupSeparator = ".",
        CurrencyDecimalSeparator = ",",
        CurrencyDecimalDigits = 0,
    };

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.VND;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 1000m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } = new(
        Symbol: "VND",
        NumberFormat: new NumberFormatInfo
        {
            CurrencySymbol = "VND",
            CurrencyPositivePattern = 3,
            CurrencyGroupSeparator = ".",
            CurrencyDecimalSeparator = ",",
            CurrencyDecimalDigits = 0
        },
        DisplayFormat: new(SymbolPlacement.Postfix)
    );

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } = new(
        Symbol: "₫",
        NumberFormat: _nfi,
        DisplayFormat: new(SymbolPlacement.Postfix)
    );

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Hào", null, 0.1m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins => [];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1000m, CashType.Bill, "1.000 ₫", "Một nghìn đồng"),
        new(2000m, CashType.Bill, "2.000 ₫", "Hai nghìn đồng"),
        new(5000m, CashType.Bill, "5.000 ₫", "Năm nghìn đồng"),
        new(10000m, CashType.Bill, "10.000 ₫", "Mười nghìn đồng"),
        new(20000m, CashType.Bill, "20.000 ₫", "Hai mươi nghìn đồng"),
        new(50000m, CashType.Bill, "50.000 ₫", "Năm mươi nghìn đồng"),
        new(100000m, CashType.Bill, "100.000 ₫", "Một trăm nghìn đồng"),
        new(200000m, CashType.Bill, "200.000 ₫", "Hai trăm nghìn đồng"),
        new(500000m, CashType.Bill, "500.000 ₫", "Năm trăm nghìn đồng"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
