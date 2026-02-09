using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Hong Kong Dollar Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.hkma.gov.hk/eng/key-functions/money/hong-kong-currency/notes/">Notes - HKMA</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://www.hkma.gov.hk/eng/key-functions/money/hong-kong-currency/coins/">Coins - HKMA</seealso></description></item>
/// </list>
/// </remarks>
public class HkdCurrency :
    ICurrency,
    ICashCountFormattable<HkdCurrency>,
    ICurrencyFormattable<HkdCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.HKD;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.1m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("HK$", "$n");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("$", "$n");

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
        [
            new SubsidiaryUnit(Name: "Cent", Symbol: "¢", Ratio: 0.01m),
        ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.10m, CashType.Coin, "10 Cent Coin", "10¢"),
        new(0.20m, CashType.Coin, "20 Cent Coin", "20¢"),
        new(0.50m, CashType.Coin, "50 Cent Coin", "50¢"),
        new(1.00m, CashType.Coin, "1 Dollar Coin", "$1"),
        new(2.00m, CashType.Coin, "2 Dollar Coin", "$2"),
        new(5.00m, CashType.Coin, "5 Dollar Coin", "$5"),
        new(10.00m, CashType.Coin, "10 Dollar Coin", "$10"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(10m, CashType.Bill, "10 Dollar Bill", "$10"),
        new(20m, CashType.Bill, "20 Dollar Bill", "$20"),
        new(50m, CashType.Bill, "50 Dollar Bill", "$50"),
        new(100m, CashType.Bill, "100 Dollar Bill", "$100"),
        new(500m, CashType.Bill, "500 Dollar Bill", "$500"),
        new(1000m, CashType.Bill, "1000 Dollar Bill", "$1000"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
