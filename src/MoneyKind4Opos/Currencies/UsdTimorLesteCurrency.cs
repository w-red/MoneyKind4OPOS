using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>US Dollar for Timor-Leste (with local Centavo coins)</summary>
/// <remarks>
/// <para>
/// Timor-Leste uses the US Dollar as its official currency, but issues its own fractional coins (Centavos) 
/// which are used alongside US Dollar banknotes.
/// </para>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://www.bancocentral.tl/en/currency/coins">BCTL</seealso></description></item>
/// </list>
/// </remarks>
public class UsdTimorLesteCurrency :
    UsdCurrency,
    ICashCountFormattable<UsdTimorLesteCurrency>,
    ICurrencyFormattable<UsdTimorLesteCurrency>
{
    // Explicitly redefine or delegate static members to ensure they are visible to reflection
    // and satisfy the static abstract interface requirements on this specific type.

    /// <inheritdoc/>
    public new static Iso4217 Code => UsdCurrency.Code;

    /// <inheritdoc/>
    public new static decimal MinimumUnit => UsdCurrency.MinimumUnit;

    /// <inheritdoc/>
    public new static bool IsZeroPadding => UsdCurrency.IsZeroPadding;

    /// <inheritdoc/>
    public new static IEnumerable<CashFaceInfo> Bills => UsdCurrency.Bills;

    /// <inheritdoc/>
    public new static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("US$", "n $"); // Based on pt-TL discovery: "1 234 567,89 US$"

    /// <inheritdoc/>
    public new static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("$", "$n"); // Based on tet-TL discovery: "$1,234,567.89"

    /// <inheritdoc/>
    public new static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits =>
    [
        new SubsidiaryUnit("Centavo", "¢", 0.01m),
    ];

    /// <inheritdoc/>
    public new static IEnumerable<CashFaceInfo> Coins =>
    [
        new(0.01m, CashType.Coin, "1 Centavo", "1c"),
        new(0.05m, CashType.Coin, "5 Centavos", "5c"),
        new(0.10m, CashType.Coin, "10 Centavos", "10c"),
        new(0.25m, CashType.Coin, "25 Centavos", "25c"),
        new(0.50m, CashType.Coin, "50 Centavos", "50c"),
        new(1.00m, CashType.Coin, "100 Centavos", "100c"), 
        new(2.00m, CashType.Coin, "200 Centavos", "200c"),
    ];
}
