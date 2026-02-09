using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Macanese Pataca Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://www.amcm.gov.mo/en/currency/notes/banknotes-of-macao">Banknotes of Macao (Monetary Authority of Macao)</seealso></description></item>
/// </list>
/// </remarks>
public class MopCurrency :
    ICurrency,
    ICashCountFormattable<MopCurrency>,
    ICurrencyFormattable<MopCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.MOP;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.1m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("P", "$n", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("P", "$n", decimalDigits: 2);

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits => [];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.1m, CashType.Coin, "10 Avos Coin", "壹毫"),
        new(0.2m, CashType.Coin, "20 Avos Coin", "貳毫"),
        new(0.5m, CashType.Coin, "50 Avos Coin", "伍毫"),
        new(1m, CashType.Coin, "1 Pataca Coin", "壹圓"),
        new(2m, CashType.Coin, "2 Patacas Coin", "貳圓"),
        new(5m, CashType.Coin, "5 Patacas Coin", "伍圓"),
        new(10m, CashType.Coin, "10 Patacas Coin", "拾圓"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(10m, CashType.Bill, "10 Patacas Bill", "拾圓"),
        new(20m, CashType.Bill, "20 Patacas Bill", "貳拾圓"),
        new(50m, CashType.Bill, "50 Patacas Bill", "伍拾圓"),
        new(100m, CashType.Bill, "100 Patacas Bill", "壹佰圓"),
        new(500m, CashType.Bill, "500 Patacas Bill", "伍佰圓"),
        new(1000m, CashType.Bill, "1000 Patacas Bill", "壹仟圓"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
