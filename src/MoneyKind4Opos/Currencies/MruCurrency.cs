using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Mauritanian Ouguiya Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.bcm.mr/">Banque Centrale de Mauritanie</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://www.bcm.mr/">Banque Centrale de Mauritanie</seealso></description></item>
/// </list>
/// </remarks>
public class MruCurrency :
    ICurrency,
    ICashCountFormattable<MruCurrency>,
    ICurrencyFormattable<MruCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.MRU;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.20m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("UM", "n $", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Khoums", "kh", 0.20m) // 1/5 Ouguiya
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.20m, CashType.Coin, "1/5 Ouguiya", "1/5um"),
        new(1m, CashType.Coin, "1 Ouguiya", "1um"),
        new(5m, CashType.Coin, "5 Ouguiya", "5um"),
        new(10m, CashType.Coin, "10 Ouguiya", "10um"),
        new(20m, CashType.Coin, "20 Ouguiya", "20um"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(50m, CashType.Bill, "50 Ouguiya", "50um"),
        new(100m, CashType.Bill, "100 Ouguiya", "100um"),
        new(200m, CashType.Bill, "200 Ouguiya", "200um"),
        new(500m, CashType.Bill, "500 Ouguiya", "500um"),
        new(1000m, CashType.Bill, "1000 Ouguiya", "1000um"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => true;
}
