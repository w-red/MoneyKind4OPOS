using Shouldly;

namespace MoneyKind4OposTest.InterfaceTests;

/// <summary>ICurrency contract tests.</summary>
public class ICurrencyContractTest
{
    public static IEnumerable<object[]> AllCurrencies =>
        MoneyKind4OposTest
        .CurrencyTestHelper
        .GetAllCurrencyTypesAsXUnitData();

    [Theory]
    [MemberData(nameof(AllCurrencies))]
    public void Coins_ShouldNotBeNull(Type currencyType)
    {
        var coins = MoneyKind4OposTest.CurrencyTestHelper.GetCoins(currencyType);
        coins.ShouldNotBeNull();
    }

    [Theory]
    [MemberData(nameof(AllCurrencies))]
    public void Bills_ShouldNotBeNull(Type currencyType)
    {
        var bills = MoneyKind4OposTest.CurrencyTestHelper.GetBills(currencyType);
        bills.ShouldNotBeNull();
    }

    [Theory]
    [MemberData(nameof(AllCurrencies))]
    public void Coins_ShouldHaveUniqueValues(Type currencyType)
    {
        var coins = MoneyKind4OposTest.CurrencyTestHelper.GetCoins(currencyType);
        var values = coins.Select(c => c.Value).ToList();
        values.ShouldBeUnique();
    }

    [Theory]
    [MemberData(nameof(AllCurrencies))]
    public void Bills_ShouldHaveUniqueValues(Type currencyType)
    {
        var bills = MoneyKind4OposTest.CurrencyTestHelper.GetBills(currencyType);
        var values = bills.Select(b => b.Value).ToList();
        values.ShouldBeUnique();
    }

    [Theory]
    [MemberData(nameof(AllCurrencies))]
    public void MinimumUnit_ShouldBePositive(Type currencyType)
    {
        var minimumUnit = MoneyKind4OposTest.CurrencyTestHelper.GetMinimumUnit(currencyType);
        minimumUnit.ShouldBeGreaterThan(0);
    }

    [Theory]
    [MemberData(nameof(AllCurrencies))]
    public void MinimumUnit_ShouldMatchSmallestDenomination(Type currencyType)
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
