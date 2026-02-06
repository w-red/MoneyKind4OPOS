using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest;

/// <summary>MoneyKind&lt;BndCurrency&gt; tests.</summary>
public class MoneyKindBndTest
{
    [Theory]
    [InlineData("0.01:1;1:1", 1.01)]
    [InlineData("0.5:1;100:1", 100.5)]
    public void BndParseShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<BndCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
