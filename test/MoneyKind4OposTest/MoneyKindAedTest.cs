using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest;

/// <summary>MoneyKind&lt;AedCurrency&gt; tests.</summary>
public class MoneyKindAedTest
{
    [Theory]
    [InlineData("0.25:1,1:1;5:1", 6.25)]
    [InlineData("0.5:1;5:1,20:1", 25.50)]
    public void Aed_Parse_ShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<AedCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
