using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Extensions;
using MoneyKind4OposTest.Infrastructure;
using Shouldly;
using System.Globalization;

namespace MoneyKind4OposTest.Currencies.Formatting;

/// <summary>
/// Verifies the "Absolute Solution" for all implemented currencies across various 
/// monetary unions and multilingual nations.
/// This complete suite acts as a definitive requirement document, 
/// synchronized with exact character outputs from Windows/.NET 10.
/// </summary>
public class GlobalLocaleAbsoluteSolutionTest
{
    /// <summary>Helper method to verify the formatted global string for a specific currency and culture.</summary>
    private static void VerifyAbsoluteSolution(string cultureName, string currencyCode, string expected)
    {
        CultureInfo culture;
        try
        {
            culture = new CultureInfo(cultureName);
        }
        catch (CultureNotFoundException)
        {
            // Skip cultures not supported on the host OS
            return;
        }

        string result = currencyCode switch
        {
            "EUR" => 1234.56m.ToGlobalString<EurCurrency>(culture),
            "GBP" => 1234.56m.ToGlobalString<GbpCurrency>(culture),
            "USD" => 1234.56m.ToGlobalString<UsdCurrency>(culture),
            "JPY" => 1234m.ToGlobalString<JpyCurrency>(culture),
            "CNY" => 1234.56m.ToGlobalString<CnyCurrency>(culture),
            "CHF" => 1234.50m.ToGlobalString<ChfCurrency>(culture),
            "AUD" => 1234.00m.ToGlobalString<AudCurrency>(culture),
            "INR" => 10000000m.ToGlobalString<InrCurrency>(culture),
            "XOF" => 1234m.ToGlobalString<XofCurrency>(culture),
            "XAF" => 1234m.ToGlobalString<XafCurrency>(culture),
            "XCD" => 1234.55m.ToGlobalString<XcdCurrency>(culture),
            "ZAR" => 1234.50m.ToGlobalString<ZarCurrency>(culture),
            "NZD" => 1234.50m.ToGlobalString<NzdCurrency>(culture),
            _ => throw new ArgumentException($"Unsupported currency: {currencyCode}")
        };

        result.ShouldBe(expected);
    }

    /// <summary>Verifies that each currency is formatted correctly according to its globally expected "Absolute Solution" in various locales.</summary>
    [Theory]
    [MemberData(nameof(FormattingAbsoluteSolutionSource.GetEurUnionData), MemberType = typeof(FormattingAbsoluteSolutionSource))]
    [MemberData(nameof(FormattingAbsoluteSolutionSource.GetGbpUnionData), MemberType = typeof(FormattingAbsoluteSolutionSource))]
    [MemberData(nameof(FormattingAbsoluteSolutionSource.GetUsdUnionData), MemberType = typeof(FormattingAbsoluteSolutionSource))]
    [MemberData(nameof(FormattingAbsoluteSolutionSource.GetOtherMajorData), MemberType = typeof(FormattingAbsoluteSolutionSource))]
    [MemberData(nameof(FormattingAbsoluteSolutionSource.GetFrancZonesData), MemberType = typeof(FormattingAbsoluteSolutionSource))]
    [MemberData(nameof(FormattingAbsoluteSolutionSource.GetDivergentUnionsData), MemberType = typeof(FormattingAbsoluteSolutionSource))]
    public void GlobalAbsoluteSolutionTest(string cultureName, string currencyCode, string expected)
    {
        VerifyAbsoluteSolution(cultureName, currencyCode, expected);
    }
}
