using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;AllCurrency&gt; (Albanian Lek) tests.</summary>
public class MoneyKindAllTest
{
    /// <summary>Verifies that ALL cash-count strings are parsed and total amounts calculated correctly.</summary>
    [Theory]
    [InlineData("1:1,5:1,10:1,20:1,50:1,100:1;200:1,500:1,1000:1,2000:1,5000:1,10000:1", 18886)]
    [InlineData("1:10,100:5;200:2", 910)]
    public void AllParseShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<AllCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
