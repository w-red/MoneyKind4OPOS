using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest;

/// <summary>
/// Tests for MoneyKind.Parse and related parsing logic.
/// </summary>
public class MoneyKindParseTest
{
    [Fact]
    public void Parse_FullFormat_ShouldParseCorrectly()
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

    [Fact]
    public void Parse_OnlyCoins_ShouldParseCorrectly()
    {
        var input = "500:1,100:2";
        var result = MoneyKind<JpyCurrency>.Parse(input);

        result.CoinAmount().ShouldBe(700m);
        result.BillAmount().ShouldBe(0m);
        
        result[500, CashType.Coin].ShouldBe(1);
        result[1000, CashType.Bill].ShouldBe(0);
    }

    [Fact]
    public void Parse_OnlyBills_ShouldParseCorrectly()
    {
        // Leading semicolon means empty coin section
        var input = ";1000:5";
        var result = MoneyKind<JpyCurrency>.Parse(input);

        result.CoinAmount().ShouldBe(0m);
        result.BillAmount().ShouldBe(5000m);
        
        result[1000, CashType.Bill].ShouldBe(5);
    }

    [Fact]
    public void Parse_WithWhitespace_ShouldIgnoreSpaces()
    {
        var input = " 500 : 1 , 100 : 2 ; 1000 : 3 ";
        var result = MoneyKind<JpyCurrency>.Parse(input);

        result.CoinAmount().ShouldBe(700m);
        result.BillAmount().ShouldBe(3000m);
        result[500, CashType.Coin].ShouldBe(1);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(";")]
    [InlineData(";;;")]
    public void Parse_EmptyOrInvalidStructure_ShouldReturnEmptyMoneyKind(string input)
    {
        var result = MoneyKind<JpyCurrency>.Parse(input);
        result.TotalAmount().ShouldBe(0m);
        result.CoinAmount().ShouldBe(0m);
        result.BillAmount().ShouldBe(0m);
    }

    [Theory]
    [InlineData("abc:1")]        // Invalid value
    [InlineData("100:abc")]      // Invalid count
    [InlineData("100")]          // Missing colon
    [InlineData(":1")]           // Missing value
    [InlineData("9999:1")]       // Non-existent denomination
    public void Parse_MalformedItems_ShouldSilentlyIgnore(string input)
    {
        var result = MoneyKind<JpyCurrency>.Parse(input);
        result.TotalAmount().ShouldBe(0m);
    }

    [Fact]
    public void Parse_MixedValidAndInvalid_ShouldParseOnlyValidItems()
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
    public void Parse_NegativeCounts_ShouldAllowNegativeValues()
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

    [Fact]
    public void Parse_UsdSpecificFormat_ShouldHandleLeadingDot()
    {
        // USD style often omits leading zero for cents: ".5" (50c), ".05" (5c)
        var input = ".5:1,.05:2"; 
        var result = MoneyKind<UsdCurrency>.Parse(input);

        result[0.5m].ShouldBe(1);   // 50 cents (Half Dollar coin)
        result[0.05m].ShouldBe(2);  // 5 cents (Nickel coin)
        result.TotalAmount().ShouldBe(0.60m);
    }
}
