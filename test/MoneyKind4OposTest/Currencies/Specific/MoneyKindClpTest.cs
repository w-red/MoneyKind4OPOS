using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;ClpCurrency&gt; tests.</summary>
public class MoneyKindClpTest
{
    /// <summary>Verifies that CLP cash-count strings are parsed and total amounts calculated correctly.</summary>
    [Theory]
    [InlineData("10:1;1000:1", 1010)]
    [InlineData("100:1;20000:1", 20100)]
    public void ClpParseShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<ClpCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
