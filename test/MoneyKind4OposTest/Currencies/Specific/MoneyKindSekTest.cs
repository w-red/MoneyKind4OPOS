using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;SekCurrency&gt; tests.</summary>
public class MoneyKindSekTest
{
    /// <summary>Verifies that SEK cash-count strings are parsed and total amounts calculated correctly.</summary>
    [Theory]
    [InlineData("1:1;20:1", 21)]
    [InlineData("10:1;1000:1", 1010)]
    public void SekParseShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<SekCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
