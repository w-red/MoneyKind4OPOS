using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Costa Rican Colón Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://www.bccr.fi.cr/">BCCR</seealso></description></item>
/// </list>
/// </remarks>
public class CrcCurrency :
    ICurrency,
    ICashCountFormattable<CrcCurrency>,
    ICurrencyFormattable<CrcCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.CRC;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 5m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("\u20A1", "$n");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("\u20A1", "$n");

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits => [];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(5m, CashType.Coin, "5 Colones", "\u20A15"),
        new(10m, CashType.Coin, "10 Colones", "\u20A110"),
        new(25m, CashType.Coin, "25 Colones", "\u20A125"),
        new(50m, CashType.Coin, "50 Colones", "\u20A150"),
        new(100m, CashType.Coin, "100 Colones", "\u20A1100"),
        new(500m, CashType.Coin, "500 Colones", "\u20A1500"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1000m, CashType.Bill, "1000 Colones", "\u20A11000"),
        new(2000m, CashType.Bill, "2000 Colones", "\u20A12000"),
        new(5000m, CashType.Bill, "5000 Colones", "\u20A15000"),
        new(10000m, CashType.Bill, "10000 Colones", "\u20A110000"),
        new(20000m, CashType.Bill, "20000 Colones", "\u20A120000"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
