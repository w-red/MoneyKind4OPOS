using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;
using System.Reflection;

namespace MoneyKind4OPOSTest.Currencies;

/// <summary>Sanity tests for all currency implementations.</summary>
public class CurrencySanityTest
{
    /// <summary>Verification that all SubsidiaryUnits are defined in descending order of Ratio.</summary>
    [Fact]
    public void AllCurrencies_SubsidiaryUnits_ShouldBeOrderedByRatioDescending()
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
    public void AllCurrencies_FormattingOptions_ShouldBeDefined()
    {
        var currencyTypes =
            typeof(ICurrency).Assembly
            .GetTypes()
            .Where(t => t.IsClass &&
                !t.IsAbstract &&
                typeof(ICurrency).IsAssignableFrom(t))
            // Only check those that are intended to be formattable (usually all our concrete currencies)
            .Where(t => t
                .GetInterfaces()
                .Any(i => i.IsGenericType &&
                    i.GetGenericTypeDefinition() ==
                    typeof(ICurrencyFormattable<>)))
            .ToList();

        foreach (var type in currencyTypes)
        {
            var globalProp =
                type
                .GetProperty(
                    "Global",
                    BindingFlags.Public | BindingFlags.Static);
            var localProp =
                type
                .GetProperty(
                    "Local",
                    BindingFlags.Public | BindingFlags.Static);

            globalProp
                .ShouldNotBeNull(
                    $"Currency {type.Name} is missing 'Global' formatting options.");
            localProp
                .ShouldNotBeNull($"Currency {type.Name} is missing 'Local' formatting options.");

            globalProp
                .GetValue(null)
                .ShouldNotBeNull($"Currency {type.Name} 'Global' options are null.");
            localProp
                .GetValue(null)
                .ShouldNotBeNull($"Currency {type.Name} 'Local' options are null.");
        }
    }
}
