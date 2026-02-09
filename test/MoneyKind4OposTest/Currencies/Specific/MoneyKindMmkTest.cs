using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;MmkCurrency&gt; tests.</summary>
public class MoneyKindMmkTest
{
    /// <summary>Verifies that MMK values are rounded to the minimum unit (100).</summary>
    [Theory]
    [InlineData(150, 200)] // Midpoint: rounds to even (200 is 2 * 100)
    [InlineData(250, 200)] // Midpoint: rounds to even (200 is 2 * 100)
    [InlineData(350, 400)] // Midpoint: rounds to even (400 is 4 * 100)
    [InlineData(149, 100)]
    [InlineData(151, 200)]
    [InlineData(1234, 1200)]
    [InlineData(1256, 1300)]
    public void MmkRoundingShouldBeCorrect(decimal input, decimal expected)
    {
        var mk = new MoneyKind<MmkCurrency>();
        mk.RoundToMinimumUnit(input).ShouldBe(expected);
    }
}
