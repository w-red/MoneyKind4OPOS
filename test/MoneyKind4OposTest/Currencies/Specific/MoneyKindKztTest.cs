using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest;

/// <summary>MoneyKind&lt;KztCurrency&gt; tests.</summary>
public class MoneyKindKztTest
{
    [Theory]
    [InlineData("1:1;200:1", 201)]
    [InlineData("200:1;200:1", 400)]
    [InlineData("1:1,2:1,5:1,10:1,20:1,50:1,100:1,200:1;200:1,500:1,1000:1,2000:1,5000:1,10000:1,20000:1", 39088)]
    public void KztParseShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<KztCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
