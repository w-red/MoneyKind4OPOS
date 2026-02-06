using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;UzsCurrency&gt; tests.</summary>
public class MoneyKindUzsTest
{
    [Theory]
    [InlineData("50:1;1000:1", 1050)]
    [InlineData("1000:1;1000:1", 2000)]
    [InlineData("50:1,100:1,200:1,500:1,1000:1;1000:1,2000:1,5000:1,10000:1,20000:1,50000:1,100000:1,200000:1", 389850)]
    public void UzsParseShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<UzsCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
