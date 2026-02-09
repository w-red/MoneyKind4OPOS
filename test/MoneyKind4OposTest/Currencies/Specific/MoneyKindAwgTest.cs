using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;AwgCurrency&gt; tests for special 2½ florin coin.</summary>
public class MoneyKindAwgTest
{
    /// <summary>Verifies that the 2½ florin coin (2.50m) is correctly handled in change calculation.</summary>
    [Fact]
    public void CalculateChangeAwgShouldHandle2AndHalfFlorinCoin()
    {
        // AWG has a special 2½ florin coin (2.50m)
        var inventory = new MoneyKind<AwgCurrency>();
        inventory[2.50m] = 5;  // 2½ florin coins
        inventory[1.00m] = 5;  // 1 florin coins
        inventory[0.50m] = 5;  // 50 cent coins

        // Pay 7.50 florins
        var result = inventory.CalculateChangeDetail(7.50m);

        // Analysis (greedy):
        // 1. Takes 2.50 x 3 = 7.50 (Remaining 0)
        result.IsSucceed.ShouldBeTrue();
        result.PayableChange[2.50m].ShouldBe(3);
        result.PayableChange.TotalAmount().ShouldBe(7.50m);
        result.RemainingAmount.ShouldBe(0m);
    }

    /// <summary>Verifies change calculation when 2½ florin coin is part of mixed denominations.</summary>
    [Fact]
    public void CalculateChangeAwgShouldMixDenominationsWithHalfFlorin()
    {
        var inventory = new MoneyKind<AwgCurrency>();
        inventory[5.00m] = 1;  // 5 florin coin
        inventory[2.50m] = 1;  // 2½ florin coin
        inventory[1.00m] = 2;  // 1 florin coins

        // Pay 9.50 florins
        var result = inventory.CalculateChangeDetail(9.50m);

        // Analysis (greedy):
        // 1. Takes 5.00 x 1 = 5.00 (Remaining 4.50)
        // 2. Takes 2.50 x 1 = 2.50 (Remaining 2.00)
        // 3. Takes 1.00 x 2 = 2.00 (Remaining 0)
        result.IsSucceed.ShouldBeTrue();
        result.PayableChange[5.00m].ShouldBe(1);
        result.PayableChange[2.50m].ShouldBe(1);
        result.PayableChange[1.00m].ShouldBe(2);
        result.PayableChange.TotalAmount().ShouldBe(9.50m);
    }

    /// <summary>Verifies the 5-cent minimum unit rounding for AWG.</summary>
    [Fact]
    public void AwgMinimumUnitShouldBeFiveCents()
    {
        AwgCurrency.MinimumUnit.ShouldBe(0.05m);
    }

    /// <summary>Verifies that AWG MoneyKind instances include the 2½ florin denomination.</summary>
    [Fact]
    public void AwgShouldInclude2AndHalfFlorinInDenominations()
    {
        var mk = new MoneyKind<AwgCurrency>();
        
        // 2.50m should be a valid denomination
        mk[2.50m] = 10;
        mk[2.50m].ShouldBe(10);
    }
}
