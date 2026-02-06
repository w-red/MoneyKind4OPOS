using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;QarCurrency&gt; tests.</summary>
public class MoneyKindQarTest
{
    /// <summary>Verifies that QAR cash-count strings are parsed and total amounts calculated correctly.</summary>
    [Theory]
    [InlineData("0.01:1;1:1", 1.01)]
    [InlineData("0.05:1,0.1:1;50:1", 50.15)]
    public void QarParseShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<QarCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
