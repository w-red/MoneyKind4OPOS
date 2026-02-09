using MoneyKind4Opos.Currencies.Interfaces;
using System.Reflection;

namespace MoneyKind4OposTest;

/// <summary>Helper for accessing currency metadata via reflection in tests.</summary>
public static class CurrencyTestHelper
{
    /// <summary>Gets the coin denominations for the specified currency type.</summary>
    public static IEnumerable<CashFaceInfo> GetCoins(Type currencyType) =>
        GetStaticProperty<IEnumerable<CashFaceInfo>>(currencyType, "Coins");

    /// <summary>Gets the bill denominations for the specified currency type.</summary>
    public static IEnumerable<CashFaceInfo> GetBills(Type currencyType) =>
        GetStaticProperty<IEnumerable<CashFaceInfo>>(currencyType, "Bills");

    /// <summary>Gets the minimum unit for the specified currency type.</summary>
    public static decimal GetMinimumUnit(Type currencyType) =>
        GetStaticProperty<decimal>(currencyType, "MinimumUnit");

    /// <summary>Gets the static property value of the specified type and property name.</summary>
    private static T GetStaticProperty<T>(Type type, string propertyName)
    {
        var currentType = type;
        while (currentType != null && currentType != typeof(object))
        {
            var prop = currentType.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
            if (prop != null)
            {
                return (T)prop.GetValue(null)!;
            }
            currentType = currentType.BaseType;
        }

        throw new ArgumentException($"Property {propertyName} not found on {type.Name} or its base types.");
    }

    /// <summary>Gets all concrete currency types in the assembly for DataDriven testing.</summary>
    public static IEnumerable<object[]> GetAllCurrencyTypesAsXUnitData()
    {
        return typeof(ICurrency).Assembly.GetTypes()
            .Where(t =>
                t.IsClass
                && !t.IsAbstract
                && typeof(ICurrency)
                    .IsAssignableFrom(t))
            .Select(t => new object[] { t });
    }
}
