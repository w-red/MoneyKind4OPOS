using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Albanian Lek Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://www.bankofalbania.org/Currency/Banknotes_and_Coins/">Bank of Albania - Banknotes and Coins</seealso></description></item>
/// </list>
/// </remarks>
public class AllCurrency :
    ICurrency,
    ICashCountFormattable<AllCurrency>,
    ICurrencyFormattable<AllCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.ALL;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 1.0m;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Qindarkë", null, 0.01m),
    ];

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("L", "$n", decimalDigits: 0);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(1.0m, CashType.Coin, "1 Lek Coin", "1 Lek", Usage: CashUsagePolicy.NonRecyclable),
        new(5.0m, CashType.Coin, "5 Lekë Coin", "5 Lekë"),
        new(10.0m, CashType.Coin, "10 Lekë Coin", "10 Lekë"),
        new(20.0m, CashType.Coin, "20 Lekë Coin", "20 Lekë"),
        new(50.0m, CashType.Coin, "50 Lekë Coin", "50 Lekë"),
        new(100.0m, CashType.Coin, "100 Lekë Coin", "100 Lekë"),
    ];
    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(200.0m, CashType.Bill, "200 Lekë Bill", "200 Lekë"),
        new(500.0m, CashType.Bill, "500 Lekë Bill", "500 Lekë"),
        new(1000.0m, CashType.Bill, "1000 Lekë Bill", "1000 Lekë"),
        new(2000.0m, CashType.Bill, "2000 Lekë Bill", "2000 Lekë"),
        new(5000.0m, CashType.Bill, "5000 Lekë Bill", "5000 Lekë"),
        new(10000.0m, CashType.Bill, "10000 Lekë Bill", "10000 Lekë"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
