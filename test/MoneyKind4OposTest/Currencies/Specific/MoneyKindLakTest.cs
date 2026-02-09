using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;LakCurrency&gt; tests.</summary>
public class MoneyKindLakTest
{
    /// <summary>Verifies that LAK values are rounded to the minimum unit (500).</summary>
    [Theory]
    [InlineData(1234, 1000)]
    [InlineData(1250, 1000)] // Midpoint: rounds to even (1000 is 2 * 500)
    [InlineData(1750, 2000)] // Midpoint: rounds to even (2000 is 4 * 500)
    [InlineData(1499, 1500)]
    [InlineData(1501, 1500)]
    [InlineData(2749, 2500)]
    [InlineData(2751, 3000)]
    public void LakRoundingShouldBeCorrect(decimal input, decimal expected)
    {
        var mk = new MoneyKind<LakCurrency>();
        mk.RoundToMinimumUnit(input).ShouldBe(expected);
    }
}
