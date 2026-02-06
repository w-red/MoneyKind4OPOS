using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest;

/// <summary>MoneyKind&lt;HkdCurrency&gt; tests.</summary>
public class MoneyKindHkdTest
{
    [Theory]
    [InlineData("0.1:1,10:1;10:1", 20.1)]
    [InlineData("10:1;1000:1", 1010)]
    public void HkdParseShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<HkdCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
