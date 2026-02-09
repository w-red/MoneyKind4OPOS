using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;IqdCurrency&gt; tests.</summary>
public class MoneyKindIqdTest
{
    /// <summary>Verifies that IQD values are rounded to the minimum unit (250).</summary>
    [Theory]
    [InlineData(1234, 1250)]
    [InlineData(1125, 1000)] // Midpoint: rounds to even (1000 is 4 * 250)
    [InlineData(1375, 1500)] // Midpoint: rounds to even (1500 is 6 * 250, but 1375 = 1250 + 125 -> closer to 1500)
    [InlineData(1249, 1250)]
    [InlineData(1251, 1250)]
    [InlineData(1124, 1000)]
    [InlineData(1126, 1250)]
    public void IqdRoundingShouldBeCorrect(decimal input, decimal expected)
    {
        var mk = new MoneyKind<IqdCurrency>();
        mk.RoundToMinimumUnit(input).ShouldBe(expected);
    }
}
