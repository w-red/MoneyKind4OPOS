using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Core;

public class MoneyKindParsingTest
{
    [Fact]
    public void Parse_StandardOposFormat_ShouldSucceed()
    {
        // JPY: Coins(1, 5, 10, 50, 100, 500); Bills(1000, 2000, 5000, 10000)
        var input = "1:10,10:5,500:1;1000:2,10000:1";
        var result = MoneyKind<JpyCurrency>.Parse(input);

        result[1].ShouldBe(10);
        result[10].ShouldBe(5);
        result[500].ShouldBe(1);
        result[1000].ShouldBe(2);
        result[10000].ShouldBe(1);
        result.TotalAmount().ShouldBe(12560m);
    }

    [Fact]
    public void Parse_NumericalVariations_ShouldBeResilient()
    {
        // .5 as 0.5, 1.0 as 1
        var input = ".5:10,1.0:5";
        var result = MoneyKind<EurCurrency>.Parse(input);

        result[0.5m].ShouldBe(10);
        result[1].ShouldBe(5);
        result.TotalAmount().ShouldBe(10m);
    }

    [Fact]
    public void Parse_WhitespaceAndNoise_ShouldBeResilient()
    {
        var input = " 1 : 10 ,  10 : 5 ; 1000 : 2 ";
        var result = MoneyKind<JpyCurrency>.Parse(input);

        result[1].ShouldBe(10);
        result[10].ShouldBe(5);
        result[1000].ShouldBe(2);
    }

    [Fact]
    public void Parse_ExtraSections_ShouldIgnoreThem()
    {
        // OPOS standard is Coins;Bills. Some drivers might append extra info.
        var input = "1:10;1000:1;ExtraData:999";
        var result = MoneyKind<JpyCurrency>.Parse(input);

        result[1].ShouldBe(10);
        result[1000].ShouldBe(1);
        result.TotalAmount().ShouldBe(1010m);
    }

    [Fact]
    public void Parse_MissingBillSection_ShouldParseCoinsOnly()
    {
        var input = "1:10,10:5";
        var result = MoneyKind<JpyCurrency>.Parse(input);

        result[1].ShouldBe(10);
        result[10].ShouldBe(5);
        result.BillAmount().ShouldBe(0m);
    }

    [Fact]
    public void Parse_EmptyOrMalformedItems_ShouldSkipThemGracefully()
    {
        var input = "1:10,,10:invalid,; ,1000:2";
        var result = MoneyKind<JpyCurrency>.Parse(input);

        result[1].ShouldBe(10);
        result[1000].ShouldBe(2);
        // "10:invalid" should be skipped, result[10] stays 0
        result[10].ShouldBe(0);
    }

    [Fact]
    public void Parse_UnknownDenominations_ShouldBeTrackedInUnrecognizedCounts()
    {
        // 999 is not a JPY denomination
        var input = "1:10,999:5;1000:1";
        var result = MoneyKind<JpyCurrency>.Parse(input);

        result[1].ShouldBe(10);
        result[1000].ShouldBe(1);
        result.TotalAmount().ShouldBe(1010m); // Defined total remains 1010
        
        // Check unrecognized
        result.UnrecognizedCounts.ContainsKey(999m).ShouldBeTrue();
        result.UnrecognizedCounts[999m].ShouldBe(5);
        result.ParseMessage.ShouldContain("Unknown denomination: 999");
    }

    [Fact]
    public void Parse_MalformedData_ShouldPopulateParseMessage()
    {
        var input = "1:10,abc:5;1000:invalid";
        var result = MoneyKind<JpyCurrency>.Parse(input);

        result.ParseMessage.ShouldContain("Malformed item: 'abc:5'");
        result.ParseMessage.ShouldContain("Malformed item: '1000:invalid'");
    }
}
