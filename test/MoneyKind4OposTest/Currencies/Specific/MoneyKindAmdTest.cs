using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;AmdCurrency&gt; tests.</summary>
public class MoneyKindAmdTest
{
    /// <summary>Verifies that AMD values are rounded to the minimum unit (10).</summary>
    [Theory]
    [InlineData(123, 120)]
    [InlineData(125, 120)] // Midpoint: rounds to even (120 is 12 * 10)
    [InlineData(135, 140)] // Midpoint: rounds to even (140 is 14 * 10)
    [InlineData(124, 120)]
    [InlineData(126, 130)]
    [InlineData(1234, 1230)]
    [InlineData(1236, 1240)]
    public void AmdRoundingShouldBeCorrect(decimal input, decimal expected)
    {
        var mk = new MoneyKind<AmdCurrency>();
        mk.RoundToMinimumUnit(input).ShouldBe(expected);
    }
}
