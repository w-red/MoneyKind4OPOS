using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;
using Xunit;

namespace MoneyKind4OposTest;

/// <summary>MoneyKind&lt;IlsCurrency&gt; tests.</summary>
public class MoneyKindIlsTest
{
    [Theory]
    [InlineData("0.1:1;20:1", 20.1)]
    [InlineData("10:1;200:1", 210.0)]
    public void Ils_Parse_ShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<IlsCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
