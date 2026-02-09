using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Extensions;
using Shouldly;
using System.Globalization;

namespace MoneyKind4OposTest.Currencies.Specific;

public class MultiLanguageCurrencyExTest
{
    #region XOF (West African CFA Franc)
    
    [Theory]
    [InlineData("fr-SN", "Franc CFA", "1 CFA")]   // French (Senegal)
    [InlineData("pt-GW", "Franco CFA", "1 FCFA")] // Portuguese (Guinea-Bissau)
    public void XofCurrencyEx_ShouldReturnLocalizedLabels(string cultureName, string expectedSymbol, string expectedCoin)
    {
        // Arrange
        var culture = new CultureInfo(cultureName);
        var originalCulture = CultureInfo.CurrentCulture;
        CultureInfo.CurrentCulture = culture;

        try
        {
            // Act
            var local = XofCurrencyEx.Local;
            var coinLabel = XofCurrencyEx.Coins.First().LocalName;

            // Assert
            local.Symbol.ShouldBe(expectedSymbol, $"Failed for {cultureName} symbol");
            coinLabel.ShouldBe(expectedCoin, $"Failed for {cultureName} coin label");
        }
        finally
        {
            CultureInfo.CurrentCulture = originalCulture;
        }
    }

    #endregion

    #region XAF (Central African CFA Franc)
    
    [Theory]
    [InlineData("fr-CM", "Franc CFA")]   // French (Cameroon)
    [InlineData("es-GQ", "Franco CFA")]  // Spanish (Equatorial Guinea)
    public void XafCurrencyEx_ShouldReturnLocalizedSymbol(string cultureName, string expectedSymbol)
    {
        // Arrange
        var culture = new CultureInfo(cultureName);
        var originalCulture = CultureInfo.CurrentCulture;
        CultureInfo.CurrentCulture = culture;

        try
        {
            // Act
            var local = XafCurrencyEx.Local;

            // Assert
            local.Symbol.ShouldBe(expectedSymbol, $"Failed for {cultureName}");
        }
        finally
        {
            CultureInfo.CurrentCulture = originalCulture;
        }
    }

    #endregion

    #region CAD (Canadian Dollar)
    
    [Theory]
    [InlineData("en-CA", "5 Cents")]
    [InlineData("fr-CA", "5 cents")]
    public void CadCurrencyEx_ShouldReturnLocalizedCoinLabels(string cultureName, string expectedCoin)
    {
        // Arrange
        var culture = new CultureInfo(cultureName);
        var originalCulture = CultureInfo.CurrentCulture;
        CultureInfo.CurrentCulture = culture;

        try
        {
            // Act
            var coinLabel = CadCurrencyEx.Coins.First().LocalName;

            // Assert
            coinLabel.ShouldBe(expectedCoin, $"Failed for {cultureName}");
        }
        finally
        {
            CultureInfo.CurrentCulture = originalCulture;
        }
    }

    #endregion

    #region SGD (Singapore Dollar)
    
    [Theory]
    [InlineData("en-SG", "5 Cent")]
    [InlineData("zh-SG", "5 分")]
    [InlineData("ms-SG", "5 Sen")]
    public void SgdCurrencyEx_ShouldReturnLocalizedCoinLabels(string cultureName, string expectedCoin)
    {
        // Arrange
        var culture = new CultureInfo(cultureName);
        var originalCulture = CultureInfo.CurrentCulture;
        CultureInfo.CurrentCulture = culture;

        try
        {
            // Act
            var coinLabel = SgdCurrencyEx.Coins.First().LocalName;

            // Assert
            coinLabel.ShouldBe(expectedCoin, $"Failed for {cultureName}");
        }
        finally
        {
            CultureInfo.CurrentCulture = originalCulture;
        }
    }

    #endregion
}
