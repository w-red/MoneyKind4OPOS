using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>New Taiwan Dollar Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://museum.cbc.gov.tw/web/en-us/circulation/banknote">Banknotes (Museum of CBC)</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://museum.cbc.gov.tw/web/en-us/circulation/currency">Coins (Museum of CBC)</seealso></description></item>
/// </list>
/// </remarks>
public class TwdCurrency :
    ICurrency,
    ICashCountFormattable<TwdCurrency>,
    ICurrencyFormattable<TwdCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.TWD;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 1m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("TW$", "$n", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("$", "$n", decimalDigits: 2);

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
        [
            // new SubsidiaryUnit(Name: "Cent", Symbol: "¢", Ratio: 0.01m),
        ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(1.00m, CashType.Coin, "1 Dollar Coin", "$1"),
        new(5.00m, CashType.Coin, "5 Dollar Coin", "$5"),
        new(10.00m, CashType.Coin, "10 Dollar Coin", "$10"),
        new(20.00m, CashType.Coin, "20 Dollar Coin", "$20"),
        new(50.00m, CashType.Coin, "50 Dollar Coin", "$50"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(100m, CashType.Bill, "100 Dollar Bill", "$100"),
        new(200m, CashType.Bill, "200 Dollar Bill", "$200"),
        new(500m, CashType.Bill, "500 Dollar Bill", "$500"),
        new(1000m, CashType.Bill, "1000 Dollar Bill", "$1000"),
        new(2000m, CashType.Bill, "2000 Dollar Bill", "$2000"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
