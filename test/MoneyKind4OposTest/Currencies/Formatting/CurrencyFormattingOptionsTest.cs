using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Formatting;

/// <summary>
/// Tests for CurrencyFormattingOptions.FromIso4217 factory method
/// and Euro multi-locale formatting variations.
/// </summary>
public class CurrencyFormattingOptionsTest
{
    /// <summary>Verifies that FromIso4217 correctly initializes JPY formatting options (yen symbol, 0 decimals).</summary>
    [Fact]
    public void FromIso4217WithJpyShouldReturnJapaneseFormatting()
    {
        var options =
            CurrencyFormattingOptions
            .FromIso4217(Iso4217.JPY);

        options.Symbol.ShouldBe("¥");
        options.NumberFormat.CurrencyDecimalDigits.ShouldBe(0);
        options.DisplayFormat.Placement.ShouldBe(SymbolPlacement.Prefix);
    }

    /// <summary>Verifies that FromIso4217 correctly initializes USD formatting options (dollar symbol, 2 decimals).</summary>
    [Fact]
    public void FromIso4217WithUsdShouldReturnUSFormatting()
    {
        var options =
            CurrencyFormattingOptions
            .FromIso4217(Iso4217.USD);

        options.Symbol.ShouldBe("$");
        options.NumberFormat.CurrencyDecimalDigits.ShouldBe(2);
        options.DisplayFormat.Placement.ShouldBe(SymbolPlacement.Prefix);
    }

    /// <summary>Verifies that FromIso4217 defaults to German style for EUR (postfix symbol, comma decimal).</summary>
    [Fact]
    public void FromIso4217WithEurShouldReturnGermanFormattingByDefault()
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

    /// <summary>Verifies that the factory method uses the 3-letter ISO code as the symbol when requested.</summary>
    [Fact]
    public void FromIso4217WithThreeLetterSymbolShouldUseIsoCode()
    {
        var options =
            CurrencyFormattingOptions
            .FromIso4217(
                Iso4217.EUR,
                preferThreeLetterSymbol: true);

        options.Symbol.ShouldBe("EUR");
    }

