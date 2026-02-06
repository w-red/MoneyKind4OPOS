using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using MoneyKind4Opos.Extensions;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Specific;

/// <summary>Tests for MoneyKind with GbpCurrency (British Pound).</summary>
public class MoneyKindGbpTest
{
    /// <summary>Verifies that GBP amounts are correctly formatted into global strings with the pound symbol.</summary>
    [Fact]
    public void ToGlobalStringGbpShouldFormatCorrectly()
    {
        // Global for GBP: £n.nn (Standard decimal digits = 2)
        1234.56m.ToGlobalString<GbpCurrency>().ShouldBe("£1,234.56");
    }

    /// <summary>Verifies that GBP MoneyKind instances can be correctly serialized and restored via cash-count strings.</summary>
    [Fact]
    public void GbpParseRoundTripShouldBeCorrect()
    {
        var mk = new MoneyKind<GbpCurrency>();
        mk[0.01m] = 5;  // 5 Pennies
        mk[10.00m] = 2; // 2 Ten pound bills

        var serialized = mk.ToCashCountsString();
        var restored = MoneyKind<GbpCurrency>.Parse(serialized);

        restored[0.01m].ShouldBe(5);
        restored[10.00m].ShouldBe(2);
        restored.TotalAmount().ShouldBe(20.05m);
    }
}
