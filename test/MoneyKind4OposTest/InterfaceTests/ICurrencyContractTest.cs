using Shouldly;

namespace MoneyKind4OposTest.InterfaceTests;

/// <summary>ICurrency contract tests.</summary>
public class ICurrencyContractTest
{
    public static IEnumerable<object[]> AllCurrencies =>
        MoneyKind4OposTest
        .CurrencyTestHelper
        .GetAllCurrencyTypesAsXUnitData();

    /// <summary>Verifies that Coins property is not null for any ICurrency implementation.</summary>
    [Theory]
    [MemberData(nameof(AllCurrencies))]
    public void CoinsShouldNotBeNull(Type currencyType)
    {
        var coins = MoneyKind4OposTest.CurrencyTestHelper.GetCoins(currencyType);
        coins.ShouldNotBeNull();
    }

    /// <summary>Verifies that Bills property is not null for any ICurrency implementation.</summary>
    [Theory]
    [MemberData(nameof(AllCurrencies))]
    public void BillsShouldNotBeNull(Type currencyType)
    {
        var bills = MoneyKind4OposTest.CurrencyTestHelper.GetBills(currencyType);
        bills.ShouldNotBeNull();
    }

    /// <summary>Verifies that all defined coins for a currency have unique numeric values.</summary>
    [Theory]
    [MemberData(nameof(AllCurrencies))]
    public void CoinsShouldHaveUniqueValues(Type currencyType)
    {
        var coins = MoneyKind4OposTest.CurrencyTestHelper.GetCoins(currencyType);
        var values = coins.Select(c => c.Value).ToList();
        values.ShouldBeUnique();
    }

    /// <summary>Verifies that all defined bills for a currency have unique numeric values.</summary>
    [Theory]
    [MemberData(nameof(AllCurrencies))]
    public void BillsShouldHaveUniqueValues(Type currencyType)
    {
        var bills = MoneyKind4OposTest.CurrencyTestHelper.GetBills(currencyType);
        var values = bills.Select(b => b.Value).ToList();
        values.ShouldBeUnique();
    }

    /// <summary>Verifies that the minimum unit of any currency is a positive value.</summary>
    [Theory]
    [MemberData(nameof(AllCurrencies))]
    public void MinimumUnitShouldBePositive(Type currencyType)
    {
        var minimumUnit = MoneyKind4OposTest.CurrencyTestHelper.GetMinimumUnit(currencyType);
        minimumUnit.ShouldBeGreaterThan(0);
    }

    /// <summary>Verifies that the declared minimum unit matches the value of the smallest available denomination.</summary>
    [Theory]
    [MemberData(nameof(AllCurrencies))]
    public void MinimumUnitShouldMatchSmallestDenomination(Type currencyType)
    {
        var minimumUnit = MoneyKind4OposTest.CurrencyTestHelper.GetMinimumUnit(currencyType);
        var coins = MoneyKind4OposTest.CurrencyTestHelper.GetCoins(currencyType);
        var bills = MoneyKind4OposTest.CurrencyTestHelper.GetBills(currencyType);

        var all = coins.Concat(bills).ToList();
        if (all.Any())
        {
            var smallest = all.Min(c => c.Value);
            minimumUnit.ShouldBe(smallest);
        }
    }
}
