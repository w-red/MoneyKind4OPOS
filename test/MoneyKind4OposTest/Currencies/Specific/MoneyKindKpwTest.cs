using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;KpwCurrency&gt; tests.</summary>
public class MoneyKindKpwTest
{
    /// <summary>Verifies that KPW values are rounded to the minimum unit (5).</summary>
    [Theory]
    [InlineData(1232, 1230)]
    [InlineData(1233, 1235)]
    public void KpwRoundingShouldBeCorrect(decimal input, decimal expected)
    {
        var mk = new MoneyKind<KpwCurrency>();
        mk.RoundToMinimumUnit(input).ShouldBe(expected);
    }
}
