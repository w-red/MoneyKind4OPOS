using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;MopCurrency&gt; tests.</summary>
public class MoneyKindMopTest
{
    /// <summary>Verifies that MOP values are rounded to the minimum unit (0.1).</summary>
    [Theory]
    [InlineData(10.04, 10.0)]
    [InlineData(10.05, 10.0)]
    [InlineData(10.16, 10.2)]
    public void MopRoundingShouldBeCorrect(decimal input, decimal expected)
    {
        var mk = new MoneyKind<MopCurrency>();
        mk.RoundToMinimumUnit(input).ShouldBe(expected);
    }
}
