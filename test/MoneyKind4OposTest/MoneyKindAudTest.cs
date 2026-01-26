using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OPOSTest;

/// <summary>MoneyKind&lt;AudCurrency&gt; tests.</summary>
public class MoneyKindAudTest
{
    /// <summary>Parse and TotalAmount tests for AudCurrency.</summary>
    [Theory]
    [InlineData("", 0)]
    [InlineData(";", 0)]
    [InlineData("0.05:1,0.1:2,0.2:3,0.5:4,1:5,2:6;5:7,10:8,20:9,50:10,100:11", 1914.85)]
    [InlineData("0.05:10,0.1:5;", 1.0)] // Coins only
    [InlineData(";20:5,50:2", 200)]     // Bills only
    [InlineData("1:10,2:5;10:2,100:1", 140)]
    public void Aud_Parse_And_TotalAmount_ShouldBeCorrect(
        string input, decimal expectedTotal)
    {
        var mk = MoneyKind<AudCurrency>.Parse(input);
        mk.TotalAmount().ShouldBe(expectedTotal);
    }

    /// <summary>ToCashCountsString tests for AudCurrency.</summary>
    [Fact]
    public void Aud_ToCashCountsString_ShouldBeCorrect()
    {
        var mk = new MoneyKind<AudCurrency>();

        mk[100m] = 2; // bill
        mk[50m] = 5;  // bill
        mk[2m] = 10;  // coin
        mk[0.05m] = 4; // coin (5 cents)

        var result = mk.ToCashCountsString();

        // Expect specific order or presence
        result.ShouldContain("0.05:4");
        result.ShouldContain("2:10");
        result.ShouldContain("50:5");
        result.ShouldContain("100:2");
        
        // Structure check
        result.ShouldContain(";");
    }
}
