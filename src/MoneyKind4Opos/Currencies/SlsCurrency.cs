using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Somaliland Shilling (SLS) - Non-ISO Currency.</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Source</term><description><seealso href="https://en.wikipedia.org/wiki/Somaliland_shilling">Wikipedia: Somaliland Shilling</seealso></description></item>
/// <item><term>Issuer</term><description>Bank of Somaliland (Baanka Somaliland)</description></item>
/// </list>
/// </remarks>
public sealed class SlsCurrency : ICurrency, ICashCountFormattable<SlsCurrency>, ICurrencyFormattable<SlsCurrency>
{
    private SlsCurrency() { }

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.SLS;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 100m; // 100 Shilling is the smallest circulating banknote.

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("Sl.Sh.", "$ n", decimalDigits: 0);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local =>
        CurrencyFormattingOptions.Create("/-", "n$", decimalDigits: 0);

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits => [];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins => [];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new CashFaceInfo(100m, CashType.Bill, "100 Shilling Bill", "boqol shilin"),
        new CashFaceInfo(500m, CashType.Bill, "500 Shilling Bill", "shan boqol shilin"),
        new CashFaceInfo(1000m, CashType.Bill, "1000 Shilling Bill", "kun shilin"),
        new CashFaceInfo(5000m, CashType.Bill, "5000 Shilling Bill", "shan kun shilin")
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
