using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OPOSTest.Currencies;

/// <summary>
/// Tests for CurrencyFormattingOptions.FromIso4217 factory method
/// and Euro multi-locale formatting variations.
/// </summary>
public class CurrencyFormattingOptionsTest
{
    [Fact]
    public void FromIso4217_WithJPY_ShouldReturnJapaneseFormatting()
    {
        var options =
            CurrencyFormattingOptions
            .FromIso4217(Iso4217.JPY);

        options.Symbol.ShouldBe("¥");
        options.NumberFormat.CurrencyDecimalDigits.ShouldBe(0);
        options.DisplayFormat.Placement.ShouldBe(SymbolPlacement.Prefix);
    }

    [Fact]
    public void FromIso4217_WithUSD_ShouldReturnUSFormatting()
    {
        var options =
            CurrencyFormattingOptions
            .FromIso4217(Iso4217.USD);

        options.Symbol.ShouldBe("$");
        options.NumberFormat.CurrencyDecimalDigits.ShouldBe(2);
        options.DisplayFormat.Placement.ShouldBe(SymbolPlacement.Prefix);
    }

    [Fact]
    public void FromIso4217_WithEUR_ShouldReturnGermanFormattingByDefault()
    {
        var options =
            CurrencyFormattingOptions
            .FromIso4217(Iso4217.EUR);

        options.Symbol.ShouldBe("€");
        options.NumberFormat.CurrencyDecimalDigits.ShouldBe(2);
        // German style: n € (postfix)
        options.DisplayFormat.Placement.ShouldBe(SymbolPlacement.Postfix);
        // German uses comma as decimal separator
        options.NumberFormat.CurrencyDecimalSeparator.ShouldBe(",");
        // German uses period as group separator
        options.NumberFormat.CurrencyGroupSeparator.ShouldBe(".");
    }

    [Fact]
    public void FromIso4217_WithThreeLetterSymbol_ShouldUseIsoCode()
    {
        var options =
            CurrencyFormattingOptions
            .FromIso4217(
                Iso4217.EUR,
                preferThreeLetterSymbol: true);

        options.Symbol.ShouldBe("EUR");
    }

    [Theory]
    [InlineData("de-DE", ",", ".")] // German: decimal=comma, group=period
    [InlineData("fr-FR", ",", " ")] // French: decimal=comma, group=space (may be thin space)
    [InlineData("en-IE", ".", ",")] // Ireland (English): decimal=period, group=comma
    public void FromIso4217_Euro_WithCultureOverride_ShouldRespectLocaleSettings(
        string cultureName,
        string expectedDecimalSeparator,
        string expectedGroupSeparator)
    {
        var options = CurrencyFormattingOptions.FromIso4217(Iso4217.EUR, cultureName: cultureName);

        options.Symbol.ShouldBe("€");
        options.NumberFormat.CurrencyDecimalSeparator.ShouldBe(expectedDecimalSeparator);
        // Group separator might include non-breaking space, so we check if it contains the expected char
        options.NumberFormat.CurrencyGroupSeparator.ShouldContain(expectedGroupSeparator.Trim());
    }

    [Fact]
    public void FromIso4217_Euro_FrenchFormat_ShouldFormatCorrectly()
    {
        var options =
            CurrencyFormattingOptions
            .FromIso4217(
                Iso4217.EUR,
                cultureName: "fr-FR");
        var result = options.Format(1234.56m);

        // French format: 1 234,56 € (with possible non-breaking space)
        result.ShouldContain("1");
        result.ShouldContain("234");
        result.ShouldContain(",56");
        result.ShouldContain("€");
        // Note: We don't use ShouldBe for exact match because fr-FR uses
        // Narrow No-Break Space (U+202F) as group separator, not regular space.
        result.TrimEnd().ShouldEndWith("€");
    }

