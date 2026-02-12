using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Chilean Peso Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills</term><description><seealso href="https://www.billetesymonedas.cl/Billetes/FamiliaBilletesActuales">Billetes y Monedas</seealso></description></item>
/// <item><term>Coins</term><description><seealso href="https://si2.bcentral.cl/public/publicaciones_digitales/memoriaanual2018/9-gestion-de-billetes/">9. GESTIÓN DE BILLETES Y MONEDAS</seealso></description></item>
/// </list>
/// </remarks>
public class ClpCurrency :
    ICurrency,
    ICashCountFormattable<ClpCurrency>,
    ICurrencyFormattable<ClpCurrency>
{
    private static readonly NumberFormatInfo _nfi = new()
    {
        CurrencySymbol = "$",
        CurrencyGroupSeparator = ",",
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 0,
    };

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.CLP;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 1m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } = new(
        Symbol: "CL$",
        NumberFormat: new NumberFormatInfo 
        { 
            CurrencySymbol = "CL$", 
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
            // new SubsidiaryUnit(Name: "Centavo", Symbol: "¢", Ratio: 0.01m),
        ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(1m, CashType.Coin, "$ 1 Coin", "$ 1", Usage: CashUsagePolicy.NonRecyclable),
        new(5m, CashType.Coin, "$ 5 Coin", "$ 5", Usage: CashUsagePolicy.NonRecyclable),
        new(10m, CashType.Coin, "$ 10 Coin", "$ 10"),
        new(50m, CashType.Coin, "$ 50 Coin", "$ 50"),
        new(100m, CashType.Coin, "$ 100 Coin", "$ 100"),
        new(500m, CashType.Coin, "$ 500 Coin", "$ 500"),
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(1000m, CashType.Bill, "$ 1000 Bill", "$ 1000"),
        new(2000m, CashType.Bill, "$ 2000 Bill", "$ 2000"),
        new(5000m, CashType.Bill, "$ 5000 Bill", "$ 5000"),
        new(10000m, CashType.Bill, "$ 10000 Bill", "$ 10000"),
        new(20000m, CashType.Bill, "$ 20000 Bill", "$ 20000", Usage: CashUsagePolicy.CollectionOnly),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
