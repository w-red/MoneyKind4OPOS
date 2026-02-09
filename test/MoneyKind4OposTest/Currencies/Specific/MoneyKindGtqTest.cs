using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;GtqCurrency&gt; tests.</summary>
public class MoneyKindGtqTest
{
    /// <summary>Verifies that GTQ cash-count strings are parsed and total amounts calculated correctly.</summary>
    [Theory]
    [InlineData("", 0)]
    [InlineData("0.01:1,0.05:1,0.1:1,0.25:1,0.5:1,1:1;1:1,5:1,10:1,20:1,50:1,100:1,200:1", 387.91)]
    public void GtqParseAndTotalAmountShouldBeCorrect(string input, decimal expectedTotal)
    {
        var mk = MoneyKind<GtqCurrency>.Parse(input);
        mk.TotalAmount().ShouldBe(expectedTotal);
    }

    /// <summary>Verifies that GTQ values are rounded correctly (minimum unit 0.01).</summary>
    [Theory]
    [InlineData(1234.567, 1234.57)]
    [InlineData(1234.564, 1234.56)]
    public void GtqRoundingShouldBeCorrect(decimal input, decimal expected)
    {
        var mk = new MoneyKind<GtqCurrency>();
        mk.RoundToMinimumUnit(input).ShouldBe(expected);
    }
}
