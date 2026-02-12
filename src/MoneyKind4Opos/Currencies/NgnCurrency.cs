using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Nigerian Naira Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.cbn.gov.ng/Currency/currencyhome.asp">Central Bank of Nigeria</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://www.cbn.gov.ng/Currency/currencyhome.asp">Central Bank of Nigeria</seealso></description></item>
/// </list>
/// </remarks>
public class NgnCurrency :
    ICurrency,
    ICashCountFormattable<NgnCurrency>,
    ICurrencyFormattable<NgnCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.NGN;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.50m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("\u20A6", "$n", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Kobo", "k", 0.01m)
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.50m, CashType.Coin, "50 Kobo", "50k", Usage: CashUsagePolicy.NonRecyclable),
        new(1m, CashType.Coin, "1 Naira", "\u20A61", Usage: CashUsagePolicy.NonRecyclable),
        new(2m, CashType.Coin, "2 Naira", "\u20A62", Usage: CashUsagePolicy.NonRecyclable),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(5m, CashType.Bill, "5 Naira", "\u20A65"),
        new(10m, CashType.Bill, "10 Naira", "\u20A610"),
        new(20m, CashType.Bill, "20 Naira", "\u20A620"),
        new(50m, CashType.Bill, "50 Naira", "\u20A650"),
        new(100m, CashType.Bill, "100 Naira", "\u20A6100"),
        new(200m, CashType.Bill, "200 Naira", "\u20A6200"),
        new(500m, CashType.Bill, "500 Naira", "\u20A6500"),
        new(1000m, CashType.Bill, "1000 Naira", "\u20A61000"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => true;
}
