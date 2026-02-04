using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Qatari Riyal Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Banknotes</term><description><seealso href="https://www.qcb.gov.qa/en/Pages/HistoryOfBanknotes.aspx">Banknotes - QCB</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://marhaba.qa/currency-and-banking-sector-in-qatar/">Coins - QCB</seealso></description></item>
/// </list>
/// </remarks>
public class QarCurrency :
    ICurrency,
    ICashCountFormattable<QarCurrency>,
    ICurrencyFormattable<QarCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.QAR;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Dirham", null, 0.01m),
    ];

    private static readonly NumberFormatInfo _nfi = new()
    {
        CurrencySymbol = "QR",
        CurrencyPositivePattern = 3, // n $
        CurrencyGroupSeparator = ",",
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 2,
    };

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        new(
            Symbol: "QR",
            NumberFormat: _nfi,
            DisplayFormat: new(SymbolPlacement.Postfix)
        );

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "1 Dirham Coin", "1d"),
        new(0.05m, CashType.Coin, "5 Dirham Coin", "5d"),
        new(0.10m, CashType.Coin, "10 Dirham Coin", "10d"),
        new(0.25m, CashType.Coin, "25 Dirham Coin", "25d"),
        new(0.50m, CashType.Coin, "50 Dirham Coin", "50d"),
    ];
    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1.0m, CashType.Bill, "1 QR Bill", "1 QR"),
        new(5.0m, CashType.Bill, "5 QR Bill", "5 QR"),
        new(10.0m, CashType.Bill, "10 QR Bill", "10 QR"),
        new(50.0m, CashType.Bill, "50 QR Bill", "50 QR"),
        new(100.0m, CashType.Bill, "100 QR Bill", "100 QR"),
        new(200.0m, CashType.Bill, "200 QR Bill", "200 QR"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
