using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Papua New Guinea Kina Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.bankpng.gov.pg/currency/">Bank of Papua New Guinea</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://www.bankpng.gov.pg/currency/">BPNG</seealso></description></item>
/// </list>
/// </remarks>
public class PgkCurrency :
    ICurrency,
    ICashCountFormattable<PgkCurrency>,
    ICurrencyFormattable<PgkCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.PGK;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.05m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("K", "$n", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Toea", "t", 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.05m, CashType.Coin, "5 Toea", "5t"),
        new(0.10m, CashType.Coin, "10 Toea", "10t"),
        new(0.20m, CashType.Coin, "20 Toea", "20t"),
        new(0.50m, CashType.Coin, "50 Toea", "50t"),
        new(1.00m, CashType.Coin, "1 Kina", "1K"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(2m, CashType.Bill, "2 Kina", "2K"),
        new(5m, CashType.Bill, "5 Kina", "5K"),
        new(10m, CashType.Bill, "10 Kina", "10K"),
        new(20m, CashType.Bill, "20 Kina", "20K"),
        new(50m, CashType.Bill, "50 Kina", "50K"),
        new(100m, CashType.Bill, "100 Kina", "100K"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
