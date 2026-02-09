using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;CrcCurrency&gt; tests.</summary>
public class MoneyKindCrcTest
{
    /// <summary>Verifies that CRC values are rounded to the minimum unit (5).</summary>
    [Theory]
    [InlineData(1234, 1235)]
    [InlineData(1232, 1230)]
    [InlineData(1232.5, 1230)] // Standard midpoint rounding to even
    [InlineData(1237.5, 1240)] // Standard midpoint rounding to even
    public void CrcRoundingShouldBeCorrect(decimal input, decimal expected)
    {
        var mk = new MoneyKind<CrcCurrency>();
        mk.RoundToMinimumUnit(input).ShouldBe(expected);
    }
}
