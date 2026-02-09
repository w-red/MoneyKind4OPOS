using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Isle of Man Pound Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://www.gov.im/categories/tax-vat-and-your-money/customs-and-excise/isle-of-man-banknotes/">IOM Government</seealso></description></item>
/// </list>
/// <para>※ Non-ISO currency code (informal: IMP). Pegged 1:1 to GBP. GBP is also legal tender.</para>
/// <para>※ Isle of Man issues £1 notes and a unique £5 coin.</para>
/// </remarks>
public class ImpCurrency :
    ICurrency,
    ICashCountFormattable<ImpCurrency>,
    ICurrencyFormattable<ImpCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.IMP;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("£", "$n", decimalDigits: 2, groupSep: ",", decimalSep: ".");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Penny", "p", 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "1 Penny", "1p"),
        new(0.02m, CashType.Coin, "2 Pence", "2p"),
        new(0.05m, CashType.Coin, "5 Pence", "5p"),
        new(0.10m, CashType.Coin, "10 Pence", "10p"),
        new(0.20m, CashType.Coin, "20 Pence", "20p"),
        new(0.50m, CashType.Coin, "50 Pence", "50p"),
        new(1.00m, CashType.Coin, "1 Pound", "£1"),
        new(2.00m, CashType.Coin, "2 Pounds", "£2"),
        new(5.00m, CashType.Coin, "5 Pounds", "£5"),  // Unique £5 coin
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1m, CashType.Bill, "1 Pound", "£1"),  // Unique £1 note
        new(5m, CashType.Bill, "5 Pounds", "£5"),
        new(10m, CashType.Bill, "10 Pounds", "£10"),
        new(20m, CashType.Bill, "20 Pounds", "£20"),
        new(50m, CashType.Bill, "50 Pounds", "£50"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
