using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest;

/// <summary>Tests for Swiss Franc (CHF) specific logic and rounding.</summary>
public class MoneyKindChfTest
{
    [Fact]
    public void CalculateChange_Chf_ShouldHandleMinimumUnitOfFiveCents()
    {
        // Setup: Need an amount that is not divisible by 0.05.
        // ChfCurrency.MinimumUnit is 0.05m.
        var inventory = new MoneyKind<ChfCurrency>();
        inventory[0.05m] = 10;
        inventory[0.10m] = 10;

        // Try to pay 0.17 CHF.
        var result = inventory.CalculateChangeDetail(0.17m);

        // Analysis:
        // 1. Greedy takes 0.10 x 1 (Remaining 0.07)
        // 2. Greedy takes 0.05 x 1 (Remaining 0.02)
        // 3. No more coins available for 0.02.
        
        result.IsSucceed.ShouldBeFalse();
        result.PayableChange[0.10m].ShouldBe(1);
        result.PayableChange[0.05m].ShouldBe(1);
        result.PayableChange.TotalAmount().ShouldBe(0.15m);
        
        result.RemainingAmount.ShouldBe(0.02m);
    }

    [Fact]
    public void Chf_Properties_ShouldBeCorrect()
    {
        ChfCurrency.Code.ShouldBe(MoneyKind4Opos.Codes.Iso4217.CHF);
        ChfCurrency.MinimumUnit.ShouldBe(0.05m);
    }

    [Fact]
    public void ToCashCountsString_Chf_ShouldOutputZeroCountsForAllDenominations()
    {
        var mk = new MoneyKind<ChfCurrency>();
        mk[0.05m] = 1;

        var result = mk.ToCashCountsString();
        
        // Assert: Actual output format is "0.05:1,0.1:0,..." without extra digits
        result.ShouldContain("0.05:1");
        result.ShouldContain("0.1:0");
        result.ShouldContain("1000:0");
    }
}
