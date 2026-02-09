using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Somali Shilling (SOS).</summary>
public sealed class SosCurrency : ICurrency, ICashCountFormattable<SosCurrency>, ICurrencyFormattable<SosCurrency>
{
    private SosCurrency() { }

    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.SOS;

    /// <inheritdoc/>
    public static decimal MinimumUnit => 1000m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("Sh.So.", "n $", decimalDigits: 2);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local => Global;

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Sente", "c", 0.01m)
    ];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins => [];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new CashFaceInfo(1000m, CashType.Bill, "1000 Shilling Bill", "1000 Shilin Soomaali")
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => true;
}
