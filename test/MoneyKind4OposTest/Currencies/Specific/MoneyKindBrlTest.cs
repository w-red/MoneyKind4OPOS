using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;BrlCurrency&gt; tests.</summary>
public class MoneyKindBrlTest
{
    /// <summary>Verifies that BRL cash-count strings are parsed and total amounts calculated correctly.</summary>
    [Theory]
    [InlineData("0.01:1;1:1", 1.01)]
    [InlineData("0.50:1;50:1", 50.50)]
    public void BrlParseShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<BrlCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
