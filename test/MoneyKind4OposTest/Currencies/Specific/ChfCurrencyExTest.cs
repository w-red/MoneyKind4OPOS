using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Extensions;
using Shouldly;
using System.Globalization;

namespace MoneyKind4OposTest.Currencies.Specific;

public class ChfCurrencyExTest
{
    private const string Apos = "\u2019";  // Right single quotation mark
    private const string NNBSP = "\u202F"; // Narrow non-breaking space

    [Theory]
    // German: "Franken 1’234.56" (Pattern: Symbol Space Number)
    [InlineData("de-CH", "Franken 1" + Apos + "234.56", "5 Rappen")]
    // French: "1 234.56 franc" (Pattern: Number Space Symbol)
    [InlineData("fr-CH", "1" + NNBSP + "234.56 franc", "5 centime")]
    // Italian: "franco 1’234.56" (Pattern: Symbol Space Number)
    [InlineData("it-CH", "franco 1" + Apos + "234.56", "5 centesimo")]
    // Romansh: "1’234.56 franc" (Pattern: Number Space Symbol)
    [InlineData("rm-CH", "1" + Apos + "234.56 franc", "5 rap")]
    public void ChfCurrencyEx_ShouldReturnLocalizedLabels(string cultureName, string expectedTotal, string expectedCoin)
    {
        // Arrange
        var culture = new CultureInfo(cultureName);
        var originalCulture = CultureInfo.CurrentCulture;
        CultureInfo.CurrentCulture = culture;

        try
        {
            // Act
            var formattedTotal = 1234.56m.ToLocalString<ChfCurrencyEx>(culture);
            var coinLabel = ChfCurrencyEx.Coins.First().LocalName;

            // Assert
            formattedTotal.ShouldBe(expectedTotal, $"Failed for {cultureName} total");
            coinLabel.ShouldBe(expectedCoin, $"Failed for {cultureName} coin label");
        }
        finally
        {
            CultureInfo.CurrentCulture = originalCulture;
        }
    }
}
