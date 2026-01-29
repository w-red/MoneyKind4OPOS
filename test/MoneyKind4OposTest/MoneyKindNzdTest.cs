using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using MoneyKind4Opos.Codes;
using Shouldly;

namespace MoneyKind4OPOSTest;

public class MoneyKindNzdTest
{
    [Theory]
    [InlineData("0.1:10,1:5", 6.0)]
    [InlineData(";20:1", 20.0)]
    public void Nzd_Parse_ShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<NzdCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }

    [Fact]
    public void Nzd_CurrencyInfo_ShouldBeCorrect()
    {
        NzdCurrency.Code.ShouldBe(Iso4217.NZD);
        NzdCurrency.MinimumUnit.ShouldBe(0.10m);
    }
}
