using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Bulgarian Lev Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.bnb.bg/NotesAndCoins/NACBanknotes/NotesInCirculation/index.htm">BNB (Bulgarian National Bank)</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://www.bnb.bg/NotesAndCoins/NACCoins/CoinsInCirculation/index.htm">BNB</seealso></description></item>
/// </list>
/// </remarks>
public class BgnCurrency :
    ICurrency,
    ICashCountFormattable<BgnCurrency>,
    ICurrencyFormattable<BgnCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.BGN;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("лв.", "n $", decimalDigits: 2, groupSep: "\u00A0", decimalSep: ",");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Stotinka", "ст.", 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "1 Stotinka", "1 ст."),
        new(0.02m, CashType.Coin, "2 Stotinki", "2 ст."),
        new(0.05m, CashType.Coin, "5 Stotinki", "5 ст."),
        new(0.10m, CashType.Coin, "10 Stotinki", "10 ст."),
        new(0.20m, CashType.Coin, "20 Stotinki", "20 ст."),
        new(0.50m, CashType.Coin, "50 Stotinki", "50 ст."),
        new(1.00m, CashType.Coin, "1 Lev", "1 лв."),
        new(2.00m, CashType.Coin, "2 Leva", "2 лв."),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(5m, CashType.Bill, "5 Leva", "5 лв."),
        new(10m, CashType.Bill, "10 Leva", "10 лв."),
        new(20m, CashType.Bill, "20 Leva", "20 лв."),
        new(50m, CashType.Bill, "50 Leva", "50 лв."),
        new(100m, CashType.Bill, "100 Leva", "100 лв."),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
