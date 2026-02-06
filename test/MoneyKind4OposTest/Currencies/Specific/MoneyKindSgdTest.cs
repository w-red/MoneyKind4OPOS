using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using MoneyKind4Opos.Codes;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;SgdCurrency&gt; tests.</summary>
public class MoneyKindSgdTest
{
    [Theory]
    [InlineData("0.05:1;5:1", 5.05)]
    [InlineData(";50:1,100:1,1000:1", 1150.0)]
    public void SgdParseShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<SgdCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }

    [Fact]
    public void SgdCurrencyInfoShouldBeCorrect()
    {
        SgdCurrency.Code.ShouldBe(Iso4217.SGD);
        SgdCurrency.MinimumUnit.ShouldBe(0.05m);
    }
}
