using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Hong Kong Dollar Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.hkma.gov.hk/eng/key-functions/money/hong-kong-currency/notes/">Notes - HKMA</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://www.hkma.gov.hk/eng/key-functions/money/hong-kong-currency/coins/">Coins - HKMA</seealso></description></item>
/// </list>
/// </remarks>
public class TwdCurrency :
    ICurrency,
    ICashCountFormattable<TwdCurrency>,
    ICurrencyFormattable<TwdCurrency>
{
    private static readonly NumberFormatInfo _nfi = new()
    {
        CurrencySymbol = "$",
        CurrencyGroupSeparator = ",",
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 0,
    };

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.TWD;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 1m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } = new(
        Symbol: "TW$",
        NumberFormat: new NumberFormatInfo 
        { 
            CurrencySymbol = "TW$", 
            CurrencyGroupSeparator = ",", 
            CurrencyDecimalSeparator = ".", 
            CurrencyDecimalDigits = 0 
        },
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } = new(
        Symbol: "$",
        NumberFormat: _nfi,
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
        [
            // new SubsidiaryUnit(Name: "Cent", Symbol: "¢", Ratio: 0.01m),
        ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(1.00m, CashType.Coin, "1 Dollar Coin", "$1"),
        new(5.00m, CashType.Coin, "5 Dollar Coin", "$5"),
        new(10.00m, CashType.Coin, "10 Dollar Coin", "$10"),
        new(20.00m, CashType.Coin, "20 Dollar Coin", "$20"),
        new(50.00m, CashType.Coin, "50 Dollar Coin", "$50"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(100m, CashType.Bill, "100 Dollar Bill", "$100"),
        new(200m, CashType.Bill, "200 Dollar Bill", "$200"),
        new(500m, CashType.Bill, "500 Dollar Bill", "$500"),
        new(1000m, CashType.Bill, "1000 Dollar Bill", "$1000"),
        new(2000m, CashType.Bill, "2000 Dollar Bill", "$2000"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
