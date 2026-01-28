using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using System.Reflection;

namespace MoneyKind4Opos.Currencies.Factories;

/// <summary>Factory for creating MoneyKind instances from OPOS device properties.</summary>
public static class MoneyKindFactory
{
    /// <summary>Cache for currency code to currency type mapping.</summary>
    private static readonly Lazy<Dictionary<string, Type>> _currencyTypeCache =
        new(BuildCurrencyTypeCache);

    /// <summary>Creates a MoneyKind instance from OPOS device properties.</summary>
    /// <param name="currencyCode">ISO 4217 currency code (e.g., "JPY", "AUD", "USD").</param>
    /// <param name="currencyCashList">
    /// Cash denominations supported by the device for the currency.
    /// Format: "coin1,coin2,...;bill1,bill2,..." (coins before semicolon, bills after).
    /// Example: "1,5,10,50,100,500;1000,5000,10000"
    /// </param>
    /// <param name="warnings">Warning messages for unsupported denominations.</param>
    /// <returns>A MoneyKind instance initialized with zero counts for supported denominations.</returns>
    /// <exception cref="ArgumentException">Thrown if the currency code is not supported.</exception>
    public static object CreateFromOpos(
        string currencyCode,
        string currencyCashList,
        out List<string> warnings)
    {
        warnings = [];

        var exMessage = "Currency code cannot be null or empty.";
        var exParams = nameof(currencyCode);

        // Validate input
        if (string.IsNullOrWhiteSpace(currencyCode))
        {
            throw new ArgumentException(
                exMessage, exParams);
        }

        exMessage = $"Currency code '{currencyCode}' is not supported.";
        // Retrieve the currency type for the given code
        var currencyType =
            GetCurrencyType(currencyCode) ??
                throw new ArgumentException(
                        exMessage, exParams);

        // Parse the CurrencyCashList
        var (coins, bills) =
            ParseCurrencyCashList(currencyCashList);

        // Create the MoneyKind instance using reflection
        return CreateMoneyKindInstance(currencyType, coins, bills, out warnings);
    }

    /// <summary>Creates a MoneyKind instance with generic type parameter.</summary>
    public static MoneyKind<TCurrency> CreateFromOpos<TCurrency>(
        string currencyCashList,
        out List<string> warnings)
        where TCurrency : ICurrency, ICashCountFormattable<TCurrency>, ICurrencyFormattable<TCurrency>
    {
        var (coins, bills) = ParseCurrencyCashList(currencyCashList);
        var mk = new MoneyKind<TCurrency>();

        // Validate and initialize with supported denominations
        ValidateAndInitializeFromDenominations(mk, coins, bills, out warnings);

        return mk;
    }

    /// <summary>Builds a cache of currency code to type mappings by scanning the assembly.</summary>
    private static Dictionary<string, Type> BuildCurrencyTypeCache()
    {
        var cache = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);

        // Find all types that implement ICurrency
        var currencyTypes =
            AppDomain
            .CurrentDomain
            .GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(
                t => 
                    typeof(ICurrency).IsAssignableFrom(t)
                    && !t.IsInterface
                    && !t.IsAbstract);

        foreach (var type in currencyTypes)
        {
            // Get the Code property
            var codeProperty = type
                .GetProperty(
                "Code",
                BindingFlags.Public |
                BindingFlags.Static);

            if (codeProperty?.GetGetMethod() is not null)
            {
                try
                {
                    if (codeProperty.GetValue(null) is Iso4217 code)
                    {
                        cache[code.ToString()] = type;
                    }
                }
                catch
                {
                    // Skip types that fail to retrieve the code
                }
            }
        }

