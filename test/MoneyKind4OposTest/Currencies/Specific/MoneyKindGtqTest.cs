using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;GtqCurrency&gt; tests.</summary>
public class MoneyKindGtqTest
{
    /// <summary>Verifies that GTQ values are rounded correctly (minimum unit 0.01).</summary>
    [Theory]
    [InlineData(1234.567, 1234.57)]
    [InlineData(1234.564, 1234.56)]
    public void GtqRoundingShouldBeCorrect(decimal input, decimal expected)
    {
        var mk = new MoneyKind<GtqCurrency>();
        mk.RoundToMinimumUnit(input).ShouldBe(expected);
    }
}
