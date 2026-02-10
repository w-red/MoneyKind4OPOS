using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Core;

/// <summary>Tests for the MoneyKind.CalculateChangeDetail method, verifying detailed change reports.</summary>
public class MoneyKindDetailTest
{
    /// <summary>Verifies that an exact match in inventory results in a successful detailed change report.</summary>
    [Fact]
    public void CalculateChangeDetailExactMatchShouldSucceed()
    {
        var inventory = MoneyKind<JpyCurrency>.Parse("500:1,100:1;1000:1");
        var result = inventory.CalculateChangeDetail(1600m);

        result.IsSucceed.ShouldBeTrue();
        result.RemainingAmount.ShouldBe(0m);
        result.PayableChange.TotalAmount().ShouldBe(1600m);
        result.PayableChange[1000].ShouldBe(1);
        result.PayableChange[1000, CashType.Bill].ShouldBe(1);
        result.PayableChange[500].ShouldBe(1);
        result.PayableChange[500, CashType.Coin].ShouldBe(1);
        result.PayableChange[100].ShouldBe(1);
        result.PayableChange[100, CashType.Coin].ShouldBe(1);
        result.MissingChange.Counts.Values.Sum().ShouldBe(0); // No missing items
    }

    /// <summary>Verifies that the detailed calculation correctly falls back to lower denominations when needed.</summary>
    [Fact]
    public void CalculateChangeDetailFallbackShouldSucceedWithLowerDenominations()
    {
        var inventory = MoneyKind<JpyCurrency>.Parse("500:4;"); // No 1,000 yen bills, only 500 yen coins
        var result = inventory.CalculateChangeDetail(1000m);

        result.IsSucceed.ShouldBeTrue();
        result.PayableChange[1000].ShouldBe(0);
        result.PayableChange[500].ShouldBe(2); // Substitute with two 500 yen coins
        result.RemainingAmount.ShouldBe(0m);
    }

    /// <summary>Verifies that partial payments and the specific missing denominations are accurately reported when stock is low.</summary>
    [Fact]
    public void CalculateChangeDetailInsufficientStockShouldReturnPartialAndMissing()
    {
        var inventory = MoneyKind<JpyCurrency>.Parse("500:1;"); // Only one 500 yen coin
        var result = inventory.CalculateChangeDetail(1200m);

        result.IsSucceed.ShouldBeFalse();
        result.PayableChange.TotalAmount().ShouldBe(500m); // Only 500 yen could be paid
        result.RemainingAmount.ShouldBe(700m); // Remaining 700 yen deficit

        // Ideal missing breakdown (700 yen = 500 yen x 1 + 100 yen x 2)
        result.MissingChange[500].ShouldBe(1);
        result.MissingChange[100].ShouldBe(2);
    }

    /// <summary>Verifies that the report identifies the exact missing denomination when a breakdown bottleneck occurs.</summary>
    [Fact]
    public void CalculateChangeDetailBottleneckShouldIdentifyExactlyWhatIsMissing()
    {
        // Want to pay 150 yen, but only have one 100 yen coin and four 10 yen coins (no 50 yen coin)
        var inventory = MoneyKind<JpyCurrency>.Parse("100:1,10:4;");
        var result = inventory.CalculateChangeDetail(150m);

        result.IsSucceed.ShouldBeFalse();
        result.PayableChange.TotalAmount().ShouldBe(140m); // Up to 140 yen
        result.RemainingAmount.ShouldBe(10m);

        // Missing is "another 10 yen"
        result.MissingChange[10].ShouldBe(1);
    }

    /// <summary>Verifies that requesting zero change results in a successful empty report.</summary>
    [Fact]
    public void CalculateChangeDetailZeroAmountShouldReturnEmptySuccess()
    {
        var inventory = MoneyKind<JpyCurrency>.Parse(";1000:10");
        var result = inventory.CalculateChangeDetail(0m);

        result.IsSucceed.ShouldBeTrue();
        result.PayableChange.TotalAmount().ShouldBe(0m);
        result.RemainingAmount.ShouldBe(0m);
    }

    /// <summary>Verifies that if inventory is empty, the entire amount is reported as missing in the ideal denomination breakdown.</summary>
    [Fact]
    public void CalculateChangeDetailZeroStockShouldReturnAllAsMissing()
    {
        var inventory = new MoneyKind<JpyCurrency>(); // Out of stock
        var result = inventory.CalculateChangeDetail(1600m);

        result.IsSucceed.ShouldBeFalse();
        result.PayableChange.TotalAmount().ShouldBe(0m);
        result.RemainingAmount.ShouldBe(1600m);

        // All items in the ideal breakdown go into Missing
        result.MissingChange[1000].ShouldBe(1);
        result.MissingChange[500].ShouldBe(1);
        result.MissingChange[100].ShouldBe(1);
    }

    /// <summary>Verifies that currencies with sub-unit decimals like EUR are handled correctly in detailed reports.</summary>
    [Fact]
    public void CalculateChangeDetailEurCurrencyShouldHandleDecimals()
    {
        var inventory = new MoneyKind<EurCurrency>(); // Out of stock
        var result = inventory.CalculateChangeDetail(0.75m); // 0.75 Euro (75 cents)

        result.IsSucceed.ShouldBeFalse();
        result.RemainingAmount.ShouldBe(0.75m);

        // EUR denomination breakdown: 0.50 (50c), 0.20 (20c), 0.05 (5c)
        result.MissingChange[0.5m].ShouldBe(1);
        result.MissingChange[0.2m].ShouldBe(1);
        result.MissingChange[0.05m].ShouldBe(1);
    }
}
