using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest;

public class MoneyKindDetailTest
{
    [Fact]
    public void CalculateChangeDetail_ExactMatch_ShouldSucceed()
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

    [Fact]
    public void CalculateChangeDetail_Fallback_ShouldSucceedWithLowerDenominations()
    {
        var inventory = MoneyKind<JpyCurrency>.Parse("500:4;"); // 1000円札なし、500円玉のみ
        var result = inventory.CalculateChangeDetail(1000m);

        result.IsSucceed.ShouldBeTrue();
        result.PayableChange[1000].ShouldBe(0);
        result.PayableChange[500].ShouldBe(2); // 500円2枚で代用
        result.RemainingAmount.ShouldBe(0m);
    }

    [Fact]
    public void CalculateChangeDetail_InsufficientStock_ShouldReturnPartialAndMissing()
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

    [Fact]
    public void CalculateChangeDetail_Bottleneck_ShouldIdentifyExactlyWhatIsMissing()
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

    [Fact]
    public void CalculateChangeDetail_ZeroAmount_ShouldReturnEmptySuccess()
    {
        var inventory = MoneyKind<JpyCurrency>.Parse(";1000:10");
        var result = inventory.CalculateChangeDetail(0m);

        result.IsSucceed.ShouldBeTrue();
        result.PayableChange.TotalAmount().ShouldBe(0m);
        result.RemainingAmount.ShouldBe(0m);
    }

    [Fact]
    public void CalculateChangeDetail_ZeroStock_ShouldReturnAllAsMissing()
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

    [Fact]
    public void CalculateChangeDetail_EurCurrency_ShouldHandleDecimals()
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
