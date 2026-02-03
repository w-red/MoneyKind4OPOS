using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Israeli New Shekel Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.boi.org.il/en/economic-roles/banknotes-and-coins/">Banknotes - BOI</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://www.boi.org.il/en/economic-roles/coins/">Coins - BOI</seealso></description></item>
/// </list>
/// </remarks>
public class IlsCurrency :
    ICurrency,
    ICashCountFormattable<IlsCurrency>,
    ICurrencyFormattable<IlsCurrency>
{
    private static readonly NumberFormatInfo _nfi = new()
    {
        CurrencySymbol = "₪",
        CurrencyGroupSeparator = ",",
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 1,
    };

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.ILS;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.1m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } = new(
        Symbol: "₪",
        NumberFormat: new NumberFormatInfo 
        { 
            CurrencySymbol = "₪", 
            CurrencyGroupSeparator = ",", 
            CurrencyDecimalSeparator = ".", 
            CurrencyDecimalDigits = 1 
        },
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } = new(
        Symbol: "₪",
        NumberFormat: _nfi,
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
        [
            new SubsidiaryUnit(Name: "Agorot", Symbol: "ag", Ratio: 0.01m),
        ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.10m, CashType.Coin, "10 Agorot Coin", "10a"),
        new(0.50m, CashType.Coin, "₪ 1/2 Coin", "₪ 1/2"),
        new(1.00m, CashType.Coin, "₪ 1 Coin", "₪ 1"),
        new(2.00m, CashType.Coin, "₪ 2 Coin", "₪ 2"),
        new(5.00m, CashType.Coin, "₪ 5 Coin", "₪ 5"),
        new(10.00m, CashType.Coin, "₪ 10 Coin", "₪ 10"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(20m, CashType.Bill, "₪ 20 Bill", "₪ 20"),
        new(50m, CashType.Bill, "₪ 50 Bill", "₪ 50"),
        new(100m, CashType.Bill, "₪ 100 Bill", "₪ 100"),
        new(200m, CashType.Bill, "₪ 200 Bill", "₪ 200"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
