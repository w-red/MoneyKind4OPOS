using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Congolese Franc (CDF).</summary>
/// <remarks>Source: Banque Centrale du Congo (http://www.bcc.cd/)</remarks>
public sealed class CdfCurrency :
    ICurrency,
    ICashCountFormattable<CdfCurrency>,
    ICurrencyFormattable<CdfCurrency>
{
    /// <inheritdoc/>
    public static string Name => "Congolese Franc";

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.CDF;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 50m; // Practical minimum is 50 FC

    /// <inheritdoc/>
    public static bool IsZeroPadding => true;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("FC", "n $", decimalDigits: 2, decimalSep: ",", groupSep: "\u202F");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Centime", "centime", 0.01m)
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins => []; // No coins in circulation

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(50m, CashType.Bill, "50 Franc Bill", "50 FC"),
        new(100m, CashType.Bill, "100 Franc Bill", "100 FC"),
        new(200m, CashType.Bill, "200 Franc Bill", "200 FC"),
        new(500m, CashType.Bill, "500 Franc Bill", "500 FC"),
        new(1000m, CashType.Bill, "1000 Franc Bill", "1000 FC"),
        new(5000m, CashType.Bill, "5000 Franc Bill", "5000 FC"),
        new(10000m, CashType.Bill, "10000 Franc Bill", "10000 FC"),
        new(20000m, CashType.Bill, "20000 Franc Bill", "20000 FC"),
    ];
}
