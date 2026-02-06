using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;KwdCurrency&gt; tests.</summary>
public class MoneyKindKwdTest
{
    /// <summary>Verifies that KWD cash-count strings are parsed and total amounts calculated correctly.</summary>
    [Theory]
    [InlineData("0.001:1;1:1", 1.001)]
    [InlineData("0.100:1;0.250:1,20:1", 20.350)]
    public void KwdParseShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<KwdCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
