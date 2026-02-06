using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>MoneyKind&lt;UahCurrency&gt; (Ukrainian Hryvnia) tests.</summary>
public class MoneyKindUahTest
{
    /// <summary>Verifies that UAH cash-count strings are parsed and total amounts calculated correctly.</summary>
    [Theory]
    [InlineData("0.1:1,0.5:1,1:1,2:1,5:1,10:1;1:1,2:1,5:1,10:1,20:1,50:1,100:1,200:1,500:1,1000:1", 1907.6)]
    [InlineData("10:5;10:5", 100)]
    public void UahParseShouldWork(string input, decimal expected)
    {
         var mk = MoneyKind<UahCurrency>.Parse(input);
         mk.TotalAmount().ShouldBe(expected);
    }
}
