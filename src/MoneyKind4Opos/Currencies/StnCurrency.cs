using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>São Tomé and Príncipe Dobra (STN).</summary>
/// <remarks>Source: Banco Central de São Tomé e Príncipe (https://www.bcstp.st/)</remarks>
public sealed class StnCurrency :
    ICurrency,
    ICashCountFormattable<StnCurrency>,
    ICurrencyFormattable<StnCurrency>
{
    /// <inheritdoc/>
    public static string Name => "Dobra";

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.STN;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.10m;

    /// <inheritdoc/>
    public static bool IsZeroPadding => true;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("Db", "n $", decimalDigits: 2, decimalSep: ",", groupSep: "\u00A0");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Centimo", "cêntimo", 0.01m)
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.10m, CashType.Coin, "10 Centimo Coin", "10 cêntimos"),
        new(0.20m, CashType.Coin, "20 Centimo Coin", "20 cêntimos"),
        new(0.50m, CashType.Coin, "50 Centimo Coin", "50 cêntimos"),
        new(1m, CashType.Coin, "1 Dobra Coin", "1 dobra"),
        new(2m, CashType.Coin, "2 Dobra Coin", "2 dobras"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(5m, CashType.Bill, "5 Dobra Bill", "5 dobras"),
        new(10m, CashType.Bill, "10 Dobra Bill", "10 dobras"),
        new(20m, CashType.Bill, "20 Dobra Bill", "20 dobras"),
        new(50m, CashType.Bill, "50 Dobra Bill", "50 dobras"),
        new(100m, CashType.Bill, "100 Dobra Bill", "100 dobras"),
        new(200m, CashType.Bill, "200 Dobra Bill", "200 dobras"),
    ];
}
