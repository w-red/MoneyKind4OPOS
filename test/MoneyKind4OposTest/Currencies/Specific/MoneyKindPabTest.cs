using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;PabCurrency&gt; tests.</summary>
public class MoneyKindPabTest
{
    /// <summary>Verifies that PAB cash-count strings are parsed and total amounts calculated correctly.</summary>
    [Theory]
    [InlineData("", 0)]
    [InlineData("0.01:1,0.05:1,0.1:1,0.25:1,0.5:1,1:1;1:1,2:1,5:1,10:1,20:1,50:1,100:1", 189.91)]
    public void PabParseAndTotalAmountShouldBeCorrect(string input, decimal expectedTotal)
    {
        var mk = MoneyKind<PabCurrency>.Parse(input);
        mk.TotalAmount().ShouldBe(expectedTotal);
    }

    /// <summary>Verifies that PAB values are rounded to the minimum unit (0.01).</summary>
    [Theory]
    [InlineData(1234.567, 1234.57)]
    public void PabRoundingShouldBeCorrect(decimal input, decimal expected)
    {
        var mk = new MoneyKind<PabCurrency>();
        mk.RoundToMinimumUnit(input).ShouldBe(expected);
    }
}
