using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;VndCurrency&gt; tests.</summary>
public class MoneyKindVndTest
{
    /// <summary>Verifies that VND values are rounded to the minimum unit (1000).</summary>
    [Theory]
    [InlineData(1234, 1000)]
    [InlineData(1500, 2000)] // Midpoint: rounds to even (2000 is 2 * 1000)
    [InlineData(2500, 2000)] // Midpoint: rounds to even (2000 is 2 * 1000)
    [InlineData(3500, 4000)] // Midpoint: rounds to even (4000 is 4 * 1000)
    [InlineData(1001, 1000)]
    [InlineData(1999, 2000)]
    public void VndRoundingShouldBeCorrect(decimal input, decimal expected)
    {
        var mk = new MoneyKind<VndCurrency>();
        mk.RoundToMinimumUnit(input).ShouldBe(expected);
    }
}
