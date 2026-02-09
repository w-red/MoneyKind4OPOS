using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;BzdCurrency&gt; tests.</summary>
public class MoneyKindBzdTest
{
    /// <summary>Verifies that BZD cash-count strings are parsed and total amounts calculated correctly.</summary>
    [Theory]
    [InlineData("", 0)]
    [InlineData("0.01:1,0.05:1,0.1:1,0.25:1,0.5:1,1:1;2:1,5:1,10:1,20:1,50:1,100:1", 188.91)]
    public void BzdParseAndTotalAmountShouldBeCorrect(string input, decimal expectedTotal)
    {
        var mk = MoneyKind<BzdCurrency>.Parse(input);
        mk.TotalAmount().ShouldBe(expectedTotal);
    }

    /// <summary>Verifies that BZD values are rounded to the minimum unit (0.01).</summary>
    [Theory]
    [InlineData(1234.567, 1234.57)]
    public void BzdRoundingShouldBeCorrect(decimal input, decimal expected)
    {
        var mk = new MoneyKind<BzdCurrency>();
        mk.RoundToMinimumUnit(input).ShouldBe(expected);
    }
}
