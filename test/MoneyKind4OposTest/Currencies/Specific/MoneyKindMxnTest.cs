using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest;

/// <summary>MoneyKind&lt;MxnCurrency&gt; tests.</summary>
public class MoneyKindMxnTest
{
    [Theory]
    [InlineData("0.1:1;20:1", 20.1)]
    [InlineData("20:1;1000:1", 1020)]
    public void MxnParseShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<MxnCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
