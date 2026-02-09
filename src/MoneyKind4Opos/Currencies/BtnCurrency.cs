using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Bhutanese Ngultrum Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.rma.org.bt/historyCurrency/">History of Currency (Royal Monetary Authority of Bhutan)</seealso></description></item>
/// </list>
/// </remarks>
public class BtnCurrency :
    ICurrency,
    ICashCountFormattable<BtnCurrency>,
    ICurrencyFormattable<BtnCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.BTN;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.05m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("BTN", "$n");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("Nu.", "$ n");

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Chertum", "Ch.", 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.05m, CashType.Coin, "5 Chertum Coin", "5 Ch."),
        new(0.10m, CashType.Coin, "10 Chertum Coin", "10 Ch."),
        new(0.20m, CashType.Coin, "20 Chertum Coin", "20 Ch."),
        new(0.25m, CashType.Coin, "25 Chertum Coin", "25 Ch."),
        new(0.50m, CashType.Coin, "50 Chertum Coin", "50 Ch."),
        new(1m, CashType.Coin, "1 Ngultrum Coin", "Nu. 1"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1m, CashType.Bill, "1 Ngultrum Bill", "Nu. 1"),
        new(5m, CashType.Bill, "5 Ngultrum Bill", "Nu. 5"),
        new(10m, CashType.Bill, "10 Ngultrum Bill", "Nu. 10"),
        new(20m, CashType.Bill, "20 Ngultrum Bill", "Nu. 20"),
        new(50m, CashType.Bill, "50 Ngultrum Bill", "Nu. 50"),
        new(100m, CashType.Bill, "100 Ngultrum Bill", "Nu. 100"),
        new(500m, CashType.Bill, "500 Ngultrum Bill", "Nu. 500"),
        new(1000m, CashType.Bill, "1000 Ngultrum Bill", "Nu. 1000"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
