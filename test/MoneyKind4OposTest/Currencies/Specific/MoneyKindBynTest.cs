using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;BynCurrency&gt; tests.</summary>
public class MoneyKindBynTest
{
    /// <summary>Verifies that BYN cash-count strings are parsed and total amounts calculated correctly.</summary>
    [Theory]
    [InlineData("0.01:1;5:1", 5.01)]
    [InlineData("2:1;500:1", 502)]
    [InlineData("0.01:1,0.02:1,0.05:1,0.1:1,0.2:1,0.5:1,1:1,2:1;5:1,10:1,20:1,50:1,100:1,200:1,500:1", 888.88)]
    public void BynParseShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<BynCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
