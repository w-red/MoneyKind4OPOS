using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

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
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.VND;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 100m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("VND", "n $", decimalDigits: 0, groupSep: ".");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("₫", "n $", decimalDigits: 0, groupSep: ".");

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Hào", null, 0.1m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(200m, CashType.Coin, "200 ₫", "200 đồng", Usage: CashUsagePolicy.NonRecyclable),
        new(500m, CashType.Coin, "500 ₫", "500 đồng", Usage: CashUsagePolicy.NonRecyclable),
        new(1000m, CashType.Coin, "1000 ₫", "1000 đồng", Usage: CashUsagePolicy.NonRecyclable),
        new(2000m, CashType.Coin, "2000 ₫", "2000 đồng", Usage: CashUsagePolicy.NonRecyclable),
        new(5000m, CashType.Coin, "5000 ₫", "5000 đồng", Usage: CashUsagePolicy.NonRecyclable),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(100m, CashType.Bill, "100 ₫", "100 đồng", Usage: CashUsagePolicy.NonRecyclable),
        new(200m, CashType.Bill, "200 ₫", "200 đồng", Usage: CashUsagePolicy.NonRecyclable),
        new(500m, CashType.Bill, "500 ₫", "500 đồng", Usage: CashUsagePolicy.NonRecyclable),
        new(1000m, CashType.Bill, "1.000 ₫", "Một nghìn đồng"),
        new(2000m, CashType.Bill, "2.000 ₫", "Hai nghìn đồng"),
        new(5000m, CashType.Bill, "5.000 ₫", "Năm nghìn đồng"),
        new(10000m, CashType.Bill, "10.000 ₫", "Mười nghìn đồng"),
        new(20000m, CashType.Bill, "20.000 ₫", "Hai mươi nghìn đồng"),
        new(50000m, CashType.Bill, "50.000 ₫", "Năm mươi nghìn đồng"),
        new(100000m, CashType.Bill, "100.000 ₫", "Một trăm nghìn đồng"),
        new(200000m, CashType.Bill, "200.000 ₫", "Hai trăm nghìn đồng"),
        new(500000m, CashType.Bill, "500.000 ₫", "Năm trăm nghìn đồng", Usage: CashUsagePolicy.CollectionOnly),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
