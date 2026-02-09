using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>North Korean Won Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description>Banknotes of North Korea (Central Bank of the DPRK)</description></item>
/// </list>
/// </remarks>
public class KpwCurrency :
    ICurrency,
    ICashCountFormattable<KpwCurrency>,
    ICurrencyFormattable<KpwCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.KPW;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 5m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("₩", "$n", decimalDigits: 0);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("₩", "$n", decimalDigits: 0);

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits => [];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins => []; // rarely circulated practical value

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(5m, CashType.Bill, "5 Won Bill", "5원"),
        new(10m, CashType.Bill, "10 Won Bill", "10원"),
        new(50m, CashType.Bill, "50 Won Bill", "50원"),
        new(100m, CashType.Bill, "100 Won Bill", "100원"),
        new(200m, CashType.Bill, "200 Won Bill", "200원"),
        new(500m, CashType.Bill, "500 Won Bill", "500원"),
        new(1000m, CashType.Bill, "1000 Won Bill", "1000원"),
        new(2000m, CashType.Bill, "2000 Won Bill", "2000원"),
        new(5000m, CashType.Bill, "5000 Won Bill", "5000원"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
