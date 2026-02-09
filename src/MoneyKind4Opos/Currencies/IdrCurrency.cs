using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Indonesian Rupiah Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://www.bi.go.id/en/rupiah/gambar-uang/Default.aspx">Currency Images (Bank Indonesia)</seealso></description></item>
/// </list>
/// </remarks>
public class IdrCurrency :
    ICurrency,
    ICashCountFormattable<IdrCurrency>,
    ICurrencyFormattable<IdrCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.IDR;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 50m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("IDR", "$n", decimalDigits: 2, groupSep: ".");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("Rp", "$n", decimalDigits: 2, groupSep: ".");

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Sen", null, 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(50m, CashType.Coin, "Rp 50 Coin", "50 Rupiah"),
        new(100m, CashType.Coin, "Rp 100 Coin", "100 Rupiah"),
        new(200m, CashType.Coin, "Rp 200 Coin", "200 Rupiah"),
        new(500m, CashType.Coin, "Rp 500 Coin", "500 Rupiah"),
        new(1000m, CashType.Coin, "Rp 1.000 Coin", "1.000 Rupiah"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1000m, CashType.Bill, "Rp 1.000 Bill", "1.000 Rupiah"),
        new(2000m, CashType.Bill, "Rp 2.000 Bill", "2.000 Rupiah"),
        new(5000m, CashType.Bill, "Rp 5.000 Bill", "5.000 Rupiah"),
        new(10000m, CashType.Bill, "Rp 10.000 Bill", "10.000 Rupiah"),
        new(20000m, CashType.Bill, "Rp 20.000 Bill", "20.000 Rupiah"),
        new(50000m, CashType.Bill, "Rp 50.000 Bill", "50.000 Rupiah"),
        new(100000m, CashType.Bill, "Rp 100.000 Bill", "100.000 Rupiah"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
