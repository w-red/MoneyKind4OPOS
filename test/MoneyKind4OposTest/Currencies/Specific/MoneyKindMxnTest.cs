using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;MxnCurrency&gt; tests.</summary>
public class MoneyKindMxnTest
{
    /// <summary>Verifies that MXN cash-count strings are parsed and total amounts calculated correctly.</summary>
    [Theory]
    [InlineData("0.1:1;20:1", 20.1)]
    [InlineData("20:1;1000:1", 1020)]
    public void MxnParseShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<MxnCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
