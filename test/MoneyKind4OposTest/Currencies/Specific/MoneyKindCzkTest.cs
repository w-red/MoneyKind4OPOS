using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;CzkCurrency&gt; tests.</summary>
public class MoneyKindCzkTest
{
    /// <summary>Verifies that CZK cash-count strings are parsed and total amounts calculated correctly.</summary>
    [Theory]
    [InlineData("1:1;100:1", 101)]
    [InlineData("50:1;5000:1", 5050)]
    public void CzkParseShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<CzkCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
