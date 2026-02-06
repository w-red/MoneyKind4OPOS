using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;BhdCurrency&gt; tests.</summary>
public class MoneyKindBhdTest
{
    /// <summary>Verifies that BHD cash-count strings are parsed and total amounts calculated correctly.</summary>
    [Theory]
    [InlineData("0.5:1;0.5:1,20:1", 21)]
    [InlineData("0.1:1;1:1", 1.1)]
    public void BhdParseShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<BhdCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
