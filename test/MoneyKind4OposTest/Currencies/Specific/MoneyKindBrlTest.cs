using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest;

/// <summary>MoneyKind&lt;BrlCurrency&gt; tests.</summary>
public class MoneyKindBrlTest
{
    [Theory]
    [InlineData("0.01:1;1:1", 1.01)]
    [InlineData("0.50:1;50:1", 50.50)]
    public void Brl_Parse_ShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<BrlCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
