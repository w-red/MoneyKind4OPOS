using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using MoneyKind4Opos.Codes;
using Shouldly;

namespace MoneyKind4OPOSTest;

public class MoneyKindXofTest
{
    [Theory]
    [InlineData("100:1,500:2", 1100)]
    public void Xof_Parse_ShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<XofCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
    
    [Fact]
    public void Xof_CurrencyInfo_ShouldBeCorrect()
    {
        XofCurrency.Code.ShouldBe(Iso4217.XOF);
    }
}
