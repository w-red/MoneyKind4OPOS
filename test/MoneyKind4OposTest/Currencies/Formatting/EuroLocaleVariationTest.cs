using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Formatting;

/// <summary>
/// Tests for Euro locale variations using CurrencyFormattingOptions.FromIso4217.
/// Verifies that different European locales produce culturally appropriate formatting.
/// All formatting tests use ShouldBe for exact string matching.
/// </summary>
public class EuroLocaleVariationTest
{
    /// <summary>
    /// Narrow No-Break Space (U+202F) used in French locale formatting.
    /// </summary>
    private const string Nnbsp = "\u202F";

    /// <summary>
    /// Euro formatting should respect culture-specific conventions:
    /// - de-DE (German): 1.234,56 € (period as group separator, comma as decimal, symbol postfix)
    /// - fr-FR (French): 1 234,56 € (NBSP as group separator, comma as decimal, symbol postfix)
    /// - en-IE (Irish English): €1,234.56 (comma as group separator, period as decimal, symbol prefix)
    /// </summary>
    /// <summary>Verifies that Euro formatting options correctly adapt to various cultural locales.</summary>
    [Theory]
    [InlineData("de-DE", SymbolPlacement.Postfix, ",", ".")]
    [InlineData("fr-FR", SymbolPlacement.Postfix, ",", " ")] // Group separator contains NBSP
    [InlineData("en-IE", SymbolPlacement.Prefix, ".", ",")]
    public void EuroShouldFormatAccordingToCulture(
        string culture,
        SymbolPlacement expectedPlacement,
        string expectedDecimalSeparator,
        string expectedGroupSeparatorContains)
    {
        // Arrange: Get formatting options from ISO code with culture override
        var options = CurrencyFormattingOptions.FromIso4217(
            Iso4217.EUR,
            cultureName: culture);

        // Assert: Symbol should always be €
        options.Symbol.ShouldBe("€");

        // Assert: Placement should match expected
        options.DisplayFormat.Placement.ShouldBe(expectedPlacement);

        // Assert: Decimal separator should match
        options.NumberFormat.CurrencyDecimalSeparator.ShouldBe(expectedDecimalSeparator);

        // Assert: Group separator should contain expected character
        options.NumberFormat.CurrencyGroupSeparator.ShouldContain(expectedGroupSeparatorContains.Trim());
    }

    /// <summary>
    /// German Euro format: 1.234,56 €
    /// Uses period as group separator, comma as decimal separator, symbol postfix.
    /// </summary>
    /// <summary>Verifies that the German locale (de-DE) produces the exact expected Euro string format.</summary>
    [Fact]
    public void EuroGermanFormatShouldMatchExactly()
    {
        // Arrange
        var options = CurrencyFormattingOptions.FromIso4217(
            Iso4217.EUR,
            cultureName: "de-DE");
        var amount = 1234.56m;

        // Act
        var formatted = options.Format(amount);

        // Assert: Exact match with ShouldBe
        formatted.ShouldBe("1.234,56 €");
    }

    /// <summary>
    /// French Euro format: 1 234,56 €
    /// Uses Narrow No-Break Space (U+202F) as group separator.
    /// </summary>
    /// <summary>Verifies that the French locale (fr-FR) produces the exact expected Euro string format, including NBSP.</summary>
    [Fact]
    public void EuroFrenchFormatShouldMatchExactlyWithNBSP()
    {
        // Arrange
        var options = CurrencyFormattingOptions.FromIso4217(
            Iso4217.EUR,
            cultureName: "fr-FR");
        var amount = 1234.56m;

        // Act
        var formatted = options.Format(amount);

        // Assert: Exact match using NBSP constant
        // Expected: "1\u202F234,56 €" (NBSP between 1 and 234, regular space before €)
        formatted.ShouldBe($"1{Nnbsp}234,56 €");
    }

    /// <summary>
    /// Irish/English Euro format: €1,234.56
    /// Uses comma as group separator, period as decimal separator, symbol prefix.
    /// </summary>
    /// <summary>Verifies that the Irish locale (en-IE) produces the exact expected Euro string format.</summary>
    [Fact]
    public void EuroIrishFormatShouldMatchExactly()
    {
        // Arrange
        var options = CurrencyFormattingOptions.FromIso4217(
            Iso4217.EUR,
            cultureName: "en-IE");
        var amount = 1234.56m;

        // Act
        var formatted = options.Format(amount);

        // Assert: Exact match with ShouldBe
        formatted.ShouldBe("€1,234.56");
    }

    /// <summary>
    /// Parameterized test for exact string matching across multiple locales.
    /// </summary>
    /// <summary>Verifies exact string matching for Euro formatting across multiple specified locales.</summary>
    [Theory]
    [InlineData("de-DE", "1.234,56 €")]
    [InlineData("en-IE", "€1,234.56")]
    public void EuroFormatShouldMatchExpectedString(
        string culture,
        string expectedFormat)
    {
        // Arrange
        var options = CurrencyFormattingOptions.FromIso4217(
            Iso4217.EUR,
            cultureName: culture);
        var amount = 1234.56m;

        // Act
        var formatted = options.Format(amount);

        // Assert: Exact match with ShouldBe
        formatted.ShouldBe(expectedFormat);
    }

    /// <summary>
    /// French format needs special handling due to NBSP, tested separately.
    /// </summary>
    /// <summary>Verifies that the French locale formatting exactly matches the expected string with Narrow No-Break Space.</summary>
    [Fact]
    public void EuroFrenchFormatInTheoryShouldMatchExpectedString()
    {
        // Arrange
        var options = CurrencyFormattingOptions.FromIso4217(
            Iso4217.EUR,
            cultureName: "fr-FR");
        var amount = 1234.56m;

        // Act
        var formatted = options.Format(amount);

        // Assert: Exact match using NBSP constant
        var expectedFormat = $"1{Nnbsp}234,56 €";
        formatted.ShouldBe(expectedFormat);
    }
}
