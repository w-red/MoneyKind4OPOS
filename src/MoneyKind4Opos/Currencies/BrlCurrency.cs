using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Brazilian Real Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.bcb.gov.br/en/banknotesandcoins/firstseriesreal">Banknotes - BCB</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://www.bcb.gov.br/dinheirobrasileiro/en/segunda-familia-moedas.html">Coins - BCB</seealso></description></item>
/// <item><term>Other</term><description><seealso href="https://www.bcb.gov.br/ingles/Mecir/cedulas/cedcomum.asp?frame=1">About BRL - BCB</seealso></description></item>
/// </list>
/// </remarks>
public class BrlCurrency :
    ICurrency,
    ICashCountFormattable<BrlCurrency>,
    ICurrencyFormattable<BrlCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.BRL;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.010m;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Centavo", "¢", 0.010m),
    ];

    private static readonly NumberFormatInfo _nfi = new()
    {
        CurrencySymbol = "R$",
        CurrencyPositivePattern = 1, // $ n
        CurrencyGroupSeparator = ",",
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 2,
    };

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        new(
            Symbol: "R$",
            NumberFormat: _nfi,
            DisplayFormat: new(SymbolPlacement.Prefix)
        );

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "1 ¢ Coin", "1¢"),
        new(0.05m, CashType.Coin, "5 ¢ Coin", "5¢"),
        new(0.1m, CashType.Coin, "10 ¢ Coin", "10¢"),
        new(0.25m, CashType.Coin, "25 ¢ Coin", "25¢"),
        new(0.5m, CashType.Coin, "50 ¢ Coin", "50¢"),
        new(1m, CashType.Coin, "R$ 1 Coin", "R$ 1"),
    ];
    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1.0m, CashType.Bill, "R$ 1 Bill", "R$ 1"),
        new(2.0m, CashType.Bill, "R$ 2 Bill", "R$ 2"),
        new(5.0m, CashType.Bill, "R$ 5 Bill", "R$ 5"),
        new(10.0m, CashType.Bill, "R$ 10 Bill", "R$ 10"),
        new(20.0m, CashType.Bill, "R$ 20 Bill", "R$ 20"),
        new(50.0m, CashType.Bill, "R$ 50 Bill", "R$ 50"),
        new(100.0m, CashType.Bill, "R$ 100 Bill", "R$ 100"),
        new(200.0m, CashType.Bill, "R$ 200 Bill", "R$ 200"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
