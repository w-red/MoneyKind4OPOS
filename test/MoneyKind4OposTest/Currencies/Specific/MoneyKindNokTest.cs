using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using MoneyKind4Opos.Codes;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;NokCurrency&gt; tests.</summary>
public class MoneyKindNokTest
{
    /// <summary>Verifies that NOK cash-count strings are parsed and total amounts calculated correctly.</summary>
    [Theory]
    [InlineData("1:1;50:1", 51.0)]
    [InlineData(";500:1,1000:1", 1500.0)]
    public void NokParseShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<NokCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }

    [Fact]
    public void NokCurrencyInfoShouldBeCorrect()
    {
        NokCurrency.Code.ShouldBe(Iso4217.NOK);
        NokCurrency.MinimumUnit.ShouldBe(1.00m);
    }
}
