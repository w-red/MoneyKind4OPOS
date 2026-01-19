using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>British Pound Sterling Currency</summary>
public class GbpCurrency : ICurrency
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.GBP;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;
    /// <inheritdoc/>
    public static string Symbol => "£";
    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Pence", "p", 0.01m),
    ];

    /// <inheritdoc/>
    public static CurrencyDisplayFormat DisplayFormat => new(
        Placement: SymbolPlacement.Postfix,
        DecimalZeroReplacement: ".",
        GroupSeparator: ",",
        DecimalSeparator: "."
    );

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "1 Penny", "One Penny"),
        new(0.02m, CashType.Coin, "2 Pence", "Two Pence"),
        new(0.05m, CashType.Coin, "5 Pence", "Five Pence"),
        new(0.10m, CashType.Coin, "10 Pence", "Ten Pence"),
        new(0.20m, CashType.Coin, "20 Pence", "Twenty Pence"),
        new(0.50m, CashType.Coin, "50 Pence", "Fifty Pence"),
        new(1.00m, CashType.Coin, "1 Pound Coin", "One Pound Coin"),
        new(2.00m, CashType.Coin, "2 Pound Coin", "Two Pound Coin"),
    ];
    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(5.00m, CashType.Banknote, "5 Pound Note", "Five Pound Note"),
        new(10.00m, CashType.Banknote, "10 Pound Note", "Ten Pound Note"),
        new(20.00m, CashType.Banknote, "20 Pound Note", "Twenty Pound Note"),
        new(50.00m, CashType.Banknote, "50 Pound Note", "Fifty Pound Note"),
    ];
}
