using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Mongolian Tugrik Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.mongolbank.mn/en/banknote">Banknotes (Bank of Mongolia)</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://www.mongolbank.mn/en/p/1391">Coins (Bank of Mongolia)</seealso></description></item>
/// </list>
/// </remarks>
public class MntCurrency :
    ICurrency,
    ICashCountFormattable<MntCurrency>,
    ICurrencyFormattable<MntCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.MNT;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 1m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("MNT", "$n", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("₮", "$n", decimalDigits: 2);

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Möngö", null, 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(20m, CashType.Coin, "20 Tugrik Coin", "20 ₮"),
        new(50m, CashType.Coin, "50 Tugrik Coin", "50 ₮"),
        new(100m, CashType.Coin, "100 Tugrik Coin", "100 ₮"),
        new(200m, CashType.Coin, "200 Tugrik Coin", "200 ₮"),
        new(500m, CashType.Coin, "500 Tugrik Coin", "500 ₮"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1m, CashType.Bill, "1 Tugrik Bill", "1 ₮"),
        new(5m, CashType.Bill, "5 Tugrik Bill", "5 ₮"),
        new(10m, CashType.Bill, "10 Tugrik Bill", "10 ₮"),
        new(20m, CashType.Bill, "20 Tugrik Bill", "20 ₮"),
        new(50m, CashType.Bill, "50 Tugrik Bill", "50 ₮"),
        new(100m, CashType.Bill, "100 Tugrik Bill", "100 ₮"),
        new(500m, CashType.Bill, "500 Tugrik Bill", "500 ₮"),
        new(1000m, CashType.Bill, "1000 Tugrik Bill", "1000 ₮"),
        new(5000m, CashType.Bill, "5000 Tugrik Bill", "5000 ₮"),
        new(10000m, CashType.Bill, "10000 Tugrik Bill", "10000 ₮"),
        new(20000m, CashType.Bill, "20000 Tugrik Bill", "20000 ₮"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
