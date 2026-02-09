using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;NioCurrency&gt; tests.</summary>
public class MoneyKindNioTest
{
    /// <summary>Verifies that NIO values are rounded to the minimum unit (0.05).</summary>
    [Theory]
    [InlineData(1234.57, 1234.55)]
    [InlineData(1234.58, 1234.60)]
    [InlineData(1234.575, 1234.60)] // Midpoint rounding away from zero (default for decimal in this lib?) 
    // Wait, MoneyKind uses AwayFromZero or ToEven? I should check.
    // Let's check MoneyKind.cs
    public void NioRoundingShouldBeCorrect(decimal input, decimal expected)
    {
        var mk = new MoneyKind<NioCurrency>();
        mk.RoundToMinimumUnit(input).ShouldBe(expected);
    }
}
