using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Extensions;
using Shouldly;
using System.Globalization;

namespace MoneyKind4OposTest.Currencies.Specific;

public class EurCurrencyExTest
{
    [Theory]
    [InlineData("bg-BG", "10,00 евро", "1 евроцент")]
    [InlineData("el-GR", "10,00 ευρώ", "1 λεπτό")]
    [InlineData("fr-FR", "10,00 euro", "1 centime")]
    [InlineData("de-DE", "10,00 Euro", "1 Cent")]
    [InlineData("en-US", "€10.00", "1 Cent")] // Standard en-US: Symbol Prefix + Dot
    public void EurCurrencyEx_ShouldReturnLocalizedLabels(string cultureName, string expectedTotal, string expectedCoin)
    {
        // Arrange
        var culture = new CultureInfo(cultureName);
        var originalCulture = CultureInfo.CurrentCulture;
        CultureInfo.CurrentCulture = culture;

        try
        {
            // Act: Using LocalString which should use the dynamic 'Local' property
            var formattedTotal = 10m.ToLocalString<EurCurrencyEx>(culture);
            var coinLabel = EurCurrencyEx.Coins.First().LocalName;

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
