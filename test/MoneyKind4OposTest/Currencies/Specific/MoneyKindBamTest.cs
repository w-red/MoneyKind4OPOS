using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;BamCurrency&gt; (Bosnia-Herzegovina Convertible Mark) tests.</summary>
public class MoneyKindBamTest
{
    /// <summary>Verifies that BAM cash-count strings are parsed and total amounts calculated correctly.</summary>
    [Theory]
    [InlineData("0.05:1,0.1:1,0.2:1,0.5:1,1:1,2:1,5:1;10:1,20:1,50:1,100:1,200:1", 388.85)]
    [InlineData("0.5:10;10:5", 55)]
    public void BamParseShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<BamCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
