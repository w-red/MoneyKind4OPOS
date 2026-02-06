using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using MoneyKind4Opos.Codes;
using Shouldly;

namespace MoneyKind4OPOSTest;

/// <summary>MoneyKind&lt;XafCurrency&gt; tests.</summary>
public class MoneyKindXafTest
{
    [Theory]
    [InlineData("500:2;1000:1", 2000)]
    public void XafParseShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<XafCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }

    [Fact]
    public void XafCurrencyInfoShouldBeCorrect()
    {
        XafCurrency.Code.ShouldBe(Iso4217.XAF);
    }
}
