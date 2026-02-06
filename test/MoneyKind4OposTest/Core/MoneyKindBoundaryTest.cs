using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Core;

/// <summary>Boundary tests for change calculation logic (Greedy algorithm).</summary>
public class MoneyKindBoundaryTest
{
    /// <summary>Verifies that exact change can be paid using smaller denominations when a larger one is missing.</summary>
    [Fact]
    public void CalculateChangeJustEnoughInSmallDenominationsShouldSucceed()
    {
        // Case: Need 1000 yen. No 1000 yen bills. 
        // Have exactly two 500 yen coins.
        var inventory = new MoneyKind<JpyCurrency>();
        inventory[500] = 2; // Total 1000

        var result = inventory.CalculateChangeDetail(1000m);

        result.IsSucceed.ShouldBeTrue();
        result.PayableChange[500].ShouldBe(2);
        result.RemainingAmount.ShouldBe(0m);
    }

    /// <summary>Verifies that change calculation fails and identifies the missing amount when inventory is slightly insufficient.</summary>
    [Fact]
    public void CalculateChangeOneUnitShortOfTotalShouldFailAndIdentifyMissing()
    {
        // Case: Need 1000 yen. Have only 999 yen (missing 1 yen).
        var inventory = new MoneyKind<JpyCurrency>();
        inventory[500] = 1;
        inventory[100] = 4;
        inventory[10] = 9;
        inventory[1] = 9; // Total 999

        var result = inventory.CalculateChangeDetail(1000m);

        result.IsSucceed.ShouldBeFalse();
        result.RemainingAmount.ShouldBe(1m);
        result.MissingChange[1, CashType.Coin].ShouldBe(1);
    }

    /// <summary>Verifies failure when the total inventory amount is enough but the breakdown cannot match the requested sum.</summary>
    [Fact]
    public void CalculateChangeBottleneckAtSmallDenominationShouldFail()
    {
        // Case: Need 110 yen. Have 1000 yen bill, but no 10 yen coins.
        // Total amount (1000) is enough, but breakdown is impossible.
        var inventory = new MoneyKind<JpyCurrency>();
        inventory[1000] = 1;

        var result = inventory.CalculateChangeDetail(110m);

        result.IsSucceed.ShouldBeFalse();
        result.PayableChange.TotalAmount().ShouldBe(0m); // Can't even use the 1000 yen bill
        result.RemainingAmount.ShouldBe(110m);

        // Should identify exactly what's needed for the 110 yen
        result.MissingChange[100].ShouldBe(1);
        result.MissingChange[10].ShouldBe(1);
    }

    /// <summary>Verifies that large inventory counts and amounts are handled without overflow or precision issues.</summary>
    [Fact]
    public void CalculateChangeLargeAmountJustEnoughShouldSucceed()
    {
        // Testing with large count to ensure no integer overflow or rounding issues
        var inventory = new MoneyKind<JpyCurrency>();
        inventory[10000] = 100; // 1,000,000 yen

        var result = inventory.CalculateChangeDetail(1000000m);

        result.IsSucceed.ShouldBeTrue();
        result.PayableChange[10000].ShouldBe(100);
    }

    /// <summary>Verifies that partial payment and missing decimal amounts are correctly identified for currencies with decimals like EUR.</summary>
    [Fact]
    public void CalculateChangeInsufficientDecimalsEurShouldFail()
    {
        // Case: Need 0.05 Euro. Have only 0.02 x 2 = 0.04.
        var inventory = new MoneyKind<EurCurrency>();
        inventory[0.02m] = 2;

        var result = inventory.CalculateChangeDetail(0.05m);

        result.IsSucceed.ShouldBeFalse();
        result.PayableChange.TotalAmount().ShouldBe(0.04m);
        result.RemainingAmount.ShouldBe(0.01m);
        result.MissingChange[0.01m].ShouldBe(1);
    }

    /// <summary>Verifies that denominations with shared face values prioritize bills over coins in CNY.</summary>
    [Fact]
    public void CalculateChangeSameValueShouldPrioritizeBillsOverCoinsCny()
    {
        // CNY has both 1 Yuan Bill and 1 Yuan Coin.
        var inventory = new MoneyKind<CnyCurrency>();
        inventory[1.0m, CashType.Bill] = 1;
        inventory[1.0m, CashType.Coin] = 1;

        // Need 1 Yuan. Should take the Bill first.
        var result = inventory.CalculateChange(1.0m);

        result[1.0m, CashType.Bill].ShouldBe(1);
        result[1.0m, CashType.Coin].ShouldBe(0);
    }

    /// <summary>Verifies that denominations with shared face values prioritize bills over coins in USD.</summary>
    [Fact]
    public void CalculateChangeSameValueShouldPrioritizeBillsOverCoinsUsd()
    {
        // USD has both 1 Dollar Bill and 1 Dollar Coin.
        var inventory = new MoneyKind<UsdCurrency>();
        inventory[1.0m, CashType.Bill] = 1;
        inventory[1.0m, CashType.Coin] = 1;

        // Need 1 Dollar. Should take the Bill first.
        var result = inventory.CalculateChange(1.0m);

        result[1.0m, CashType.Bill].ShouldBe(1);
        result[1.0m, CashType.Coin].ShouldBe(0);
    }
}
