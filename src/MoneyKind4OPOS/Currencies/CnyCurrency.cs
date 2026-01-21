using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Chinese Yuan Currency</summary>
public class CnyCurrency :
    ICurrency,
    ICashCountFormattable<CnyCurrency>,
    ICurrencyFormattable<CnyCurrency>
{
    private static readonly NumberFormatInfo _globalNfi = new()
    {
        CurrencySymbol = "¥",
        CurrencyPositivePattern = 0,
        CurrencyGroupSeparator = ",",
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 2,
    };

    private static readonly NumberFormatInfo _localNfi = new()
    {
        CurrencySymbol = "元",
        CurrencyPositivePattern = 1,
        CurrencyGroupSeparator = ",",
        CurrencyDecimalSeparator = ".",
        CurrencyDecimalDigits = 2,
    };

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.CNY;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } = new(
        Symbol: "¥",
        NumberFormat: _globalNfi,
        DisplayFormat: new(SymbolPlacement.Prefix)
    );

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } = new(
        Symbol: "元",
        NumberFormat: _localNfi,
        DisplayFormat: new(SymbolPlacement.Postfix),
        CustomFormatter: amount =>
        {
            // Special formatting for amounts less than 1 Yuan
            if (amount is > 0 and < 1.0m)
            {
                var remaining = amount;
                var result = "";
                foreach (var unit in SubsidiaryUnits)
                {
                    var count = (int)(remaining / unit.Ratio);
                    if (count > 0)
                    {
                        result += $"{count}{unit.Symbol}";
                        remaining -= count * unit.Ratio;
                        remaining = 
                            Math.Round(
                                remaining,
                                _localNfi.CurrencyDecimalDigits);
                    }
                }

                if (!string.IsNullOrEmpty(result))
                {
                    return result;
                }
            }

            // normal formatting for 1 Yuan and above, or 0 Yuan, or tiny values
            return amount.ToString("C", _localNfi);
        }
    );

    private static readonly ISubsidiaryUnit[] _subsidiaryUnits =
    [
        new SubsidiaryUnit("Jiao", "角", 0.10m),
        new SubsidiaryUnit("Fen", "分", 0.01m),
    ];

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits => _subsidiaryUnits;

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "1 Fen Coin", "1分硬币"),
        new(0.02m, CashType.Coin, "2 Fen Coin", "2分硬币"),
        new(0.05m, CashType.Coin, "5 Fen Coin", "5分硬币"),
        new(0.10m, CashType.Coin, "1 Jiao Coin", "1角硬币"),
        new(0.20m, CashType.Coin, "2 Jiao Coin", "2角硬币"),
        new(0.50m, CashType.Coin, "5 Jiao Coin", "5角硬币"),
        new(1.00m, CashType.Coin, "1 Yuan Coin", "1元硬币"),
    ];
    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(0.10m, CashType.Bill, "1 Jiao Bill", "1角券"),
        new(0.50m, CashType.Bill, "5 Jiao Bill", "5角券"),
        new(1.00m, CashType.Bill, "1 Yuan Bill", "1元券"),
        new(5.00m, CashType.Bill, "5 Yuan Bill", "5元券"),
        new(10.00m, CashType.Bill, "10 Yuan Bill", "10元券"),
        new(20.00m, CashType.Bill, "20 Yuan Bill", "20元券"),
        new(50.00m, CashType.Bill, "50 Yuan Bill", "50元券"),
        new(100.00m, CashType.Bill, "100 Yuan Bill", "100元券"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
