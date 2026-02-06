using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using MoneyKind4Opos.Codes;
using Shouldly;

namespace MoneyKind4OPOSTest;

/// <summary>MoneyKind&lt;NzdCurrency&gt; tests.</summary>
public class MoneyKindNzdTest
{
    [Theory]
    [InlineData("0.1:10,1:5", 6.0)]
    [InlineData(";20:1", 20.0)]
    public void NzdParseShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<NzdCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }

    [Fact]
    public void NzdCurrencyInfoShouldBeCorrect()
    {
        NzdCurrency.Code.ShouldBe(Iso4217.NZD);
        NzdCurrency.MinimumUnit.ShouldBe(0.10m);
    }
}
