using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;KydCurrency&gt; tests.</summary>
public class MoneyKindKydTest
{
    [Theory]
    [InlineData("0.01:1;1:1", 1.01)]
    [InlineData("0.25:1;100:1", 100.25)]
    public void KydParseShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<KydCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
