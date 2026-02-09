using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;HnlCurrency&gt; tests.</summary>
public class MoneyKindHnlTest
{
    /// <summary>Verifies that HNL cash-count strings are parsed and total amounts calculated correctly.</summary>
    [Theory]
    [InlineData("", 0)]
    [InlineData("0.05:1,0.1:1,0.2:1,0.5:1;1:1,2:1,5:1,10:1,20:1,50:1,100:1,200:1,500:1", 888.85)]
    public void HnlParseAndTotalAmountShouldBeCorrect(string input, decimal expectedTotal)
    {
        var mk = MoneyKind<HnlCurrency>.Parse(input);
        mk.TotalAmount().ShouldBe(expectedTotal);
    }

    /// <summary>Verifies that HNL values are rounded to the minimum unit (0.05).</summary>
    [Theory]
    [InlineData(1234.57, 1234.55)]
    [InlineData(1234.58, 1234.60)]
    public void HnlRoundingShouldBeCorrect(decimal input, decimal expected)
    {
        var mk = new MoneyKind<HnlCurrency>();
        mk.RoundToMinimumUnit(input).ShouldBe(expected);
    }
}