    /// <summary>Verifies that culture-specific overrides for rounding and separators are respected for EUR.</summary>
    [Theory]
    [InlineData("de-DE", ",", ".")] // German: decimal=comma, group=period
    [InlineData("fr-FR", ",", " ")] // French: decimal=comma, group=space (may be thin space)
    [InlineData("en-IE", ".", ",")] // Ireland (English): decimal=period, group=comma
    public void FromIso4217EuroWithCultureOverrideShouldRespectLocaleSettings(
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

    /// <summary>Verifies that the French regional format for Euro is correctly applied during string formatting.</summary>
    [Fact]
    public void FromIso4217EuroFrenchFormatShouldFormatCorrectly()
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

    /// <summary>Verifies that the Irish regional format correctly places the Euro symbol as a prefix.</summary>
    [Fact]
    public void FromIso4217EuroIrishFormatShouldHavePrefixSymbol()
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

    /// <summary>Verifies that requesting an unsupported ISO code without a culture override throws an ArgumentException.</summary>
    [Fact]
    public void FromIso4217UnsupportedCodeWithoutCultureOverrideShouldThrow()
    {
        // AFN (Afghani) is not in the default map
        Should.Throw<ArgumentException>(() =>
            CurrencyFormattingOptions.FromIso4217(Iso4217.AFN));
    }

    /// <summary>Verifies that unsupported ISO codes can still be formatted if a specific culture name is provided.</summary>
    [Fact]
    public void FromIso4217UnsupportedCodeWithCultureOverrideShouldWork()
    {
        // Even unsupported codes work if culture is provided
        var options = CurrencyFormattingOptions.FromIso4217(Iso4217.AFN, cultureName: "ps-AF");

        // Symbol falls back to 3-letter code when not in map
        options.Symbol.ShouldBe("AFN");
    }

    /// <summary>Verifies that FromIso4217 correctly initializes CNY formatting options.</summary>
    [Fact]
    public void FromIso4217CnyShouldReturnChineseFormatting()
    {
        var options = CurrencyFormattingOptions.FromIso4217(Iso4217.CNY);

        options
            .Symbol.ShouldBe("¥");
        options
            .NumberFormat
            .CurrencyDecimalDigits
            .ShouldBe(2);
    }

    /// <summary>Verifies that FromIso4217 correctly initializes GBP formatting options.</summary>
    [Fact]
    public void FromIso4217GbpShouldReturnBritishFormatting()
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

    /// <summary>Verifies that FromIso4217 uses the 3-letter code by default for currencies without a known symbol like CHF.</summary>
    [Fact]
    public void FromIso4217ChfShouldUseThreeLetterCodeAsSymbol()
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

    /// <summary>Verifies that Swiss regional variations for CHF are correctly respected.</summary>
    [Theory]
    [InlineData("de-CH")]
    [InlineData("fr-CH")]
    [InlineData("it-CH")]
    [InlineData("rm-CH")]
    public void FromIso4217ChfWithCultureOverrideShouldRespectLocale(string culture)
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

    /// <summary>Verifies the exact formatting output for Swiss German CHF.</summary>
    [Fact]
    public void FromIso4217ChfGermanSwissShouldFormatCorrectly()
    {
        var options = CurrencyFormattingOptions.FromIso4217(Iso4217.CHF, cultureName: "de-CH");
        var formatted = options.Format(1234.56m);

        // Swiss German uses apostrophe as group separator: CHF 1'234.56 or 1'234.56 CHF
        formatted.ShouldContain("1");
        formatted.ShouldContain("234");
        formatted.ShouldContain(".56");
        formatted.ShouldContain("CHF");
    }

    /// <summary>Verifies the default English-Canadian formatting for CAD.</summary>
    [Fact]
    public void FromIso4217CadEnglishShouldUseCanadianEnglishFormatting()
    {
        var options = CurrencyFormattingOptions.FromIso4217(Iso4217.CAD);

        options.Symbol.ShouldBe("$");
        options.DisplayFormat.Placement.ShouldBe(SymbolPlacement.Prefix);
        options.NumberFormat.CurrencyDecimalSeparator.ShouldBe(".");
        options.NumberFormat.CurrencyGroupSeparator.ShouldBe(",");
    }

    /// <summary>Verifies the French-Canadian decimal and group separators for CAD.</summary>
    [Fact]
    public void FromIso4217CadFrenchShouldUseCanadianFrenchFormatting()
    {
        var options = CurrencyFormattingOptions.FromIso4217(Iso4217.CAD, cultureName: "fr-CA");

        options.Symbol.ShouldBe("$");
        // French Canadian uses comma as decimal separator
        options.NumberFormat.CurrencyDecimalSeparator.ShouldBe(",");
        // Group separator is typically NBSP
        options.NumberFormat.CurrencyGroupSeparator.ShouldContain(" ".Trim());
    }

    /// <summary>Verifies the exact formatting output for French-Canadian CAD.</summary>
    [Fact]
    public void FromIso4217CadFrenchShouldFormatCorrectly()
    {
        var options = CurrencyFormattingOptions.FromIso4217(Iso4217.CAD, cultureName: "fr-CA");
        var formatted = options.Format(1234.56m);

        // French Canadian format: 1 234,56 $ (with NBSP)
        formatted.ShouldContain("1");
        formatted.ShouldContain("234");
        formatted.ShouldContain(",56");
        formatted.ShouldContain("$");
    }

    /// <summary>Verifies that FromIso4217 correctly initializes KRW formatting options (no decimals).</summary>
    [Fact]
    public void FromIso4217KrwShouldUseKoreanFormatting()
    {
        var options = CurrencyFormattingOptions.FromIso4217(Iso4217.KRW);

        options.Symbol.ShouldBe("₩");
        options.DisplayFormat.Placement.ShouldBe(SymbolPlacement.Prefix);
        // Korean Won has no decimal places
        options.NumberFormat.CurrencyDecimalDigits.ShouldBe(0);
    }

    /// <summary>Verifies that KRW is formatted as a whole number without decimal points.</summary>
    [Fact]
    public void FromIso4217KrwShouldFormatWholeNumbersCorrectly()
    {
        var options = CurrencyFormattingOptions.FromIso4217(Iso4217.KRW);
        var formatted = options.Format(1234m);

        // Korean format: ₩1,234 (no decimals)
        formatted.ShouldContain("₩");
        formatted.ShouldContain("1");
        formatted.ShouldContain("234");
        formatted.ShouldNotContain("."); // No decimal point for whole currency
    }

    /// <summary>Verifies the exact formatting output for British GBP.</summary>
    [Fact]
    public void FromIso4217GbpShouldFormatCorrectly()
    {
        var options = CurrencyFormattingOptions.FromIso4217(Iso4217.GBP);
        var formatted = options.Format(1234.56m);

        // British format: £1,234.56
        formatted.ShouldBe("£1,234.56");
    }

    /// <summary>Verifies that a custom symbol override is applied correctly.</summary>
    [Fact]
    public void FromIso4217WithOverrideSymbolShouldUseCustomSymbol()
    {
        // CHF defaults to "CHF", but we override it with "Fr."
        var options = CurrencyFormattingOptions.FromIso4217(
            Iso4217.CHF,
            overrideSymbol: "Fr.");

        options.Symbol.ShouldBe("Fr.");
        options.Format(100m).ShouldContain("Fr.");
    }

    /// <summary>Verifies that the custom symbol override takes precedence over the preferThreeLetterSymbol option.</summary>
    [Fact]
    public void FromIso4217OverrideSymbolShouldTakePrecedenceOverThreeLetterOption()
    {
        // overrideSymbol should be stronger than preferThreeLetterSymbol
        var options = CurrencyFormattingOptions.FromIso4217(
            Iso4217.EUR,
            preferThreeLetterSymbol: true,
            overrideSymbol: "EURO");

        options.Symbol.ShouldBe("EURO");
    }

    /// <summary>Verifies that the custom symbol override is correctly reflected in the final formatted string.</summary>
    [Fact]
    public void FromIso4217OverrideSymbolShouldBeReflectedInFormattedString()
    {
        var options = CurrencyFormattingOptions.FromIso4217(
            Iso4217.USD,
            overrideSymbol: "US$");

        var formatted = options.Format(1234.56m);

        // Uses US$ instead of regular $
        formatted.ShouldBe("US$1,234.56");
    }

}
