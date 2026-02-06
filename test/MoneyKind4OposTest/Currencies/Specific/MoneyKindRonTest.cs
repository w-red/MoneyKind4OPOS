using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;RonCurrency&gt; (Romanian Leu) tests.</summary>
public class MoneyKindRonTest
{
    /// <summary>Verifies that RON cash-count strings are parsed and total amounts calculated correctly.</summary>
    [Theory]
    [InlineData("0.01:1,0.05:1,0.1:1,0.5:1;1:1,5:1,10:1,50:1,100:1,200:1,500:1", 866.66)]
    [InlineData("0.5:10;10:5", 55)]
    public void RonParseShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<RonCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
