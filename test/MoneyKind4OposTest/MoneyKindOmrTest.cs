using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;
using Xunit;

namespace MoneyKind4OposTest;

public class MoneyKindOmrTest
{
    [Theory]
    [InlineData("0.005:1;1:1", 1.005)]
    [InlineData("0.050:1;0.100:1,50:1", 50.150)]
    public void Omr_Parse_ShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<OmrCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
