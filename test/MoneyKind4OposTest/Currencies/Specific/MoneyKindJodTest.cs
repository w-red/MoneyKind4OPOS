using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest;

/// <summary>MoneyKind&lt;JodCurrency&gt; tests.</summary>
public class MoneyKindJodTest
{
    [Theory]
    [InlineData("0.01:1;1:1", 1.01)]
    [InlineData("0.50:1;50:1", 50.50)]
    public void JodParseShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<JodCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
