using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Iraqi Dinar Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description>Banknotes (Central Bank of Iraq)</description></item>
/// </list>
/// </remarks>
public class IqdCurrency :
    ICurrency,
    ICashCountFormattable<IqdCurrency>,
    ICurrencyFormattable<IqdCurrency>
{
    private static readonly NumberFormatInfo _nfi = new()
    {
        CurrencySymbol = "د.ع",
        CurrencyPositivePattern = 2, // $ n
        CurrencyGroupSeparator = ",",
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 0,
    };

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.IQD;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 250.0m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } = new(
        Symbol: "IQD",
        NumberFormat: new NumberFormatInfo
        {
            CurrencySymbol = "IQD",
            CurrencyGroupSeparator = ",",
            CurrencyDecimalSeparator = ".",
            CurrencyDecimalDigits = 0
        },
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } = new(
        Symbol: "د.ع",
        NumberFormat: _nfi,
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Fils", null, 0.001m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins => [];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(250m, CashType.Bill, "250 Dinar Bill", "250 د.ع"),
        new(500m, CashType.Bill, "500 Dinar Bill", "500 د.ع"),
        new(1000m, CashType.Bill, "1000 Dinar Bill", "1000 د.ع"),
        new(5000m, CashType.Bill, "5000 Dinar Bill", "5000 د.ع"),
        new(10000m, CashType.Bill, "10000 Dinar Bill", "10000 د.ع"),
        new(25000m, CashType.Bill, "25000 Dinar Bill", "25000 د.ع"),
        new(50000m, CashType.Bill, "50000 Dinar Bill", "50000 د.ع"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
