using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest;

/// <summary>MoneyKind&lt;MxnCurrency&gt; tests.</summary>
public class MoneyKindMxnTest
{
    [Theory]
    [InlineData("0.01:1,1:1;500:1", 501.01)]
    [InlineData("0.5:1;50:1,100:1", 150.5)]
    public void Mxn_Parse_ShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<MxnCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
