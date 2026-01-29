using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using MoneyKind4Opos.Codes;
using Shouldly;

namespace MoneyKind4OPOSTest;

public class MoneyKindXcdTest
{
    [Theory]
    [InlineData("0.05:2,1:1", 1.10)]
    [InlineData(";10:1", 10.0)]
    public void Xcd_Parse_ShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<XcdCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }

    [Fact]
    public void Xcd_CurrencyInfo_ShouldBeCorrect()
    {
        XcdCurrency.Code.ShouldBe(Iso4217.XCD);
        XcdCurrency.MinimumUnit.ShouldBe(0.05m);
    }
}
