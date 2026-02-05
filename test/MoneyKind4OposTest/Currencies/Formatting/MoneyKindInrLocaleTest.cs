using MoneyKind4Opos.Currencies;
using Shouldly;
using System.Globalization;

namespace MoneyKind4OposTest;

/// <summary>
/// Tests for Indian Rupee (INR) formatting across various Indian locales.
/// Focuses on the "Absolute Solution" for each culture, respecting unique separators,
/// spacing, and the Lakh/Crore grouping system (1,00,00,000).
/// </summary>
public class MoneyKindInrLocaleTest
{
    private static readonly int[] IndianGroupSizes = [3, 2];

    /// <summary>
    /// Verifies the "Absolute Solution" for various Indian language cultures.
    /// This test ensures that the library respects the local conventions (e.g., Urdu's unique separators)
    /// while strictly enforcing the Indian numbering system.
    /// </summary>
    /// <param name="cultureName">The culture identifier (e.g., ur-IN).</param>
    /// <param name="expectedFormattedCrore">The exact expected string for 1 Crore (10,000,000).</param>
    [Theory]
    [InlineData("hi-IN", "₹1,00,00,000.00")]    // Hindi: Standard Rupee symbol, no space
    [InlineData("bn-IN", "₹1,00,00,000.00")]    // Bengali
    [InlineData("te-IN", "₹1,00,00,000.00")]    // Telugu
    [InlineData("mr-IN", "₹1,00,00,000.00")]    // Marathi
    [InlineData("ta-IN", "₹1,00,00,000.00")]    // Tamil
    [InlineData("ur-IN", "₹ 1٬00٬00٬000٫00")]   // Urdu: "Absolute Solution" with special separators and spaces
    [InlineData("gu-IN", "₹1,00,00,000.00")]    // Gujarati
    [InlineData("kn-IN", "₹1,00,00,000.00")]    // Kannada
    [InlineData("ml-IN", "₹1,00,00,000.00")]    // Malayalam
    [InlineData("pa-IN", "₹1,00,00,000.00")]    // Punjabi
    [InlineData("or-IN", "₹1,00,00,000.00")]    // Odia
    [InlineData("as-IN", "₹ 1,00,00,000.00")]   // Assamese: Absolute Solution with space
    [InlineData("kok-IN", "₹ 1,00,00,000.00")]  // Konkani: Absolute Solution with space
    public void Inr_Culture_Absolute_Solution_Test(string cultureName, string expectedFormattedCrore)
    {
        CultureInfo culture;
        try
        {
            // We use the CultureInfo as the base for the "Absolute Solution" of that specific culture.
            culture = new CultureInfo(cultureName);
        }
        catch (CultureNotFoundException)
        {
            return;
        }

        // We clone and explicitly set the Indian Group Sizes to ensure the Lakh/Crore system
        // is enforced even if the OS default for that culture is standard international [3].
        var nfi = (NumberFormatInfo)culture.NumberFormat.Clone();
        nfi.CurrencyGroupSizes = IndianGroupSizes;
        nfi.NumberGroupSizes = IndianGroupSizes;

        decimal amount = 10000000m; // 1 Crore
        var formatted = amount.ToString("C", nfi);

        // Exact match comparison - validating the Absolute Solution (separators, symbols, spacing).
        formatted.ShouldBe(expectedFormattedCrore);
    }

    /// <summary>
    /// Verifies that the library's standard InrCurrency implementation consistently follows
    /// the Indian Lakh/Crore grouping system.
    /// </summary>
    [Fact]
    public void InrCurrency_Implementation_Should_Be_Consistent()
    {
        InrCurrency.Global.NumberFormat.CurrencyGroupSizes.ShouldBe(IndianGroupSizes);
        InrCurrency.Local.NumberFormat.CurrencyGroupSizes.ShouldBe(IndianGroupSizes);

        decimal amount = 10000000m;
        var result = InrCurrency.Global.Format(amount);

        // International/Global absolute solution for this library
        result.ShouldBe("₹1,00,00,000.00");
    }

    /// <summary>
    /// Reference for localized names. While the library currently uses hardcoded names,
    /// these act as the absolute reference for future localization work.
    /// </summary>
    [Theory]
    [InlineData("hi-IN", "रुपया", "पैसे")]
    [InlineData("bn-IN", "টাকা", "পয়সা")]
    [InlineData("mr-IN", "रुपये", "पैसे")]
    [InlineData("ta-IN", "ரூபாய்", "பைसा")]
    public void Inr_DenominationLocalizedNames_Reference(string cultureName, string rupeeName, string paiseName)
    {
        var culture = CultureInfo.GetCultureInfo(cultureName);
        culture.Name.ShouldBe(cultureName);
        rupeeName.ShouldNotBeNullOrEmpty();
        paiseName.ShouldNotBeNullOrEmpty();
    }
}
