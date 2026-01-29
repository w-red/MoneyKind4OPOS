using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using MoneyKind4Opos.Codes;
using Shouldly;

namespace MoneyKind4OPOSTest;

public class MoneyKindNokTest
{
    [Theory]
    [InlineData("1:1;50:1", 51.0)]
    [InlineData(";500:1,1000:1", 1500.0)]
    public void Nok_Parse_ShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<NokCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }

    [Fact]
    public void Nok_CurrencyInfo_ShouldBeCorrect()
    {
        NokCurrency.Code.ShouldBe(Iso4217.NOK);
        NokCurrency.MinimumUnit.ShouldBe(1.00m);
    }
}
