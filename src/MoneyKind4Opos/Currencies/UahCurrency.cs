using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Ukrainian Hryvnia Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://bank.gov.ua/en/uah/obig-banknoty">National Bank of Ukraine - Banknotes and Coins</seealso></description></item>
/// </list>
/// </remarks>
public class UahCurrency :
    ICurrency,
    ICashCountFormattable<UahCurrency>,
    ICurrencyFormattable<UahCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.UAH;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.10m;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Kopiyka", null, 0.01m),
    ];

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("₴", "n $", decimalSep: ",", groupSep: " ");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.10m, CashType.Coin, "10 Kopiyok Coin", "10к."),
        new(0.50m, CashType.Coin, "50 Kopiyok Coin", "50к."),
        new(1.0m, CashType.Coin, "1 Hryvnia Coin", "1₴"),
        new(2.0m, CashType.Coin, "2 Hryvni Coin", "2₴"),
        new(5.0m, CashType.Coin, "5 Hryvень Coin", "5₴"),
        new(10.0m, CashType.Coin, "10 Hryvень Coin", "10₴"),
    ];
    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1.0m, CashType.Bill, "1 Hryvnia Bill", "1₴"),
        new(2.0m, CashType.Bill, "2 Hryvni Bill", "2₴"),
        new(5.0m, CashType.Bill, "5 Hryvень Bill", "5₴"),
        new(10.0m, CashType.Bill, "10 Hryvень Bill", "10₴"),
        new(20.0m, CashType.Bill, "20 Hryvень Bill", "20₴"),
        new(50.0m, CashType.Bill, "50 Hryvень Bill", "50₴"),
        new(100.0m, CashType.Bill, "100 Hryvень Bill", "100₴"),
        new(200.0m, CashType.Bill, "200 Hryvень Bill", "200₴"),
        new(500.0m, CashType.Bill, "500 Hryvень Bill", "500₴"),
        new(1000.0m, CashType.Bill, "1000 Hryvень Bill", "1000₴"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
