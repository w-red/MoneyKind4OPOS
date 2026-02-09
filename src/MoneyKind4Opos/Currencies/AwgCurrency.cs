using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Aruban Florin Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.cbaruba.org/currency/banknotes">CBA (Centrale Bank van Aruba)</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://www.cbaruba.org/currency/coins">CBA</seealso></description></item>
/// </list>
/// </remarks>
public class AwgCurrency :
    ICurrency,
    ICashCountFormattable<AwgCurrency>,
    ICurrencyFormattable<AwgCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.AWG;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.05m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("Afl.", "$ n", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("Afl.", "$ n", decimalDigits: 2);

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Cent", "¢", 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.05m, CashType.Coin, "5 Cents", "5¢"),
        new(0.10m, CashType.Coin, "10 Cents", "10¢"),
        new(0.25m, CashType.Coin, "25 Cents", "25¢"),
        new(0.50m, CashType.Coin, "50 Cents", "50¢"),
        new(1.00m, CashType.Coin, "1 Florin", "Afl.1"),
        new(2.50m, CashType.Coin, "2½ Florins", "Afl.2½"),
        new(5.00m, CashType.Coin, "5 Florins", "Afl.5"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(10m, CashType.Bill, "10 Florins", "Afl.10"),
        new(25m, CashType.Bill, "25 Florins", "Afl.25"),
        new(50m, CashType.Bill, "50 Florins", "Afl.50"),
        new(100m, CashType.Bill, "100 Florins", "Afl.100"),
        new(200m, CashType.Bill, "200 Florins", "Afl.200"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
