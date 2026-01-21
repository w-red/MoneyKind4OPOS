using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Currencies;

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
    [Theory]
    [InlineData("de-DE", SymbolPlacement.Postfix, ",", ".")]
    [InlineData("fr-FR", SymbolPlacement.Postfix, ",", " ")] // Group separator contains NBSP
    [InlineData("en-IE", SymbolPlacement.Prefix, ".", ",")]
    public void Euro_ShouldFormatAccordingToCulture(
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
    [Fact]
    public void Euro_GermanFormat_ShouldMatchExactly()
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
    [Fact]
    public void Euro_FrenchFormat_ShouldMatchExactlyWithNBSP()
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
    [Fact]
    public void Euro_IrishFormat_ShouldMatchExactly()
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
    [Theory]
    [InlineData("de-DE", "1.234,56 €")]
    [InlineData("en-IE", "€1,234.56")]
    public void Euro_Format_ShouldMatchExpectedString(
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
    [Fact]
    public void Euro_FrenchFormat_InTheory_ShouldMatchExpectedString()
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
