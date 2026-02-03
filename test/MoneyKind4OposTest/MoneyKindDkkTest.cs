using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;
using Xunit;

namespace MoneyKind4OposTest;

/// <summary>MoneyKind&lt;DkkCurrency&gt; tests.</summary>
public class MoneyKindDkkTest
{
    [Theory]
    [InlineData("0.5:1;50:1", 50.5)]
    [InlineData("20:1;500:1", 520.0)]
    public void Dkk_Parse_ShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<DkkCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
