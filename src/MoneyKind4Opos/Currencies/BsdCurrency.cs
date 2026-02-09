using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Bahamian Dollar Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.centralbankbahamas.com/banknotes">CBB (Central Bank of The Bahamas)</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://www.centralbankbahamas.com/faq-s/issuer-of-banknotes-and-coins">CBB</seealso></description></item>
/// </list>
/// </remarks>
public class BsdCurrency :
    ICurrency,
    ICashCountFormattable<BsdCurrency>,
    ICurrencyFormattable<BsdCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.BSD;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("$", "$n", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("B$", "$n", decimalDigits: 2);

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Cent", "¢", 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "1 Cent", "1¢"),
        new(0.05m, CashType.Coin, "5 Cents", "5¢"),
        new(0.10m, CashType.Coin, "10 Cents", "10¢"),
        new(0.15m, CashType.Coin, "15 Cents", "15¢"),
        new(0.25m, CashType.Coin, "25 Cents", "25¢"),
        new(0.50m, CashType.Coin, "50 Cents", "50¢"),
        new(1.00m, CashType.Coin, "1 Dollar", "B$1"),
        new(2.00m, CashType.Coin, "2 Dollars", "B$2"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(0.50m, CashType.Bill, "50 Cents", "B$0.50"),
        new(1m, CashType.Bill, "1 Dollar", "B$1"),
        new(3m, CashType.Bill, "3 Dollars", "B$3"),
        new(5m, CashType.Bill, "5 Dollars", "B$5"),
        new(10m, CashType.Bill, "10 Dollars", "B$10"),
        new(20m, CashType.Bill, "20 Dollars", "B$20"),
        new(50m, CashType.Bill, "50 Dollars", "B$50"),
        new(100m, CashType.Bill, "100 Dollars", "B$100"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
