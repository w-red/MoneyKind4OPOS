using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Currencies;

/// <summary>Cambodian Riel Currency</summary>
/// <remarks>
/// <list type="bullet">
/// <item><term>Bills and Coins</term><description><seealso href="https://www.nbc.gov.kh/english/currency/banknotes_in_circulation.php">Banknotes in Circulation (National Bank of Cambodia)</seealso></description></item>
/// </list>
/// </remarks>
public class KhrCurrency :
    ICurrency,
    ICashCountFormattable<KhrCurrency>,
    ICurrencyFormattable<KhrCurrency>
{
    /// <inheritdoc/>
    public static Iso4217 Code => Iso4217.KHR;
    /// <inheritdoc/>
    public static decimal MinimumUnit => 50m;

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Global { get; } =
        CurrencyFormattingOptions.Create("៛", "$n", decimalDigits: 0);

    /// <inheritdoc/>
    public static CurrencyFormattingOptions Local { get; } =
        CurrencyFormattingOptions.Create("៛", "$n", decimalDigits: 0);

    /// <inheritdoc/>
    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits => [];

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Coins => []; // effectively not in circulation

    /// <inheritdoc/>
    public static IEnumerable<CashFaceInfo> Bills =>
    [
        new(50m, CashType.Bill, "50 Riel Bill", "៥០ រៀល"),
        new(100m, CashType.Bill, "100 Riel Bill", "១០០ រៀល"),
        new(200m, CashType.Bill, "200 Riel Bill", "២០០ រៀល"),
        new(500m, CashType.Bill, "500 Riel Bill", "៥០០ រៀល"),
        new(1000m, CashType.Bill, "1000 Riel Bill", "១០០០ រៀល"),
        new(2000m, CashType.Bill, "2000 Riel Bill", "២០០០ រៀល"),
        new(5000m, CashType.Bill, "5000 Riel Bill", "៥០០០ រៀល"),
        new(10000m, CashType.Bill, "10000 Riel Bill", "១០០០០ រៀល"),
        new(15000m, CashType.Bill, "15000 Riel Bill", "១៥០០០ រៀល"),
        new(20000m, CashType.Bill, "20000 Riel Bill", "២០០០០ រៀល"),
        new(30000m, CashType.Bill, "30000 Riel Bill", "៣០០០០ រៀល"),
        new(50000m, CashType.Bill, "50000 Riel Bill", "៥០០០០ រៀល"),
        new(100000m, CashType.Bill, "100000 Riel Bill", "១០០០០០ រៀល"),
    ];

    /// <inheritdoc/>
    public static bool IsZeroPadding => false;
}
