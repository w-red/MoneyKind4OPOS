using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;RubCurrency&gt; tests.</summary>
public class MoneyKindRubTest
{
    [Theory]
    [InlineData("0.01:1;5:1", 5.01)]
    [InlineData("10:1;5000:1", 5010)]
    public void RubParseShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<RubCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