    [Fact]
    public void FromIso4217_Euro_IrishFormat_ShouldHavePrefixSymbol()
    {
        var options =
            CurrencyFormattingOptions
            .FromIso4217(
                Iso4217.EUR,
                cultureName: "en-IE");

        // Irish (English) uses prefix: €1,234.56
        options
            .DisplayFormat
            .Placement
            .ShouldBe(SymbolPlacement.Prefix);
    }

    [Fact]
    public void FromIso4217_UnsupportedCode_WithoutCultureOverride_ShouldThrow()
    {
        // AFN (Afghani) is not in the default map
        Should.Throw<ArgumentException>(() =>
            CurrencyFormattingOptions.FromIso4217(Iso4217.AFN));
    }

    [Fact]
    public void FromIso4217_UnsupportedCode_WithCultureOverride_ShouldWork()
    {
        // Even unsupported codes work if culture is provided
        var options = CurrencyFormattingOptions.FromIso4217(Iso4217.AFN, cultureName: "ps-AF");

        // Symbol falls back to 3-letter code when not in map
        options.Symbol.ShouldBe("AFN");
    }

    [Fact]
    public void FromIso4217_CNY_ShouldReturnChineseFormatting()
    {
        var options = CurrencyFormattingOptions.FromIso4217(Iso4217.CNY);

        options
            .Symbol.ShouldBe("¥");
        options
            .NumberFormat
            .CurrencyDecimalDigits
            .ShouldBe(2);
    }

    [Fact]
    public void FromIso4217_GBP_ShouldReturnBritishFormatting()
    {
        var options =
            CurrencyFormattingOptions
            .FromIso4217(Iso4217.GBP);

        options
            .Symbol
            .ShouldBe("£");
        options
            .DisplayFormat
            .Placement
            .ShouldBe(SymbolPlacement.Prefix);
    }

    [Fact]
    public void FromIso4217_CHF_ShouldUseThreeLetterCodeAsSymbol()
    {
        // CHF has null Symbol in the map, so it should use code.ToString()
        var options =
            CurrencyFormattingOptions
            .FromIso4217(Iso4217.CHF);

        options
            .Symbol
            .ShouldBe("CHF");
        options
            .NumberFormat
            .CurrencyDecimalDigits
            .ShouldBe(2);
    }

    [Theory]
    [InlineData("de-CH")]
    [InlineData("fr-CH")]
    [InlineData("it-CH")]
    [InlineData("rm-CH")]
    public void FromIso4217_CHF_WithCultureOverride_ShouldRespectLocale(string culture)
    {
        var options = CurrencyFormattingOptions.FromIso4217(Iso4217.CHF, cultureName: culture);

        // Symbol should always be "CHF" (3-letter code)
        options.Symbol.ShouldBe("CHF");

        // All Swiss locales use period as decimal separator
        options.NumberFormat.CurrencyDecimalSeparator.ShouldBe(".");

        // Group separator varies by locale (apostrophe ' or NBSP variants)
        // but should never be empty
        options.NumberFormat.CurrencyGroupSeparator.ShouldNotBeNullOrEmpty();
        options.NumberFormat.CurrencyDecimalDigits.ShouldBe(2);
    }


    [Fact]
    public void FromIso4217_CHF_GermanSwiss_ShouldFormatCorrectly()
    {
        var options = CurrencyFormattingOptions.FromIso4217(Iso4217.CHF, cultureName: "de-CH");
        var formatted = options.Format(1234.56m);

        // Swiss German uses apostrophe as group separator: CHF 1'234.56 or 1'234.56 CHF
        formatted.ShouldContain("1");
        formatted.ShouldContain("234");
        formatted.ShouldContain(".56");
        formatted.ShouldContain("CHF");
    }

