using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;AedCurrency&gt; tests.</summary>
public class MoneyKindAedTest
{
    /// <summary>Verifies that AED cash-count strings are parsed and total amounts calculated correctly.</summary>
    [Theory]
    [InlineData("0.25:1,1:1;5:1", 6.25)]
    [InlineData("0.5:1;5:1,20:1", 25.50)]
    public void AedParseShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<AedCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
