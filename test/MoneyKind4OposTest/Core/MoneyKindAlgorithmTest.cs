using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Core;

/// <summary>Tests for core MoneyKind algorithms including addition, subtraction, and greedy change calculation.</summary>
public class MoneyKindAlgorithmTest
{
    /// <summary>Verifies that adding one MoneyKind to another correctly accumulates denomination counts.</summary>
    [Fact]
    public void AddShouldAccumulateCounts()
    {
        var inventory = new MoneyKind<JpyCurrency>();
        var deposit = new MoneyKind<JpyCurrency>();

        inventory[1000] = 5;
        deposit[1000] = 2;
        deposit[500] = 3;

        inventory.Add(deposit);

        inventory[1000].ShouldBe(7);
        inventory[500].ShouldBe(3);
        inventory.TotalAmount().ShouldBe(8500m);
    }

    /// <summary>Verifies that subtracting one MoneyKind from another correctly reduces denomination counts.</summary>
    [Fact]
    public void SubtractShouldReduceCounts()
    {
        var inventory = new MoneyKind<JpyCurrency>();
        var dispense = new MoneyKind<JpyCurrency>();

        inventory[1000] = 10;
        dispense[1000] = 3;

        inventory.Subtract(dispense);

        inventory[1000].ShouldBe(7);
    }

    /// <summary>Verifies that subtracting more than available inventory throws an InvalidOperationException.</summary>
    [Fact]
    public void SubtractInsufficientInventoryShouldThrow()
    {
        var inventory = new MoneyKind<JpyCurrency>();
        var dispense = new MoneyKind<JpyCurrency>();

        inventory[100] = 1;
        dispense[100] = 2; // Required 2, only 1 available

        Should.Throw<InvalidOperationException>(() =>
            inventory.Subtract(dispense));
    }

    /// <summary>Verifies that the greedy algorithm is used when sufficient inventory exists for all denominations.</summary>
    [Fact]
    public void CalculateChangeWithSufficientInventoryShouldUseGreedy()
    {
        var inventory = new MoneyKind<JpyCurrency>();
        inventory[1000] = 10;
        inventory[500] = 10;
        inventory[100] = 10;

        // Change needed: 1600
        var change = inventory.CalculateChange(1600m);

        change[1000].ShouldBe(1);
        change[500].ShouldBe(1);
        change[100].ShouldBe(1);
        change.TotalAmount().ShouldBe(1600m);
    }

    /// <summary>Verifies that the algorithm falls back to lower denominations when a higher denomination is unavailable.</summary>
    [Fact]
    public void CalculateChangeWithBrokenDenominationShouldFallbackToLower()
    {
        var inventory = new MoneyKind<JpyCurrency>();
        inventory[1000] = 0; // Out of 1000 yen bills
        inventory[500] = 10;
        inventory[100] = 10;

        // Change needed: 1200. Should use 500x2 + 100x2
        var change = inventory.CalculateChange(1200m);

        change[1000].ShouldBe(0);
        change[500].ShouldBe(2);
        change[100].ShouldBe(2);
        change.TotalAmount().ShouldBe(1200m);
    }

    /// <summary>Verifies that the algorithm returns the maximum possible payable amount when the exact amount cannot be matched.</summary>
    [Fact]
    public void CalculateChangeWhenImpossibleShouldReturnWhatItCouldCalculate()
    {
        var inventory = new MoneyKind<JpyCurrency>();
        inventory[100] = 2; // Total 200 available

        // Need 500, only 200 possible
        var change = inventory.CalculateChange(500m);

        change[100].ShouldBe(2);
        change.TotalAmount().ShouldBe(200m);
    }

    /// <summary>Verifies the IsPayable method reflects whether an exact amount can be formed from the inventory.</summary>
    [Fact]
    public void IsPayableShouldReflectAccuracy()
    {
        var inventory = new MoneyKind<JpyCurrency>();
        inventory[1000] = 1;
        inventory[100] = 4; // Total 1400

        inventory.IsPayable(1000m).ShouldBeTrue();
        inventory.IsPayable(1400m).ShouldBeTrue();
        inventory.IsPayable(1500m).ShouldBeFalse(); // Not enough total
        inventory.IsPayable(500m).ShouldBeFalse();  // Has 1000 and 100s, but can't make 500
    }
}
