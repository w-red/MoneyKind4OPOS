using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;RsdCurrency&gt; (Serbian Dinar) tests.</summary>
public class MoneyKindRsdTest
{
    /// <summary>Verifies that RSD cash-count strings are parsed and total amounts calculated correctly.</summary>
    [Theory]
    [InlineData("1:1,2:1,5:1,10:1,20:1;10:1,20:1,50:1,100:1,200:1,500:1,1000:1,2000:1,5000:1", 8918)]
    [InlineData("20:5;50:2", 200)]
    public void RsdParseShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<RsdCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
