using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;KrwCurrency&gt; tests.</summary>
public class MoneyKindKrwTest
{
    [Theory]
    [InlineData("1:1;1000:1", 1001)]
    [InlineData("500:1;50000:1", 50500)]
    public void KrwParseShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<KrwCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
