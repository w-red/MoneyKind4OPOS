using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;AudCurrency&gt; tests.</summary>
public class MoneyKindAudTest
{
    /// <summary>Verifies that AUD cash-count strings are parsed and total amounts calculated correctly.</summary>
    [Theory]
    [InlineData("", 0)]
    [InlineData(";", 0)]
    [InlineData("0.05:1,0.1:2,0.2:3,0.5:4,1:5,2:6;5:7,10:8,20:9,50:10,100:11", 1914.85)]
    [InlineData("0.05:10,0.1:5;", 1.0)] // Coins only
    [InlineData(";20:5,50:2", 200)]     // Bills only
    [InlineData("1:10,2:5;10:2,100:1", 140)]
    public void AudParseAndTotalAmountShouldBeCorrect(
        string input, decimal expectedTotal)
    {
        var mk = MoneyKind<AudCurrency>.Parse(input);
        mk.TotalAmount().ShouldBe(expectedTotal);
    }

    /// <summary>Verifies that an AUD MoneyKind instance is correctly serialized to a cash-count string.</summary>
    [Fact]
    public void AudToCashCountsStringShouldBeCorrect()
    {
        var mk = new MoneyKind<AudCurrency>();

        mk[100m] = 2;   // bill
        mk[50m] = 5;    // bill
        mk[2m] = 10;    // coin
        mk[0.05m] = 4;  // coin (5 cents)

        var result = mk.ToCashCountsString();

        // Expected format: "coinFace1:count1,...;billFace1:count1,..."
        result.ShouldBe("0.05:4,0.1:0,0.2:0,0.5:0,1:0,2:10;5:0,10:0,20:0,50:5,100:2");
    }
}
