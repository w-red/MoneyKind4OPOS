using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest;

/// <summary>MoneyKind&lt;TwdCurrency&gt; tests.</summary>
public class MoneyKindTwdTest
{
    [Theory]
    [InlineData("1:1;100:1", 101)]
    [InlineData("50:1;2000:1", 2050)]
    public void Twd_Parse_ShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<TwdCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
