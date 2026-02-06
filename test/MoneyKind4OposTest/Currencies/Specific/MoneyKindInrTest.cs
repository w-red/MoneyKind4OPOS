using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;InrCurrency&gt; tests.</summary>
public class MoneyKindInrTest
{
    /// <summary>Parse and TotalAmount tests for InrCurrency.</summary>
    [Theory]
    [InlineData("", 0)]
    [InlineData(";", 0)]
    [InlineData("1:1,2:1,5:1,10:1,20:1;10:1,20:1,50:1,100:1,200:1,500:1", 918)]
    [InlineData("0.5:2,1:10;", 11)] // Coins only (50 paise * 2 + 1 * 10)
    [InlineData(";100:5,500:2", 1500)] // Bills only
    [InlineData("1:10,2:5;50:2,200:1", 320)]
    public void InrParseAndTotalAmountShouldBeCorrect(
        string input, decimal expectedTotal)
    {
        var mk = MoneyKind<InrCurrency>.Parse(input);
        mk.TotalAmount().ShouldBe(expectedTotal);
    }

    /// <summary>ToCashCountsString tests for InrCurrency.</summary>
    [Fact]
    public void InrToCashCountsStringShouldBeCorrect()
    {
        var mk = new MoneyKind<InrCurrency>();

        mk[500m] = 2; // bill
        mk[100m] = 5; // bill
        mk[2m] = 10;  // coin
        mk[0.5m] = 4; // coin (50 paise)

        var result = mk.ToCashCountsString();

        // Expect specific order or presence
        // result example: "0.5:4,2:10;100:5,500:2"
        result.ShouldContain("0.5:4");
        result.ShouldContain("2:10");
        result.ShouldContain("100:5");
        result.ShouldContain("500:2");

        // Structure check
        result.ShouldContain(";");
    }

    /// <summary>Tests the Indian digit grouping (Lakh/Crore system).</summary>
    [Fact]
    public void InrGroupingShouldFollowIndianSystem()
    {
        var amount = 123456.78m;
        var formatted = amount.ToString("N", InrCurrency.Global.NumberFormat);

        // Expected: 1,23,456.78 (Indian system)
        // Default: 123,456.78 (Western system)
        formatted.ShouldBe("1,23,456.78");
    }
}
