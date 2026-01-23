using MoneyKind4Opos.Currencies.Interfaces;
using System.Reflection;

namespace MoneyKind4OposTest;

/// <summary>Helper for accessing currency metadata via reflection in tests.</summary>
public static class CurrencyTestHelper
{
    public static IEnumerable<CashFaceInfo> GetCoins(Type currencyType) =>
        GetStaticProperty<IEnumerable<CashFaceInfo>>(currencyType, "Coins");

    public static IEnumerable<CashFaceInfo> GetBills(Type currencyType) =>
        GetStaticProperty<IEnumerable<CashFaceInfo>>(currencyType, "Bills");

    public static decimal GetMinimumUnit(Type currencyType) =>
        GetStaticProperty<decimal>(currencyType, "MinimumUnit");

    private static T GetStaticProperty<T>(Type type, string propertyName)
    {
        var prop = type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Static);
        if (prop == null) throw new ArgumentException($"Property {propertyName} not found on {type.Name}");
        return (T)prop.GetValue(null)!;
    }

    /// <summary>Gets all concrete currency types in the assembly for DataDriven testing.</summary>
    public static IEnumerable<object[]> GetAllCurrencyTypesAsXUnitData()
    {
        return typeof(ICurrency).Assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && typeof(ICurrency).IsAssignableFrom(t))
            .Select(t => new object[] { t });
    }
}