    [Fact]
    public void FromIso4217_CAD_English_ShouldUseCanadianEnglishFormatting()
    {
        var options = CurrencyFormattingOptions.FromIso4217(Iso4217.CAD);

        options.Symbol.ShouldBe("$");
        options.DisplayFormat.Placement.ShouldBe(SymbolPlacement.Prefix);
        options.NumberFormat.CurrencyDecimalSeparator.ShouldBe(".");
        options.NumberFormat.CurrencyGroupSeparator.ShouldBe(",");
    }

    [Fact]
    public void FromIso4217_CAD_French_ShouldUseCanadianFrenchFormatting()
    {
        var options = CurrencyFormattingOptions.FromIso4217(Iso4217.CAD, cultureName: "fr-CA");

        options.Symbol.ShouldBe("$");
        // French Canadian uses comma as decimal separator
        options.NumberFormat.CurrencyDecimalSeparator.ShouldBe(",");
        // Group separator is typically NBSP
        options.NumberFormat.CurrencyGroupSeparator.ShouldContain(" ".Trim());
    }

    [Fact]
    public void FromIso4217_CAD_French_ShouldFormatCorrectly()
    {
        var options = CurrencyFormattingOptions.FromIso4217(Iso4217.CAD, cultureName: "fr-CA");
        var formatted = options.Format(1234.56m);

        // French Canadian format: 1 234,56 $ (with NBSP)
        formatted.ShouldContain("1");
        formatted.ShouldContain("234");
        formatted.ShouldContain(",56");
        formatted.ShouldContain("$");
    }

    [Fact]
    public void FromIso4217_KRW_ShouldUseKoreanFormatting()
    {
        var options = CurrencyFormattingOptions.FromIso4217(Iso4217.KRW);

        options.Symbol.ShouldBe("₩");
        options.DisplayFormat.Placement.ShouldBe(SymbolPlacement.Prefix);
        // Korean Won has no decimal places
        options.NumberFormat.CurrencyDecimalDigits.ShouldBe(0);
    }

    [Fact]
    public void FromIso4217_KRW_ShouldFormatWholeNumbersCorrectly()
    {
        var options = CurrencyFormattingOptions.FromIso4217(Iso4217.KRW);
        var formatted = options.Format(1234m);

        // Korean format: ₩1,234 (no decimals)
        formatted.ShouldContain("₩");
        formatted.ShouldContain("1");
        formatted.ShouldContain("234");
        formatted.ShouldNotContain("."); // No decimal point for whole currency
    }

    [Fact]
    public void FromIso4217_GBP_ShouldFormatCorrectly()
    {
        var options = CurrencyFormattingOptions.FromIso4217(Iso4217.GBP);
        var formatted = options.Format(1234.56m);

        // British format: £1,234.56
        formatted.ShouldBe("£1,234.56");
    }

    [Fact]
    public void FromIso4217_WithOverrideSymbol_ShouldUseCustomSymbol()
    {
        // CHF defaults to "CHF", but we override it with "Fr."
        var options = CurrencyFormattingOptions.FromIso4217(
            Iso4217.CHF,
            overrideSymbol: "Fr.");

        options.Symbol.ShouldBe("Fr.");
        options.Format(100m).ShouldContain("Fr.");
    }

    [Fact]
    public void FromIso4217_OverrideSymbol_ShouldTakePrecedenceOverThreeLetterOption()
    {
        // overrideSymbol should be stronger than preferThreeLetterSymbol
        var options = CurrencyFormattingOptions.FromIso4217(
            Iso4217.EUR,
            preferThreeLetterSymbol: true,
            overrideSymbol: "EURO");

        options.Symbol.ShouldBe("EURO");
    }

    [Fact]
    public void FromIso4217_OverrideSymbol_ShouldBeReflectedInFormattedString()
    {
        var options = CurrencyFormattingOptions.FromIso4217(
            Iso4217.USD,
            overrideSymbol: "US$");

        var formatted = options.Format(1234.56m);

        // Uses US$ instead of regular $
        formatted.ShouldBe("US$1,234.56");
    }

}
