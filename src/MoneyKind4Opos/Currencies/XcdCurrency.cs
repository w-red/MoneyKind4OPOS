using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Eastern Caribbean Dollar</summary>
/// <seealso href="https://www.eccb-centralbank.org/it-s-here-the-new-family-of-ec-polymer-notes">Banknotes (Eastern Caribbean Central Bank)</seealso>
public class XcdCurrency :
    ICurrency,
    ICashCountFormattable<XcdCurrency>,
    ICurrencyFormattable<XcdCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.XCD;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.05m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("EC$", "$n");

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("$", "$n");

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits => [];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.05m, CashType.Coin, "5 Cents", "5¢"),
        new(0.10m, CashType.Coin, "10 Cents", "10¢"),
        new(0.25m, CashType.Coin, "25 Cents", "25¢"),
        new(1.00m, CashType.Coin, "1 Dollar", "$1"),
    ];

    /// <inheritdoc/>
    /// <remarks>
    /// Denominations are based on the polymer series.
    /// Reference: https://www.eccb-centralbank.org/p/polymer-banknotes-1
    /// </remarks>
    /// <seealso href="https://www.eccb-centralbank.org/p/polymer-banknotes-1">Polymer Banknotes (Eastern Caribbean Central Bank)</seealso>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(5m, CashType.Bill, "5 Dollars", "$5"),
        new(10m, CashType.Bill, "10 Dollars", "$10"),
        new(20m, CashType.Bill, "20 Dollars", "$20"),
        new(50m, CashType.Bill, "50 Dollars", "$50"),
        new(100m, CashType.Bill, "100 Dollars", "$100"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
