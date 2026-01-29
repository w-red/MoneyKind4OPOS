using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using MoneyKind4Opos.Codes;
using Shouldly;

namespace MoneyKind4OPOSTest;

public class MoneyKindZarTest
{
    [Theory]
    [InlineData("0.1:5,1:2", 2.5)]
    [InlineData(";10:1", 10.0)]
    public void Zar_Parse_ShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<ZarCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }

    [Fact]
    public void Zar_CurrencyInfo_ShouldBeCorrect()
    {
        ZarCurrency.Code.ShouldBe(Iso4217.ZAR);
        ZarCurrency.MinimumUnit.ShouldBe(0.10m);
    }
}
