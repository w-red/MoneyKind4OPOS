using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;
using Xunit;

namespace MoneyKind4OposTest;

/// <summary>MoneyKind&lt;IlsCurrency&gt; tests.</summary>
public class MoneyKindIlsTest
{
    [Theory]
    [InlineData("0.01:1,1:1;500:1", 501.01)]
    [InlineData("0.5:1;50:1,100:1", 150.5)]
    public void Ils_Parse_ShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<IlsCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
