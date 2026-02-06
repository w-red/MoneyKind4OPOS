using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using MoneyKind4Opos.Codes;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;ZarCurrency&gt; tests.</summary>
public class MoneyKindZarTest
{
    /// <summary>Verifies that ZAR cash-count strings are parsed and total amounts calculated correctly.</summary>
    [Theory]
    [InlineData("0.1:5,1:2", 2.5)]
    [InlineData(";10:1", 10.0)]
    public void ZarParseShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<ZarCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }

    [Fact]
    public void ZarCurrencyInfoShouldBeCorrect()
    {
        ZarCurrency.Code.ShouldBe(Iso4217.ZAR);
        ZarCurrency.MinimumUnit.ShouldBe(0.10m);
    }
}
