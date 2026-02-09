using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;KhrCurrency&gt; tests.</summary>
public class MoneyKindKhrTest
{
    /// <summary>Verifies that KHR values are rounded to the minimum unit (50).</summary>
    [Theory]
    [InlineData(1234, 1250)]
    [InlineData(1224, 1200)]
    [InlineData(1225, 1200)]
    public void KhrRoundingShouldBeCorrect(decimal input, decimal expected)
    {
        var mk = new MoneyKind<KhrCurrency>();
        mk.RoundToMinimumUnit(input).ShouldBe(expected);
    }
}
