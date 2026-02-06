using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Core;

/// <summary>Tests for MoneyKind. Parse and related parsing logic.</summary>
public class MoneyKindParseTest
{
    /// <summary>Verifies that the standard comma and semicolon separated format is parsed correctly into coins and bills.</summary>
    [Fact]
    public void ParseFullFormatShouldParseCorrectly()
    {
        // Setup: 500 yen x1, 100 yen x2 (Coins) ; 1000 yen x3 (Bills)
        var input = "500:1,100:2;1000:3";
        var result = MoneyKind<JpyCurrency>.Parse(input);

        // Value check via auto lookup
        result[500].ShouldBe(1);
        result[100].ShouldBe(2);
        result[1000].ShouldBe(3);

        // Explicit type check
        result[500, CashType.Coin].ShouldBe(1);
        result[100, CashType.Coin].ShouldBe(2);
        result[1000, CashType.Bill].ShouldBe(3);

        // Negative check (ensure they are NOT the wrong type)
        result[1000, CashType.Coin].ShouldBe(0);
        result[500, CashType.Bill].ShouldBe(0);

        // Amount separation check
        result.CoinAmount().ShouldBe(700m);   // (500*1) + (100*2)
        result.BillAmount().ShouldBe(3000m); // (1000*3)
        result.TotalAmount().ShouldBe(3700m);
    }

    /// <summary>Verifies that parsing a string with only coins results in correctly populated coin counts and zero bill amounts.</summary>
    [Fact]
    public void ParseOnlyCoinsShouldParseCorrectly()
    {
        var input = "500:1,100:2";
        var result = MoneyKind<JpyCurrency>.Parse(input);

        result.CoinAmount().ShouldBe(700m);
        result.BillAmount().ShouldBe(0m);

        result[500, CashType.Coin].ShouldBe(1);
        result[1000, CashType.Bill].ShouldBe(0);
    }

    /// <summary>Verifies that parsing a string with only bills results in correctly populated bill counts and zero coin amounts.</summary>
    [Fact]
    public void ParseOnlyBillsShouldParseCorrectly()
    {
        // Leading semicolon means empty coin section
        var input = ";1000:5";
        var result = MoneyKind<JpyCurrency>.Parse(input);

        result.CoinAmount().ShouldBe(0m);
        result.BillAmount().ShouldBe(5000m);

        result[1000, CashType.Bill].ShouldBe(5);
    }

    /// <summary>Verifies that leading or trailing whitespace around delimiters does not affect parsing accuracy.</summary>
    [Fact]
    public void ParseWithWhitespaceShouldIgnoreSpaces()
    {
        var input = " 500 : 1 , 100 : 2 ; 1000 : 3 ";
        var result = MoneyKind<JpyCurrency>.Parse(input);

        result.CoinAmount().ShouldBe(700m);
        result.BillAmount().ShouldBe(3000m);
        result[500, CashType.Coin].ShouldBe(1);
    }

    /// <summary>Verifies that empty or structural-only strings result in an empty MoneyKind instance.</summary>
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(";")]
    [InlineData(";;;")]
    public void ParseEmptyOrInvalidStructureShouldReturnEmptyMoneyKind(string input)
    {
        var result = MoneyKind<JpyCurrency>.Parse(input);
        result.TotalAmount().ShouldBe(0m);
        result.CoinAmount().ShouldBe(0m);
        result.BillAmount().ShouldBe(0m);
    }

    /// <summary>Verifies that invalid numeric values or unrecognized denominations are ignored during parsing.</summary>
    [Theory]
    [InlineData("abc:1")]        // Invalid value
    [InlineData("100:abc")]      // Invalid count
    [InlineData("100")]          // Missing colon
    [InlineData(":1")]           // Missing value
    [InlineData("9999:1")]       // Non-existent denomination
    public void ParseMalformedItemsShouldSilentlyIgnore(string input)
    {
        var result = MoneyKind<JpyCurrency>.Parse(input);
        result.TotalAmount().ShouldBe(0m);
    }

    /// <summary>Verifies that the parser extracts all valid items from a string containing mixed valid and invalid entries.</summary>
    [Fact]
    public void ParseMixedValidAndInvalidShouldParseOnlyValidItems()
    {
        var input = "500:1,invalid:99,100:2;1000:5";
        var result = MoneyKind<JpyCurrency>.Parse(input);

        result[500, CashType.Coin].ShouldBe(1);
        result[100, CashType.Coin].ShouldBe(2);
        result[1000, CashType.Bill].ShouldBe(5);
        result.CoinAmount().ShouldBe(700m);
        result.BillAmount().ShouldBe(5000m);
    }

    /// <summary>Verifies that the parser correctly allows and processes negative count values for currency denominations, For Refunds and Adjustments.</summary>
    /// <remarks>This test ensures that negative values in the input string are parsed as negative counts for
    /// the corresponding denominations, and that aggregate calculations such as total, coin, and bill amounts reflect
    /// these negative values appropriately.</remarks>
    [Fact]
    public void ParseNegativeCountsShouldAllowNegativeValues()
    {
        // Setup: -1 x 500 yen, -2 x 1000 yen
        var input = "500:-1;1000:-2";
        var result = MoneyKind<JpyCurrency>.Parse(input);

        result[500].ShouldBe(-1);
        result[1000].ShouldBe(-2);

        // Total should be -2500
        result.TotalAmount().ShouldBe(-2500m);
        result.CoinAmount().ShouldBe(-500m);
        result.BillAmount().ShouldBe(-2000m);
    }

    /// <summary>Verifies that the USD-specific leading dot format (e.g., .5 for 0.5) is correctly parsed.</summary>
    [Fact]
    public void ParseUsdSpecificFormatShouldHandleLeadingDot()
    {
        // USD style often omits leading zero for cents: ".5" (50c), ".05" (5c)
        var input = ".5:1,.05:2";
        var result = MoneyKind<UsdCurrency>.Parse(input);

        result[0.5m].ShouldBe(1);   // 50 cents (Half Dollar coin)
        result[0.05m].ShouldBe(2);  // 5 cents (Nickel coin)
        result.TotalAmount().ShouldBe(0.60m);
    }
}
