using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;DkkCurrency&gt; tests.</summary>
public class MoneyKindDkkTest
{
    /// <summary>Verifies that DKK cash-count strings are parsed and total amounts calculated correctly.</summary>
    [Theory]
    [InlineData("0.5:1;50:1", 50.5)]
    [InlineData("20:1;500:1", 520.0)]
    public void DkkParseShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<DkkCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
