using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Hungarian Forint Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://www.mnb.hu/en/banknotes-and-coins">Banknotes and Coins (Magyar Nemzeti Bank)</seealso></description></item>
/// </list>
/// </remarks>
public class HufCurrency :
    ICurrency,
    ICashCountFormattable<HufCurrency>,
    ICurrencyFormattable<HufCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.HUF;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 5m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("Ft", "$n", decimalDigits: 0);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("Ft", "$n", decimalDigits: 0);

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits => [];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(5m, CashType.Coin, "5 Forint Coin", "5 Ft-os érme"),
        new(10m, CashType.Coin, "10 Forint Coin", "10 Ft-os érme"),
        new(20m, CashType.Coin, "20 Forint Coin", "20 Ft-os érme"),
        new(50m, CashType.Coin, "50 Forint Coin", "50 Ft-os érme"),
        new(100m, CashType.Coin, "100 Forint Coin", "100 Ft-os érme"),
        new(200m, CashType.Coin, "200 Forint Coin", "200 Ft-os érme"),
    ];
    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(500m, CashType.Bill, "500 Forint Bill", "500 Ft-os bankjegy"),
        new(1000m, CashType.Bill, "1000 Forint Bill", "1000 Ft-os bankjegy"),
        new(2000m, CashType.Bill, "2000 Forint Bill", "2000 Ft-os bankjegy"),
        new(5000m, CashType.Bill, "5000 Forint Bill", "5000 Ft-os bankjegy"),
        new(10000m, CashType.Bill, "10000 Forint Bill", "10000 Ft-os bankjegy"),
        new(20000m, CashType.Bill, "20000 Forint Bill", "20000 Ft-os bankjegy"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
