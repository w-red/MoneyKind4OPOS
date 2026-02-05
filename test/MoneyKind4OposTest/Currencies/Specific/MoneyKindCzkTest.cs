using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest;

/// <summary>MoneyKind&lt;CzkCurrency&gt; tests.</summary>
public class MoneyKindCzkTest
{
    [Theory]
    [InlineData("1:1;100:1", 101)]
    [InlineData("50:1;5000:1", 5050)]
    public void Czk_Parse_ShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<CzkCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
