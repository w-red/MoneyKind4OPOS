using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Philippine Peso Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.bsp.gov.ph/SitePages/CoinsAndNotes/NewGenerationCurrencyBanknotes.aspx">Banknotes (Bangko Sentral ng Pilipinas)</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://www.bsp.gov.ph/SitePages/CoinsAndNotes/CoinsAndNotes.aspx">Coins (Bangko Sentral ng Pilipinas)</seealso></description></item>
/// </list>
/// </remarks>
public class PhpCurrency :
    ICurrency,
    ICashCountFormattable<PhpCurrency>,
    ICurrencyFormattable<PhpCurrency>
{
    private static readonly NumberFormatInfo _nfi = new()
    {
        CurrencySymbol = "₱",
        CurrencyPositivePattern = 0, // $n
        CurrencyGroupSeparator = ",",
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 2,
    };

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.PHP;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } = new(
        Symbol: "PHP",
        NumberFormat: new NumberFormatInfo
        {
            CurrencySymbol = "PHP",
            CurrencyPositivePattern = 0,
            CurrencyGroupSeparator = ",",
            CurrencyDecimalSeparator = ".",
            CurrencyDecimalDigits = 2
        },
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } = new(
        Symbol: "₱",
        NumberFormat: _nfi,
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Sentimo", "c", 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "1 Sentimo Coin", "1 Sentimo"),
        new(0.05m, CashType.Coin, "5 Sentimo Coin", "5 Sentimo"),
        new(0.10m, CashType.Coin, "10 Sentimo Coin", "10 Sentimo"),
        new(0.25m, CashType.Coin, "25 Sentimo Coin", "25 Sentimo"),
        new(1m, CashType.Coin, "1 Peso Coin", "1 Piso"),
        new(5m, CashType.Coin, "5 Pesos Coin", "5 Piso"),
        new(10m, CashType.Coin, "10 Pesos Coin", "10 Piso"),
        new(20m, CashType.Coin, "20 Pesos Coin", "20 Piso"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(20m, CashType.Bill, "20 Pesos Bill", "20 Piso"),
        new(50m, CashType.Bill, "50 Pesos Bill", "50 Piso"),
        new(100m, CashType.Bill, "100 Pesos Bill", "100 Piso"),
        new(200m, CashType.Bill, "200 Pesos Bill", "200 Piso"),
        new(500m, CashType.Bill, "500 Pesos Bill", "500 Piso"),
        new(1000m, CashType.Bill, "1000 Pesos Bill", "1000 Piso"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
