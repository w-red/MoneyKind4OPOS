using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using MoneyKind4Opos.Extensions;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

public class SlsCurrencyTest
{
    [Fact]
    public void SlsCurrencyFormattingShouldWork()
    {
        var amount = 1234.56m;
        // Global format: Sl.Sh. 1,235 (rounded since decimalDigits: 0)
        // Wait, amount 1234.56 with digits 0 should be 1235.
        // But for Shilling, we usually deal with integers in SHS.
        
        var global = amount.ToGlobalString<SlsCurrency>();
        global.ShouldBe("Sl.Sh. 1,235");

        var local = amount.ToLocalString<SlsCurrency>();
        local.ShouldBe("1,235/-");
    }

    [Fact]
    public void SlsCurrencyParsingShouldWork()
    {
        // ;100:1, 500:2, 1000:3 (All are bills)
        var input = ";100:1,500:2,1000:3";
        var result = MoneyKind<SlsCurrency>.Parse(input);

        result[100].ShouldBe(1);
        result[500].ShouldBe(2);
        result[1000].ShouldBe(3);
        result.TotalAmount().ShouldBe(4100m);
    }
}
