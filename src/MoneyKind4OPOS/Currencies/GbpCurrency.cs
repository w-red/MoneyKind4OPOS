using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>British Pound Sterling Currency</summary>
/// <seealso href="https://www.acbi.org.uk/banknotes/scottish-banknotes.html">Scottish Banknotes (Association of Commercial Banknote Issuers)</seealso>
public class GbpCurrency : ICurrency, ICashCountFormattable<GbpCurrency>, ICurrencyFormattable<GbpCurrency>
{
    private static readonly NumberFormatInfo _nfi = new()
    {
        CurrencySymbol = "£",
        CurrencyPositivePattern = 0, // $n
        CurrencyGroupSeparator = ",",
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 2,
    };

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.GBP;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } = new(
        Symbol: "£",
        NumberFormat: _nfi,
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Penny", "p", 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "1 Penny Coin", "1p"),
        new(0.02m, CashType.Coin, "2 Pence Coin", "2p"),
        new(0.05m, CashType.Coin, "5 Pence Coin", "5p"),
        new(0.10m, CashType.Coin, "10 Pence Coin", "10p"),
        new(0.20m, CashType.Coin, "20 Pence Coin", "20p"),
        new(0.50m, CashType.Coin, "50 Pence Coin", "50p"),
        new(1.00m, CashType.Coin, "1 Pound Coin", "£1"),
        new(2.00m, CashType.Coin, "2 Pounds Coin", "£2"),
    ];
    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(5.00m, CashType.Bill, "5 Pounds Bill", "£5"),
        new(10.00m, CashType.Bill, "10 Pounds Bill", "£10"),
        new(20.00m, CashType.Bill, "20 Pounds Bill", "£20"),
        new(50.00m, CashType.Bill, "50 Pounds Bill", "£50"),
        new(100.00m, CashType.Bill, "100 Pounds Bill", "£100"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
