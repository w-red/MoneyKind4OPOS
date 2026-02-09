using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;CopCurrency&gt; tests.</summary>
public class MoneyKindCopTest
{
    /// <summary>Verifies that COP values are rounded to the minimum unit (50).</summary>
    [Theory]
    [InlineData(123, 100)]
    [InlineData(125, 100)] // Midpoint: rounds to even (100 is 2 * 50)
    [InlineData(175, 200)] // Midpoint: rounds to even (200 is 4 * 50)
    [InlineData(149, 150)]
    [InlineData(151, 150)]
    [InlineData(74, 50)]
    [InlineData(76, 100)]
    public void CopRoundingShouldBeCorrect(decimal input, decimal expected)
    {
        var mk = new MoneyKind<CopCurrency>();
        mk.RoundToMinimumUnit(input).ShouldBe(expected);
    }
}
