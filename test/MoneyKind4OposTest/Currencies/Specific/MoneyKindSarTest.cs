using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;SarCurrency&gt; tests.</summary>
public class MoneyKindSarTest
{
    [Theory]
    [InlineData("0.01:1,1:1;500:1", 501.01)]
    [InlineData("0.5:1;50:1,100:1", 150.5)]
    public void SarParseShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<SarCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
