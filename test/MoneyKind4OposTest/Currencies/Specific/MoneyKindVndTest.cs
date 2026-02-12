using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;VndCurrency&gt; tests.</summary>
public class MoneyKindVndTest
{
    /// <summary>Verifies that VND values are rounded to the minimum unit (1000).</summary>
    [Theory]
    [InlineData(1234, 1200)]
    [InlineData(1050, 1000)] // Midpoint (10 * 100 is even)
    [InlineData(1150, 1200)] // Midpoint (12 * 100 is even)
    [InlineData(1500, 1500)] // Exact multiple of 100
    [InlineData(2500, 2500)] // Exact multiple of 100
    [InlineData(3500, 3500)] // Exact multiple of 100
    [InlineData(1001, 1000)]
    [InlineData(1999, 2000)]
    public void VndRoundingShouldBeCorrect(decimal input, decimal expected)
    {
        var mk = new MoneyKind<VndCurrency>();
        mk.RoundToMinimumUnit(input).ShouldBe(expected);
    }
}
