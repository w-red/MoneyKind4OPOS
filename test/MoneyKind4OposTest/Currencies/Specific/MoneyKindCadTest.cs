using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;CadCurrency&gt; tests.</summary>
public class MoneyKindCadTest
{
    [Theory]
    [InlineData("0.05:1;5:1", 5.05)]
    [InlineData(";50:1,100:1", 150.0)]
    public void CadParseShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<CadCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }

    [Fact]
    public void CadCurrencyInfoShouldBeCorrect()
    {
        CadCurrency.Code.ShouldBe(Iso4217.CAD);
        CadCurrency.MinimumUnit.ShouldBe(0.05m);
    }
}
