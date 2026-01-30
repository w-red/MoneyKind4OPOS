using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;
using Xunit;

namespace MoneyKind4OposTest;

public class MoneyKindJodTest
{
    [Theory]
    [InlineData("0.01:1;1:1", 1.01)]
    [InlineData("0.50:1;50:1", 50.50)]
    public void Jod_Parse_ShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<JodCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
