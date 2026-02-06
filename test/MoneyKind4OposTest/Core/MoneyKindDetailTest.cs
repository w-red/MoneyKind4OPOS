using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Core;

/// <summary>Tests for the MoveKind.CalculateChangeDetail method, verifying detailed change reports.</summary>
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
        result.MissingChange.Counts.Values.Sum().ShouldBe(0); // 足りないものは無し
    }

    /// <summary>Verifies that the detailed calculation correctly falls back to lower denominations when needed.</summary>
    [Fact]
    public void CalculateChangeDetailFallbackShouldSucceedWithLowerDenominations()
    {
        var inventory = MoneyKind<JpyCurrency>.Parse("500:4;"); // 1000円札なし、500円玉のみ
        var result = inventory.CalculateChangeDetail(1000m);

        result.IsSucceed.ShouldBeTrue();
        result.PayableChange[1000].ShouldBe(0);
        result.PayableChange[500].ShouldBe(2); // 500円2枚で代用
        result.RemainingAmount.ShouldBe(0m);
    }

    /// <summary>Verifies that partial payments and the specific missing denominations are accurately reported when stock is low.</summary>
    [Fact]
    public void CalculateChangeDetailInsufficientStockShouldReturnPartialAndMissing()
    {
        var inventory = MoneyKind<JpyCurrency>.Parse("500:1;"); // 500円1枚のみ
        var result = inventory.CalculateChangeDetail(1200m);

        result.IsSucceed.ShouldBeFalse();
        result.PayableChange.TotalAmount().ShouldBe(500m); // 払えたのは500円のみ
        result.RemainingAmount.ShouldBe(700m); // 残り700円不足

        // 理想的な不足構成 (700円 = 500円x1 + 100円x2)
        result.MissingChange[500].ShouldBe(1);
        result.MissingChange[100].ShouldBe(2);
    }

    /// <summary>Verifies that the report identifies the exact missing denomination when a breakdown bottleneck occurs.</summary>
    [Fact]
    public void CalculateChangeDetailBottleneckShouldIdentifyExactlyWhatIsMissing()
    {
        // 150円払いたいが、100円玉1枚、10円玉4枚しかない（50円玉がない）
        var inventory = MoneyKind<JpyCurrency>.Parse("100:1,10:4;");
        var result = inventory.CalculateChangeDetail(150m);

        result.IsSucceed.ShouldBeFalse();
        result.PayableChange.TotalAmount().ShouldBe(140m); // 140円まで
        result.RemainingAmount.ShouldBe(10m);

        // 足りないのは「あと10円」
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
        var inventory = new MoneyKind<JpyCurrency>(); // 在庫なし
        var result = inventory.CalculateChangeDetail(1600m);

        result.IsSucceed.ShouldBeFalse();
        result.PayableChange.TotalAmount().ShouldBe(0m);
        result.RemainingAmount.ShouldBe(1600m);

        // 理想的な構成すべてが Missing に入る
        result.MissingChange[1000].ShouldBe(1);
        result.MissingChange[500].ShouldBe(1);
        result.MissingChange[100].ShouldBe(1);
    }

    /// <summary>Verifies that currencies with sub-unit decimals like EUR are handled correctly in detailed reports.</summary>
    [Fact]
    public void CalculateChangeDetailEurCurrencyShouldHandleDecimals()
    {
        var inventory = new MoneyKind<EurCurrency>(); // 在庫なし
        var result = inventory.CalculateChangeDetail(0.75m); // 0.75ユーロ（75セント）

        result.IsSucceed.ShouldBeFalse();
        result.RemainingAmount.ShouldBe(0.75m);

        // EURの金種構成: 0.50 (50c), 0.20 (20c), 0.05 (5c)
        result.MissingChange[0.5m].ShouldBe(1);
        result.MissingChange[0.2m].ShouldBe(1);
        result.MissingChange[0.05m].ShouldBe(1);
    }
}
