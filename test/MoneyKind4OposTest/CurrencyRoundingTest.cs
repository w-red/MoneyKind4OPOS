using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;
using System.Globalization;

namespace MoneyKind4OposTest;

/// <summary>
/// A test-only currency to simulate Swiss Franc (CHF) like rounding issues.
/// Minimum unit is 0.05, coins are 0.05, 0.10, etc.
/// </summary>
public class MockChfCurrency : ICurrency, ICashCountFormattable<MockChfCurrency>, ICurrencyFormattable<MockChfCurrency>
{
    public static Iso4217 Code => Iso4217.CHF;
    public static decimal MinimumUnit => 0.05m; // 5 cents is the smallest physical coin
    public static bool IsZeroPadding => false;

    public static IEnumerable<CashFaceInfo> Coins => [
        new(0.05m, CashType.Coin, "5 Rappen", "5c"),
        new(0.10m, CashType.Coin, "10 Rappen", "10c"),
        new(0.20m, CashType.Coin, "20 Rappen", "20c")
    ];

    public static IEnumerable<CashFaceInfo> Bills => [
        new(10.00m, CashType.Bill, "10 Francs", "10Fr")
    ];

    public static IEnumerable<ISubsidiaryUnit> SubsidiaryUnits => [];

    // Formatting stubs for test
    public static CurrencyFormattingOptions Global { get; } = new(
        Symbol: "Fr.",
        NumberFormat: NumberFormatInfo.InvariantInfo,
        DisplayFormat: new(SymbolPlacement.Prefix));

    public static CurrencyFormattingOptions Local => Global;
}

public class CurrencyRoundingTest
{
    [Fact]
    public void CalculateChange_WhenAmountIsBelowMinimumUnit_ShouldFailWithRemaining()
    {
        // Setup: Need to pay 0.07 (7 cents).
        // Inventory has plenty of 0.05 coins.
        var inventory = new MoneyKind<MockChfCurrency>();
        inventory[0.05m] = 10;

        var result = inventory.CalculateChangeDetail(0.07m);

        // Result: 
        // 1. Can pay 0.05
        // 2. Remaining 0.02 cannot be paid (smaller than 0.05)
        result.IsSucceed.ShouldBeFalse();
        result.PayableChange[0.05m].ShouldBe(1);
        result.PayableChange.TotalAmount().ShouldBe(0.05m);

        result.RemainingAmount.ShouldBe(0.02m); // Exactly 0.02 short

        // MissingChange logic will try to explain how to get 0.02 using the same denominations.
        // Since no denomination is <= 0.02, MissingChange.TotalAmount() will be 0.
        result.MissingChange.TotalAmount().ShouldBe(0m);
    }

    [Fact]
    public void CalculateChange_WhenExactMatchPossible_ShouldSucceed()
    {
        var inventory = new MoneyKind<MockChfCurrency>();
        inventory[0.05m] = 1;
        inventory[0.10m] = 1;

        var result = inventory.CalculateChangeDetail(0.15m);

        result.IsSucceed.ShouldBeTrue();
        result.PayableChange.TotalAmount().ShouldBe(0.15m);
    }
}
