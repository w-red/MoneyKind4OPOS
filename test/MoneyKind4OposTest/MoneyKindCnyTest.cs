using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OPOSTest;

/// <summary>Tests for MoneyKind with CnyCurrency (Complex case with overlaps).</summary>
public class MoneyKindCnyTest
{
    [Fact]
    public void Overlap_Denominations_ShouldBeHandledSeparately()
    {
        // CNY has 1.00, 0.50, 0.10 as BOTH Coin and Bill.
        // Input: 0.1:1, 0.5:1, 1:1 (coins) ; 0.1:10, 0.5:10, 1:10 (bills)
        var input = "0.1:1,0.5:1,1:1;0.1:10,0.5:10,1:10";
        var mk = MoneyKind<CnyCurrency>.Parse(input);

        // Individual counts (via specific indexer)
        mk[0.1m, CashType.Coin].ShouldBe(1);
        mk[0.1m, CashType.Bill].ShouldBe(10);

        // Sums
        mk.CoinAmount().ShouldBe(0.1m + 0.5m + 1.0m); // 1.6
        mk.BillAmount().ShouldBe(1.0m + 5.0m + 10.0m); // 16.0
        mk.TotalAmount().ShouldBe(17.6m);
    }

    [Fact]
    public void Undefined_Denominations_ShouldBeIgnored()
    {
        // 999 is not a valid CNY face value
        var input = "1:1,999:10;100:1";
        var mk = MoneyKind<CnyCurrency>.Parse(input);

        mk[1, CashType.Coin].ShouldBe(1);
        mk[100, CashType.Bill].ShouldBe(1);
        mk.Counts
            .Count(c => c.Value > 0).ShouldBe(2); // Only 1 Yuan (coin) and 100 Yuan (bill)
        mk.TotalAmount().ShouldBe(101.0m);

        // Setter for undefined value
        mk[999m] = 5;
        mk.TotalAmount().ShouldBe(101.0m); // No change
    }

    [Theory]
    [InlineData("1:abc", 0)]     // Invalid count
    [InlineData("abc:1", 0)]     // Invalid value
    [InlineData("1:", 0)]        // Missing count
    [InlineData(":1", 0)]        // Missing value
    [InlineData("1.0:1, ,0.5:1", 1.5)] // Empty entry between commas
    public void Malformed_Input_ShouldNotCrash(string input, decimal expectedTotal)
    {
        var mk = MoneyKind<CnyCurrency>.Parse(input);
        mk.TotalAmount().ShouldBe(expectedTotal);
    }

    [Fact]
    public void Default_Indexer_ShouldTargetPreferredType()
    {
        var mk = new MoneyKind<CnyCurrency>();

        // When face value exists in both, target preferred (usually Coin because it comes first in concat)
        mk[1.0m] = 7;

        mk[1.0m, CashType.Coin].ShouldBe(7);
        mk[1.0m, CashType.Bill].ShouldBe(0);
    }

    [Fact]
    public void RoundTrip_WithOverlaps_ShouldPreserveDistinction()
    {
        var original = new MoneyKind<CnyCurrency>();
        original[1.0m, CashType.Coin] = 2;
        original[1.0m, CashType.Bill] = 3;

        var serialized = original.ToCashCountsString();
        // serialized contains all defined faces. check a few specific parts.

        var restored = MoneyKind<CnyCurrency>.Parse(serialized);

        restored[1.0m, CashType.Coin].ShouldBe(2);
        restored[1.0m, CashType.Bill].ShouldBe(3);
        restored.TotalAmount().ShouldBe(5.0m);
    }

    [Fact]
    public void ToCashCountsString_FullFormat_ShouldBeStrictlyCorrect()
    {
        var mk = new MoneyKind<CnyCurrency>();
        // Set specific counts. Unset should be 0.
        mk[0.01m, CashType.Coin] = 1; // Fen
        mk[100.0m, CashType.Bill] = 5; // 100 Yuan

        var result = mk.ToCashCountsString();

        // The order is determined by TCurrency.Coins then TCurrency.Bills
        // Expected parts (subset for clarity but strict check):
        // Coins: 0.01:1, 0.02:0, 0.05:0, 0.1:0, 0.2:0, 0.5:0, 1:0
        // Bills: 0.1:0, 0.5:0, 1:0, 5:0, 10:0, 20:0, 50:0, 100:5
        var expected = "0.01:1,0.02:0,0.05:0,0.1:0,0.2:0,0.5:0,1:0;0.1:0,0.5:0,1:0,5:0,10:0,20:0,50:0,100:5";

        result.ShouldBe(expected);
    }
}
