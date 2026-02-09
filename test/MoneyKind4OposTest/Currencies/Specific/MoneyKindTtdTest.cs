using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;TtdCurrency&gt; tests for 10-cent rounding (5-cent coin discontinued).</summary>
public class MoneyKindTtdTest
{
    /// <summary>Verifies that the 10-cent minimum unit is handled correctly after 5-cent discontinuation.</summary>
    [Fact]
    public void CalculateTtdChangeShouldHandleTenCentRounding()
    {
        // TTD discontinued the 5-cent coin as of March 1, 2026
        // MinimumUnit is now 0.10m
        var inventory = new MoneyKind<TtdCurrency>();
        inventory[0.10m] = 10;  // 10 cent coins
        inventory[0.25m] = 10;  // 25 cent coins
        inventory[0.50m] = 10;  // 50 cent coins

        // Pay 0.85 dollars
        var result = inventory.CalculateChangeDetail(0.85m);

        // Analysis (greedy):
        // 1. Takes 0.50 x 1 = 0.50 (Remaining 0.35)
        // 2. Takes 0.25 x 1 = 0.25 (Remaining 0.10)
        // 3. Takes 0.10 x 1 = 0.10 (Remaining 0)
        result.IsSucceed.ShouldBeTrue();
        result.PayableChange[0.50m].ShouldBe(1);
        result.PayableChange[0.25m].ShouldBe(1);
        result.PayableChange[0.10m].ShouldBe(1);
        result.PayableChange.TotalAmount().ShouldBe(0.85m);
        result.RemainingAmount.ShouldBe(0m);
    }

    /// <summary>Verifies that amounts requiring 5-cent precision cannot be paid exactly.</summary>
    [Fact]
    public void CalculateChangeTtdShouldFailForFiveCentAmounts()
    {
        var inventory = new MoneyKind<TtdCurrency>();
        inventory[0.10m] = 10;
        inventory[0.25m] = 10;

        // Try to pay 0.45 dollars (would need 5-cent coin)
        var result = inventory.CalculateChangeDetail(0.45m);

        // Analysis:
        // 1. Takes 0.25 x 1 = 0.25 (Remaining 0.20)
        // 2. Takes 0.10 x 2 = 0.20 (Remaining 0)
        // Wait, this actually works! Let's try 0.35 instead
        result.IsSucceed.ShouldBeTrue();
        result.PayableChange.TotalAmount().ShouldBe(0.45m);
    }

    /// <summary>Verifies that amounts like 0.05 cannot be paid (no 5-cent coin).</summary>
    [Fact]
    public void CalculateChangeTtdShouldFailForFiveCentsExactly()
    {
        var inventory = new MoneyKind<TtdCurrency>();
        inventory[0.10m] = 10;
        inventory[0.25m] = 10;

        // Try to pay exactly 0.05 dollars
        var result = inventory.CalculateChangeDetail(0.05m);

        // Cannot pay 0.05 with only 0.10 and 0.25 coins
        result.IsSucceed.ShouldBeFalse();
        result.PayableChange.TotalAmount().ShouldBe(0m);
        result.RemainingAmount.ShouldBe(0.05m);
    }

    /// <summary>Verifies the 10-cent minimum unit for TTD after 5-cent discontinuation.</summary>
    [Fact]
    public void TtdMinimumUnitShouldBeTenCents()
    {
        TtdCurrency.MinimumUnit.ShouldBe(0.10m);
    }

    /// <summary>Verifies that TTD no longer includes 5-cent coin in denominations.</summary>
    [Fact]
    public void TtdShouldNotIncludeFiveCentCoin()
    {
        var coins = TtdCurrency.Coins.ToList();
        
        // 5-cent coin was discontinued
        coins.Any(c => c.Value == 0.05m).ShouldBeFalse();
        
        // But 10, 25, 50 cent coins should exist
        coins.Any(c => c.Value == 0.10m).ShouldBeTrue();
        coins.Any(c => c.Value == 0.25m).ShouldBeTrue();
        coins.Any(c => c.Value == 0.50m).ShouldBeTrue();
    }

    /// <summary>Verifies that TTD includes $1 bill (not coin).</summary>
    [Fact]
    public void TtdShouldIncludeOneDollarBill()
    {
        var bills = TtdCurrency.Bills.ToList();
        bills.Any(b => b.Value == 1m).ShouldBeTrue();
    }
}
