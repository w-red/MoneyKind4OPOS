using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;CrcCurrency&gt; tests.</summary>
public class MoneyKindCrcTest
{
    /// <summary>Verifies that CRC cash-count strings are parsed and total amounts calculated correctly.</summary>
    [Theory]
    [InlineData("", 0)]
    [InlineData("5:1,10:1,25:1,50:1,100:1,500:1;1000:1,2000:1,5000:1,10000:1,20000:1", 38690)]
    public void CrcParseAndTotalAmountShouldBeCorrect(string input, decimal expectedTotal)
    {
        var mk = MoneyKind<CrcCurrency>.Parse(input);
        mk.TotalAmount().ShouldBe(expectedTotal);
    }

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
