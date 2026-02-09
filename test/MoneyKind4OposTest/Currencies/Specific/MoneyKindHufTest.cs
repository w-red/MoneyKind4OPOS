using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;HufCurrency&gt; tests.</summary>
public class MoneyKindHufTest
{
    /// <summary>Verifies that HUF cash-count strings are parsed and total amounts calculated correctly.</summary>
    [Theory]
    [InlineData("", 0)]
    [InlineData(";", 0)]
    [InlineData("5:1,10:2,20:3,50:4,100:5,200:6;", 1985)]
    [InlineData(";500:1,1000:2,2000:3,5000:4,10000:5,20000:6", 198500)]
    [InlineData("5:1,10:1;500:1", 515)]
    public void HufParseAndTotalAmountShouldBeCorrect(string input, decimal expectedTotal)
    {
        var mk = MoneyKind<HufCurrency>.Parse(input);
        mk.TotalAmount().ShouldBe(expectedTotal);
    }

    /// <summary>Verifies that HUF values are rounded to the minimum unit (5).</summary>
    [Theory]
    [InlineData(1232, 1230)]
    [InlineData(1233, 1235)]
    [InlineData(1237, 1235)]
    [InlineData(1238, 1240)]
    public void HufRoundingShouldBeCorrect(decimal input, decimal expected)
    {
        var mk = new MoneyKind<HufCurrency>();
        mk.RoundToMinimumUnit(input).ShouldBe(expected);
    }

    /// <summary>ToCashCountsString tests for HufCurrency.</summary>
    [Fact]
    public void HufToCashCountsStringShouldBeCorrect()
    {
        var mk = new MoneyKind<HufCurrency>();

        mk[1000m] = 5;
        mk[10m] = 3;

        var result = mk.ToCashCountsString();

        result.ShouldContain("10:3");
        result.ShouldContain("1000:5");
    }
}
