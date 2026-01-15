using MoneyKind4Opos;
using MoneyKind4Opos.Currencies;
using Shouldly;

namespace MoneyKind4OPOSTest;

/// <summary>MoneyKind&lt;JpyCurrency&gt; tests.</summary>
public class MoneyKindJpyTest
{
    /// <summary>Parse and TotalAmount tests for JpyCurrency.</summary>
    [Theory]
    [InlineData("", 0)]
    [InlineData(";", 0)]
    [InlineData("1:1,5:2,10:3,50:4,100:5,500:6;", 3741)]
    [InlineData(";1000:1,2000:2,5000:3,10000:4", 60000)]
    [InlineData(
        "1:1,5:2,10:3,50:4,100:5,500:6;1000:1,2000:2,5000:3,10000:4",
        63741)]
    [InlineData("1:1,10:2;1000:1", 1021)]
    [InlineData("1:,10:;10000:1", 10000)]
    [InlineData(";10000:1", 10000)]
    [InlineData("1:10;5000:1,10000:1", 15010)]
    public void Jpy_Parse_And_TotalAmount_ShouldBeCorrect(
        string input, decimal expectedTotal)
    {
        var mk = MoneyKind<JpyCurrency>.Parse(input);
        mk.TotalAmount().ShouldBe(expectedTotal);
    }

    /// <summary>ToCashCountsString tests for JpyCurrency.</summary>
    [Fact]
    public void Jpy_ToCashCountsString_ShouldBeCorrect()
    {
        var mk = new MoneyKind<JpyCurrency>();

        mk[1000m] = 5;
        mk[100m] = 3;

        var result = mk.ToCashCountsString();

        // expect: coins...;bills...
        // order is ICurrency.Coins -> Bills.
        result.ShouldContain("100:3");
        result.ShouldContain("1000:5");
    }
}
