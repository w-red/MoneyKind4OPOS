using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;MkdCurrency&gt; (Macedonian Denar) tests.</summary>
public class MoneyKindMkdTest
{
    /// <summary>Verifies that MKD cash-count strings are parsed and total amounts calculated correctly.</summary>
    [Theory]
    [InlineData("1:1,2:1,5:1,10:1,50:1;10:1,50:1,100:1,200:1,500:1,1000:1,2000:1", 3928)]
    [InlineData("1:10;10:5", 60)]
    public void MkdParseShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<MkdCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
