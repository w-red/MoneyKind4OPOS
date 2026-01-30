using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;
using Xunit;

namespace MoneyKind4OposTest;

public class MoneyKindKwdTest
{
    [Theory]
    [InlineData("0.001:1;1:1", 1.001)]
    [InlineData("0.100:1;0.250:1,20:1", 20.350)]
    public void Kwd_Parse_ShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<KwdCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
