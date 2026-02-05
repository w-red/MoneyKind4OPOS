using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest;

public class MoneyKindAlgorithmTest
{
    [Fact]
    public void Add_ShouldAccumulateCounts()
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

    [Fact]
    public void Subtract_ShouldReduceCounts()
    {
        var inventory = new MoneyKind<JpyCurrency>();
        var dispense = new MoneyKind<JpyCurrency>();

        inventory[1000] = 10;
        dispense[1000] = 3;

        inventory.Subtract(dispense);

        inventory[1000].ShouldBe(7);
    }

    [Fact]
    public void Subtract_InsufficientInventory_ShouldThrow()
    {
        var inventory = new MoneyKind<JpyCurrency>();
        var dispense = new MoneyKind<JpyCurrency>();

        inventory[100] = 1;
        dispense[100] = 2; // Required 2, only 1 available

        Should.Throw<InvalidOperationException>(() =>
            inventory.Subtract(dispense));
    }

    [Fact]
    public void CalculateChange_WithSufficientInventory_ShouldUseGreedy()
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

    [Fact]
    public void CalculateChange_WithBrokenDenomination_ShouldFallbackToLower()
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

    [Fact]
    public void CalculateChange_WhenImpossible_ShouldReturnWhatItCouldCalculate()
    {
        var inventory = new MoneyKind<JpyCurrency>();
        inventory[100] = 2; // Total 200 available

        // Need 500, only 200 possible
        var change = inventory.CalculateChange(500m);

        change[100].ShouldBe(2);
        change.TotalAmount().ShouldBe(200m);
    }

    [Fact]
    public void IsPayable_ShouldReflectAccuracy()
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
