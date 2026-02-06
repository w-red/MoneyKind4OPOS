using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;
using System.Reflection;

namespace MoneyKind4OposTest.Currencies;

/// <summary>Sanity tests for all currency implementations.</summary>
public class CurrencySanityTest
{
    /// <summary>Verification that all SubsidiaryUnits are defined in descending order of Ratio.</summary>
    [Fact]
    public void AllCurrenciesSubsidiaryUnitsShouldBeOrderedByRatioDescending()
    {
        var currencyTypes =
            typeof(ICurrency).Assembly
            .GetTypes()
            .Where(t => t.IsClass &&
                !t.IsAbstract &&
                typeof(ICurrency).IsAssignableFrom(t))
            .ToList();

        currencyTypes.ShouldNotBeEmpty();

        foreach (var type in currencyTypes)
        {
            // Get the static SubsidiaryUnits property via reflection
            var prop = type
                .GetProperty(nameof(ICurrency.SubsidiaryUnits),
                    BindingFlags.Public | BindingFlags.Static);
            if (prop == null) continue;

            var units =
                (prop.GetValue(null) as IEnumerable<ISubsidiaryUnit>)?
                .ToList();

            if (units != null && units.Count > 1)
            {
                var ratios =
                    units
                    .Select(u => u.Ratio).ToList();
                var sortedRatios =
                    ratios
                    .OrderByDescending(r => r).ToList();

                ratios
                    .ShouldBe(sortedRatios,
                    $"Currency {type.Name} has SubsidiaryUnits in incorrect order. Expected descending Ratio.");
            }
        }
    }

    /// <summary>Verification that all currency formatting options (Global and Local) are defined.</summary>
    [Fact]
    public void AllCurrenciesFormattingOptionsShouldBeDefined()
    {
        var currencyTypes = GetAllCurrencyTypes();

        foreach (var type in currencyTypes)
        {
            var globalProp = type
                .GetProperty(
                    "Global",
                    BindingFlags.Public
                    | BindingFlags.Static);
            var localProp = type
                .GetProperty(
                    "Local",
                    BindingFlags.Public
                    | BindingFlags.Static);

            globalProp
                .ShouldNotBeNull(
                    $"Currency {type.Name} is missing 'Global' formatting options.");
            localProp
                .ShouldNotBeNull(
                    $"Currency {type.Name} is missing 'Local' formatting options.");

            globalProp
                .GetValue(null)
                .ShouldNotBeNull($"Currency {type.Name} 'Global' options are null.");
            localProp
                .GetValue(null)
                .ShouldNotBeNull($"Currency {type.Name} 'Local' options are null.");
        }
    }

    /// <summary>Verification that Parse and TotalAmount work for all registered denominations for every currency.</summary>
    [Fact]
    public void AllCurrenciesParseAndTotalAmountShouldBeConsistent()
    {
        var currencyTypes = GetAllCurrencyTypes();

        foreach (var type in currencyTypes)
        {
            var coins = MoneyKind4OposTest.CurrencyTestHelper.GetCoins(type).ToList();
            var bills = MoneyKind4OposTest.CurrencyTestHelper.GetBills(type).ToList();
            var all = coins.Concat(bills).ToList();

            if (!all.Any()) continue;

            // Construct a string: coin1:1,coin2:1;bill1:1,bill2:1
            var coinPart = string.Join(",", coins.Select(c => $"{c.Value:G29}:1"));
            var billPart = string.Join(",", bills.Select(b => $"{b.Value:G29}:1"));
            var input = $"{coinPart};{billPart}";

            // Dynamically call MoneyKind<T>.Parse(input)
            var moneyKindType = typeof(MoneyKind4Opos.Currencies.Interfaces.MoneyKind<>).MakeGenericType(type);
            var parseMethod = moneyKindType.GetMethod("Parse", BindingFlags.Public | BindingFlags.Static);
            var mk = parseMethod!.Invoke(null, [input]);

            // Dynamically call mk.TotalAmount()
            var totalAmountMethod = moneyKindType.GetMethod("TotalAmount");
            var actualTotal = (decimal)totalAmountMethod!.Invoke(mk, null)!;

            var expectedTotal = all.Sum(a => a.Value);
            actualTotal.ShouldBe(expectedTotal, $"Currency {type.Name} failed TotalAmount verification for all denominations.");

            // Verify Round-trip
            var toCashCountsStringMethod = moneyKindType.GetMethod("ToCashCountsString", [typeof(string), typeof(string)]);
            var output = (string)toCashCountsStringMethod!.Invoke(mk, [null, null])!;

            // Verify the output can be parsed back and gives the same result
            var mk2 = parseMethod.Invoke(null, [output]);
            var actualTotal2 = (decimal)totalAmountMethod.Invoke(mk2, null)!;
            actualTotal2.ShouldBe(expectedTotal, $"Currency {type.Name} failed Round-trip verification.");
        }
    }

    private static List<Type> GetAllCurrencyTypes()
    {
        return [..
            typeof(ICurrency).Assembly
            .GetTypes()
            .Where(t => t.IsClass &&
                !t.IsAbstract &&
                typeof(ICurrency).IsAssignableFrom(t))
        ];
    }
}
