using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using MoneyKind4Opos.Codes;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;XcdCurrency&gt; tests.</summary>
public class MoneyKindXcdTest
{
    /// <summary>Verifies that XCD cash-count strings are parsed and total amounts calculated correctly.</summary>
    [Theory]
    [InlineData("0.05:2,1:1", 1.10)]
    [InlineData(";10:1", 10.0)]
    public void XcdParseShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<XcdCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }

    [Fact]
    public void XcdCurrencyInfoShouldBeCorrect()
    {
        XcdCurrency.Code.ShouldBe(Iso4217.XCD);
        XcdCurrency.MinimumUnit.ShouldBe(0.05m);
    }
}
