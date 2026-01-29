using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OPOSTest;

public class MoneyKindCadTest
{
    [Theory]
    [InlineData("0.05:1;5:1", 5.05)]
    [InlineData(";50:1,100:1", 150.0)]
    public void Cad_Parse_ShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<CadCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }

    [Fact]
    public void Cad_CurrencyInfo_ShouldBeCorrect()
    {
        CadCurrency.Code.ShouldBe(Iso4217.CAD);
        CadCurrency.MinimumUnit.ShouldBe(0.05m);
    }
}
