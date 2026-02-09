using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Botswana Pula (BWP).</summary>
/// <remarks>Source: Bank of Botswana (https://www.bankofbotswana.bw/)</remarks>
public sealed class BwpCurrency :
    ICurrency,
    ICashCountFormattable<BwpCurrency>,
    ICurrencyFormattable<BwpCurrency>
{
    /// <inheritdoc/>
    public static string Name => "Pula";

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.BWP;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.05m;

    /// <inheritdoc/>
    public static bool IsZeroPadding => true;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("P", "$n", decimalDigits: 2, decimalSep: ".", groupSep: ",");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Thebe", "thebe", 0.01m)
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.05m, CashType.Coin, "5 Thebe Coin", "5t"),
        new(0.10m, CashType.Coin, "10 Thebe Coin", "10t"),
        new(0.25m, CashType.Coin, "25 Thebe Coin", "25t"),
        new(0.50m, CashType.Coin, "50 Thebe Coin", "50t"),
        new(1m, CashType.Coin, "1 Pula Coin", "P1"),
        new(2m, CashType.Coin, "2 Pula Coin", "P2"),
        new(5m, CashType.Coin, "5 Pula Coin", "P5"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(10m, CashType.Bill, "10 Pula Bill", "P10"),
        new(20m, CashType.Bill, "20 Pula Bill", "P20"),
        new(50m, CashType.Bill, "50 Pula Bill", "P50"),
        new(100m, CashType.Bill, "100 Pula Bill", "P100"),
        new(200m, CashType.Bill, "200 Pula Bill", "P200"),
    ];
}
