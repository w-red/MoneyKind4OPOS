using MoneyKind4Opos;
using MoneyKind4Opos.Currencies;
using Shouldly;

namespace MoneyKind4OPOSTest;

public class MoneyKindTest
{
    [Theory]
    [InlineData("1:1,10:2;1000:1", 1021)]
    [InlineData(";10000:1", 10000)]
    [InlineData("1:10;5000:1,10000:1", 15010)]
    public void Jpy_Parse_And_TotalAmount_ShouldBeCorrect(string input, decimal expectedTotal)
    {
        var mk = MoneyKind<JpyCurrency>.Parse(input);
        mk.TotalAmount().ShouldBe(expectedTotal);
    }

    [Fact]
    public void Jpy_ToCashCountsString_ShouldBeCorrect()
    {
        var mk = new MoneyKind<JpyCurrency>();
        var face1000 = JpyCurrency.Bills.First(f => f.Value == 1000m);
        var face100 = JpyCurrency.Coins.First(f => f.Value == 100m);

        mk.Counts[face1000] = 5;
        mk.Counts[face100] = 3;

        var result = mk.ToCashCountsString();

        // 期待される形式: coins...;bills...
        // 順番は ICurrency.Coins/Bills の巡回順に依存する
        result.ShouldContain("100:3");
        result.ShouldContain("1000:5");
    }
}
