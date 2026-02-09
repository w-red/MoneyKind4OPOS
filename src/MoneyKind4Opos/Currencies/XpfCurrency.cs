using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>CFP Franc Currency (Comptoirs Français du Pacifique Franc)</summary>
/// <remarks>
/// Used in French Polynesia, New Caledonia, and Wallis and Futuna.
/// Also known as the "pacific franc" (Franc Pacifique).
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.ieom.fr/ieom/billets-et-pieces/">IEOM (Institut d'Émission d'Outre-Mer)</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://www.ieom.fr/ieom/billets-et-pieces/">IEOM</seealso></description></item>
/// </list>
/// </remarks>
public class XpfCurrency :
    ICurrency,
    ICashCountFormattable<XpfCurrency>,
    ICurrencyFormattable<XpfCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.XPF;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 1.0m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("FCFP", "n $", decimalDigits: 0, groupSep: "\u202F", decimalSep: ",");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits => []; // Centime discontinued

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(1m, CashType.Coin, "1 Franc", "1F"),
        new(2m, CashType.Coin, "2 Francs", "2F"),
        new(5m, CashType.Coin, "5 Francs", "5F"),
        new(10m, CashType.Coin, "10 Francs", "10F"),
        new(20m, CashType.Coin, "20 Francs", "20F"),
        new(50m, CashType.Coin, "50 Francs", "50F"),
        new(100m, CashType.Coin, "100 Francs", "100F"),
        new(200m, CashType.Coin, "200 Francs", "200F"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(500m, CashType.Bill, "500 Francs", "500F"),
        new(1000m, CashType.Bill, "1000 Francs", "1000F"),
        new(5000m, CashType.Bill, "5000 Francs", "5000F"),
        new(10000m, CashType.Bill, "10000 Francs", "10000F"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
