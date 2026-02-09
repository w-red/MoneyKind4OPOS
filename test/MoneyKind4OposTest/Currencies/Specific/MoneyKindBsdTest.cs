using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;BsdCurrency&gt; tests for special 15-cent coin.</summary>
public class MoneyKindBsdTest
{
    /// <summary>Verifies that the 15-cent coin (0.15m) is correctly handled in change calculation.</summary>
    [Fact]
    public void CalculateChangeBsdShouldHandle15CentCoin()
    {
        // BSD has a special 15-cent coin (0.15m)
        var inventory = new MoneyKind<BsdCurrency>();
        inventory[0.15m] = 5;  // 15 cent coins
        inventory[0.10m] = 5;  // 10 cent coins
        inventory[0.05m] = 5;  // 5 cent coins

        // Pay 0.45 dollars
        var result = inventory.CalculateChangeDetail(0.45m);

        // Analysis (greedy):
        // 1. Takes 0.15 x 3 = 0.45 (Remaining 0)
        result.IsSucceed.ShouldBeTrue();
        result.PayableChange[0.15m].ShouldBe(3);
        result.PayableChange.TotalAmount().ShouldBe(0.45m);
        result.RemainingAmount.ShouldBe(0m);
    }

    /// <summary>Verifies change calculation when 15-cent coin is part of mixed denominations.</summary>
    [Fact]
    public void CalculateChangeBsdShouldMixDenominationsWith15Cent()
    {
        var inventory = new MoneyKind<BsdCurrency>();
        inventory[0.25m] = 2;  // 25 cent coins
        inventory[0.15m] = 2;  // 15 cent coins
        inventory[0.10m] = 2;  // 10 cent coins
        inventory[0.05m] = 2;  // 5 cent coins

        // Pay 0.80 dollars
        var result = inventory.CalculateChangeDetail(0.80m);

        // Analysis (greedy):
        // 1. Takes 0.25 x 2 = 0.50 (Remaining 0.30)
        // 2. Takes 0.15 x 2 = 0.30 (Remaining 0)
        result.IsSucceed.ShouldBeTrue();
        result.PayableChange[0.25m].ShouldBe(2);
        result.PayableChange[0.15m].ShouldBe(2);
        result.PayableChange.TotalAmount().ShouldBe(0.80m);
    }

    /// <summary>Verifies the 1-cent minimum unit for BSD.</summary>
    [Fact]
    public void BsdMinimumUnitShouldBeOneCent()
    {
        BsdCurrency.MinimumUnit.ShouldBe(0.01m);
    }

    /// <summary>Verifies that BSD MoneyKind instances include the 15-cent denomination.</summary>
    [Fact]
    public void BsdShouldInclude15CentInDenominations()
    {
        var mk = new MoneyKind<BsdCurrency>();
        
        // 0.15m should be a valid denomination
        mk[0.15m] = 10;
        mk[0.15m].ShouldBe(10);
    }

    /// <summary>Verifies that BSD also has 50-cent bill (unusual).</summary>
    [Fact]
    public void BsdShouldInclude50CentBill()
    {
        var mk = new MoneyKind<BsdCurrency>();
        
        // 0.50m bill should be a valid denomination
        mk[0.50m] = 5;
        mk[0.50m].ShouldBe(5);
    }
}
