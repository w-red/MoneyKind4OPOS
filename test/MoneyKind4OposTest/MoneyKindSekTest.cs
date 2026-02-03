using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest;

/// <summary>MoneyKind&lt;SekCurrency&gt; tests.</summary>
public class MoneyKindSekTest
{
    [Theory]
    [InlineData("0.01:1;1:1", 1.01)]
    [InlineData("0.25:1;100:1", 100.25)]
    public void Sek_Parse_ShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<SekCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