        return cache;
    }

    /// <summary>Retrieves the currency type for the given ISO 4217 code.</summary>
    private static Type? GetCurrencyType(string currencyCode)
    {
        var cache = _currencyTypeCache.Value;
        return cache
            .TryGetValue(currencyCode, out var type) 
            ? type : null;
    }

    /// <summary>
    /// Parses the CurrencyCashList string into coin and bill denominations.
    /// </summary>
    /// <returns>
    /// A tuple containing:
    /// <list type="bullet">
    /// <item>coins<term></term><description>List of coin denominations</description></item>
    /// <item>bills<term></term><description>List of bill denominations</description></item>
    /// </list>
    /// </returns>
    private static (List<decimal> coins, List<decimal> bills) ParseCurrencyCashList(
        string currencyCashList)
    {
        if (string.IsNullOrWhiteSpace(currencyCashList))
        {
            return ([], []);
        }

        var sections = currencyCashList.Split(';');

        return sections switch
        {
            [var coinSec, var billSec, ..] =>
                (ParseDenominationSection(coinSec),
                 ParseDenominationSection(billSec)),
            [var coinSec] =>
                (ParseDenominationSection(coinSec),
                 []),
            _ => ([], [])
        };
    }

    /// <summary>
    /// Parses a denomination section string into a list of decimal values using LINQ.
    /// Filters out values that cannot be parsed as decimals.
    /// </summary>
    /// <param name="section">The section string containing comma-separated values.</param>
    /// <returns>List of successfully parsed decimal values.</returns>
    private static List<decimal> ParseDenominationSection(string section) =>
        [.. section
            .Split(',',
                StringSplitOptions.RemoveEmptyEntries
                | StringSplitOptions.TrimEntries)
            .Select(s => (success: decimal.TryParse(s, out var value), value))
            .Where(x => x.success)
            .Select(x => x.value)];

    /// <summary>Creates a MoneyKind instance using reflection.</summary>
    private static object CreateMoneyKindInstance(
        Type currencyType,
        List<decimal> coins,
        List<decimal> bills,
        out List<string> warnings)
    {
        warnings = [];

        // Construct the generic type MoneyKind<TCurrency>
        var moneyKindType = typeof(MoneyKind<>).MakeGenericType(currencyType);
        var instance =
            Activator
            .CreateInstance(moneyKindType) ??
                throw new InvalidOperationException(
                    $"Failed to create MoneyKind<{currencyType.Name}>.");

        // Get the Counts property
        var countsProperty =
            moneyKindType.GetProperty("Counts");
        if (countsProperty?.GetGetMethod() is null)
        {
            throw new InvalidOperationException(
                "Cannot access Counts property.");
        }

        var counts = (IDictionary<CashFaceInfo, int>?)countsProperty
            .GetValue(instance);
        if (counts is null)
        {
            return instance;
        }

        // Validate and initialize counts
        ValidateAndInitializeFromDenominations(
            instance, coins, bills, out warnings);

        return instance;
    }

    /// <summary>Validates denominations against supported faces and initializes counts.</summary>
    /// <param name="warnings">Unsupported denominations generate warnings.</param>
    private static void ValidateAndInitializeFromDenominations(
        object moneyKindInstance,
        List<decimal> coins,
        List<decimal> bills,
        out List<string> warnings)
    {
        warnings = [];

        var instanceType = moneyKindInstance.GetType();
        var countsProperty = instanceType.GetProperty("Counts");
        var isValidFaceValueMethod = instanceType.GetMethod("IsValidFaceValue");

        if (countsProperty?.GetGetMethod() is null ||
            isValidFaceValueMethod is null)
        {
            return;
        }

        var counts = (IDictionary<CashFaceInfo, int>?)countsProperty
            .GetValue(moneyKindInstance);
        if (counts is null)
        {
            return;
        }

        // Validate coins
        foreach (var coin in coins)
        {
            var isValid =
                (bool?)isValidFaceValueMethod
                .Invoke(moneyKindInstance, [coin]) 
                ?? false;
            if (!isValid)
            {
                warnings
                    .Add($"Coin denomination {coin} is not supported by this currency.");
            }
        }

        // Validate bills
        foreach (var bill in bills)
        {
            var isValid = (bool?)isValidFaceValueMethod
                .Invoke(moneyKindInstance, [bill])
                ?? false;
            if (!isValid)
            {
                warnings.Add($"Bill denomination {bill} is not supported by this currency.");
            }
        }
    }
}