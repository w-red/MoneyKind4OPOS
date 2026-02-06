using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;IlsCurrency&gt; tests.</summary>
public class MoneyKindIlsTest
{
    [Theory]
    [InlineData("0.1:1;20:1", 20.1)]
    [InlineData("10:1;200:1", 210.0)]
    public void IlsParseShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<IlsCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
