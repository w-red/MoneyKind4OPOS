using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest;

/// <summary>
/// Tests for MoneyKind.ToCashCountsString.
/// </summary>
public class MoneyKindFormatTest
{
    [Fact]
    public void ToCashCountsString_MixedInventory_ShouldFormatSeparately()
    {
        var mk = new MoneyKind<JpyCurrency>();
        mk[100] = 2;   // Coin
        mk[1000] = 5;  // Bill

        var result = mk.ToCashCountsString();

        // Default JpyCurrency format: "1:0,5:0,10:0,50:0,100:2,500:0;1000:5,2000:0,5000:0,10000:0"
        var sections = result.Split(';');
        sections.Length.ShouldBe(2);

        sections[0].ShouldContain("100:2");
        sections[1].ShouldContain("1000:5");
        // 0-counts are included by default implementation
        sections[0].ShouldContain("500:0");
    }

    [Fact]
    public void ToCashCountsString_OnlyBills_ShouldHaveEmptyCoinSectionWithZeroes()
    {
        var mk = new MoneyKind<JpyCurrency>();
        mk[10000] = 1;

        var result = mk.ToCashCountsString();

        // Coin section exists but all counts are 0
        var sections = result.Split(';');
        sections[0].ShouldContain("1:0");
        sections[1].ShouldContain("10000:1");
    }

    [Fact]
    public void ToCashCountsString_NegativeCounts_ShouldRepresentNegativeSigns()
    {
        var mk = new MoneyKind<JpyCurrency>();
        mk[100] = -5;

        var result = mk.ToCashCountsString();
        result.ShouldContain("100:-5");
    }

    [Fact]
    public void ToCashCountsString_ZeroCounts_ShouldIncludeZeroesForAllDenominations()
    {
        var mk = new MoneyKind<JpyCurrency>();
        // All JPY denominations should be present with :0
        var result = mk.ToCashCountsString();

        result.ShouldContain("100:0");
        result.ShouldContain("10:0");
        result.ShouldContain("1000:0");
    }

    [Fact]
    public void ToCashCountsString_CustomFormat_ShouldApplyToValues()
    {
        var mk = new MoneyKind<EurCurrency>();
        mk[0.5m] = 2; // 50 cents

        // Explicit decimal format
        var result = mk.ToCashCountsString(coinFormat: "0.00");

        result.ShouldContain("0.50:2");
    }

    [Fact]
    public void ToCashCountsString_Usd_CanProduceLeadingDotFormat()
    {
        var mk = new MoneyKind<UsdCurrency>();
        mk[0.5m] = 1;   // 50 cents
        mk[0.05m] = 2;  // 5 cents

        // .NET format string ".##" omits leading zero for values < 1
        var result = mk.ToCashCountsString(coinFormat: ".##");

        result.ShouldContain(".5:1");
        result.ShouldContain(".05:2");
    }
}
