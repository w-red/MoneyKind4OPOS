using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;VedCurrency&gt; tests for extreme minimum unit (5.0).</summary>
public class MoneyKindVedTest
{
    /// <summary>Verifies that the extreme minimum unit of 5 bolivares is handled correctly.</summary>
    [Fact]
    public void CalculateChangeVedShouldHandleMinimumUnitOfFive()
    {
        // VED has an extreme MinimumUnit of 5.0 due to hyperinflation
        var inventory = new MoneyKind<VedCurrency>();
        inventory[5m] = 10;   // 5 bolivar bills
        inventory[10m] = 10;  // 10 bolivar bills
        inventory[20m] = 5;   // 20 bolivar bills

        // Pay 35 bolivares
        var result = inventory.CalculateChangeDetail(35m);

        // Analysis (greedy):
        // 1. Takes 20 x 1 = 20 (Remaining 15)
        // 2. Takes 10 x 1 = 10 (Remaining 5)
        // 3. Takes 5 x 1 = 5 (Remaining 0)
        result.IsSucceed.ShouldBeTrue();
        result.PayableChange[20m].ShouldBe(1);
        result.PayableChange[10m].ShouldBe(1);
        result.PayableChange[5m].ShouldBe(1);
        result.PayableChange.TotalAmount().ShouldBe(35m);
        result.RemainingAmount.ShouldBe(0m);
    }

    /// <summary>Verifies that amounts not divisible by 5 cannot be paid exactly.</summary>
    [Fact]
    public void CalculateChangeVedShouldFailForAmountsNotDivisibleByFive()
    {
        var inventory = new MoneyKind<VedCurrency>();
        inventory[5m] = 10;
        inventory[10m] = 10;

        // Try to pay 17 bolivares (not divisible by 5)
        var result = inventory.CalculateChangeDetail(17m);

        // Analysis:
        // 1. Takes 10 x 1 = 10 (Remaining 7)
        // 2. Takes 5 x 1 = 5 (Remaining 2)
        // 3. Cannot pay 2 (below minimum unit)
        result.IsSucceed.ShouldBeFalse();
        result.PayableChange[10m].ShouldBe(1);
        result.PayableChange[5m].ShouldBe(1);
        result.PayableChange.TotalAmount().ShouldBe(15m);
        result.RemainingAmount.ShouldBe(2m);
    }

    /// <summary>Verifies the extreme 5.0 minimum unit for VED.</summary>
    [Fact]
    public void VedMinimumUnitShouldBeFive()
    {
        VedCurrency.MinimumUnit.ShouldBe(5.0m);
    }

    /// <summary>Verifies that VED has no circulating coins due to hyperinflation.</summary>
    [Fact]
    public void VedShouldHaveNoCirculatingCoins()
    {
        var coins = VedCurrency.Coins.ToList();
        coins.Count.ShouldBe(0);
    }

    /// <summary>Verifies large denomination bills for hyperinflation currency.</summary>
    [Fact]
    public void VedShouldIncludeLargeBillDenominations()
    {
        var mk = new MoneyKind<VedCurrency>();
        
        // Should include 200 and 500 bolivar bills (added in 2024)
        mk[200m] = 5;
        mk[500m] = 5;
        mk[200m].ShouldBe(5);
        mk[500m].ShouldBe(5);
    }
}
