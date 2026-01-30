using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest;

public class MoneyKindBhdTest
{
    [Theory]
    [InlineData("0.005:1;1:1", 1.005)]
    [InlineData("0.5:1;0.5:1,25:1", 26.000)]
    public void Bhd_Parse_ShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<BhdCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
