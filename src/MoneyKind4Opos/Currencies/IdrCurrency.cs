using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Indonesian Rupiah Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Banknotes and Coins</term><description><seealso href="https://www.bi.go.id/en/rupiah/gambar-uang/Default.aspx">Currency Images - Bank Indonesia</seealso></description></item>
/// </list>
/// </remarks>
public class IdrCurrency :
    ICurrency,
    ICashCountFormattable<IdrCurrency>,
    ICurrencyFormattable<IdrCurrency>
{
    private static readonly NumberFormatInfo _nfi = new()
    {
        CurrencySymbol = "Rp",
        CurrencyGroupSeparator = ".",
        CurrencyDecimalSeparator = ",",
        CurrencyDecimalDigits = 0,
        CurrencyPositivePattern = 0, // $n
    };

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.IDR;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 50m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } = new(
        Symbol: "Rp",
        NumberFormat: _nfi,
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
        [
            new SubsidiaryUnit(Name: "Sen", Symbol: "sen", Ratio: 0.01m),
        ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(50m, CashType.Coin, "Rp 50 Coin", "Rp 50"),
        new(100m, CashType.Coin, "Rp 100 Coin", "Rp 100"),
        new(200m, CashType.Coin, "Rp 200 Coin", "Rp 200"),
        new(500m, CashType.Coin, "Rp 500 Coin", "Rp 500"),
        new(1000m, CashType.Coin, "Rp 1000 Coin", "Rp 1000"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1000m, CashType.Bill, "Rp 1,000 Bill", "Rp 1000"),
        new(2000m, CashType.Bill, "Rp 2,000 Bill", "Rp 2000"),
        new(5000m, CashType.Bill, "Rp 5,000 Bill", "Rp 5000"),
        new(10000m, CashType.Bill, "Rp 10,000 Bill", "Rp 10000"),
        new(20000m, CashType.Bill, "Rp 20,000 Bill", "Rp 20000"),
        new(50000m, CashType.Bill, "Rp 50,000 Bill", "Rp 50000"),
        new(100000m, CashType.Bill, "Rp 100,000 Bill", "Rp 100000"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => true;
}
