using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Formatting;

/// <summary>Tests for MoneyKind.ToCashCountsString.</summary>
public class MoneyKindFormatTest
{
    /// <summary>Verifies that an inventory with both coins and bills is formatted with clear semicolon separation.</summary>
    [Fact]
    public void ToCashCountsStringMixedInventoryShouldFormatSeparately()
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

    /// <summary>Verifies that an inventory with only bills still includes the coin section (populated with zeros).</summary>
    [Fact]
    public void ToCashCountsStringOnlyBillsShouldHaveEmptyCoinSectionWithZeroes()
    {
        var mk = new MoneyKind<JpyCurrency>();
        mk[10000] = 1;

        var result = mk.ToCashCountsString();

        // Coin section exists but all counts are 0
        var sections = result.Split(';');
        sections[0].ShouldContain("1:0");
        sections[1].ShouldContain("10000:1");
    }

    /// <summary>Verifies that negative counts are correctly represented with a negative sign in the output string.</summary>
    [Fact]
    public void ToCashCountsStringNegativeCountsShouldRepresentNegativeSigns()
    {
        var mk = new MoneyKind<JpyCurrency>();
        mk[100] = -5;

        var result = mk.ToCashCountsString();
        result.ShouldContain("100:-5");
    }

    /// <summary>Verifies that all standard denominations are included in the output string even if their counts are zero.</summary>
    [Fact]
    public void ToCashCountsStringZeroCountsShouldIncludeZeroesForAllDenominations()
    {
        var mk = new MoneyKind<JpyCurrency>();
        // All JPY denominations should be present with :0
        var result = mk.ToCashCountsString();

        result.ShouldContain("100:0");
        result.ShouldContain("10:0");
        result.ShouldContain("1000:0");
    }

    /// <summary>Verifies that custom formatting strings (e.g., Decimal places) are correctly applied to denominations.</summary>
    [Fact]
    public void ToCashCountsStringCustomFormatShouldApplyToValues()
    {
        var mk = new MoneyKind<EurCurrency>();
        mk[0.5m] = 2; // 50 cents

        // Explicit decimal format
        var result = mk.ToCashCountsString(coinFormat: "0.00");

        result.ShouldContain("0.50:2");
    }

    /// <summary>Verifies that USD-specific leading dot formatting can be produced via custom format parameters.</summary>
    [Fact]
    public void ToCashCountsStringUsdCanProduceLeadingDotFormat()
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
