using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Venezuelan Bolívar Digital Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="http://www.bcv.org.ve/">BCV (Banco Central de Venezuela)</seealso></description></item>
/// </list>
/// <para>※ Bolívar Digital was introduced in 2021 (1:1,000,000 old VES). 200 &amp; 500 notes added in 2024 due to inflation.</para>
/// <para>※ Coins are technically valid but rarely circulate in practice.</para>
/// </remarks>
public class VedCurrency :
    ICurrency,
    ICashCountFormattable<VedCurrency>,
    ICurrencyFormattable<VedCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.VED;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 5.0m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("Bs.S", "$n", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("Bs.D", "$ n", decimalDigits: 2);

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Céntimo", null, 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        // Coins are legally valid but rarely circulate
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(5m, CashType.Bill, "5 Bolívares", "Bs.D 5"),
        new(10m, CashType.Bill, "10 Bolívares", "Bs.D 10"),
        new(20m, CashType.Bill, "20 Bolívares", "Bs.D 20"),
        new(50m, CashType.Bill, "50 Bolívares", "Bs.D 50"),
        new(100m, CashType.Bill, "100 Bolívares", "Bs.D 100"),
        new(200m, CashType.Bill, "200 Bolívares", "Bs.D 200"),
        new(500m, CashType.Bill, "500 Bolívares", "Bs.D 500"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
