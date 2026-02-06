using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;MdlCurrency&gt; (Moldovan Leu) tests.</summary>
public class MoneyKindMdlTest
{
    /// <summary>Verifies that MDL cash-count strings are parsed and total amounts calculated correctly.</summary>
    [Theory]
    [InlineData("0.01:1,0.05:1,0.1:1,0.25:1,0.5:1,1:1,2:1,5:1,10:1;1:1,5:1,10:1,20:1,50:1,100:1,200:1,500:1,1000:1", 1904.91)]
    [InlineData("1:10;10:5", 60)]
    public void MdlParseShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<MdlCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
