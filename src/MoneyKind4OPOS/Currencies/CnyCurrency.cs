using MoneyKind4Opos.Codes;

namespace MoneyKind4Opos.Currencies;

/// <summary>Chinese Yuan Currency</summary>
public class CnyCurrency : ICurrency
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.CNY;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 0.01m;
    /// <inheritdoc/>
    public static string Symbol => "¥";
    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Fen", "分", 0.01m),
        new SubsidiaryUnit("Jiao", "角", 0.10m),
    ];

    /// <inheritdoc/>
    public static CurrencyDisplayFormat DisplayFormat => new(
        Placement: SymbolPlacement.Prefix,
        DecimalZeroReplacement: "."
    );

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "1 Fen Coin", "1分硬币"),
        new(0.02m, CashType.Coin, "2 Fen Coin", "2分硬币"),
        new(0.05m, CashType.Coin, "2 Fen Coin", "5分硬币"),
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
}
