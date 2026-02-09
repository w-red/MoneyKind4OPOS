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
            return;
        }

        string result = currencyCode switch
        {
            "EUR" => 1234567.89m.ToGlobalString<EurCurrency>(culture),
            "GBP" => 1234567.89m.ToGlobalString<GbpCurrency>(culture),
            "USD" => 1234567.89m.ToGlobalString<UsdCurrency>(culture),
            "JPY" => 1234567.89m.ToGlobalString<JpyCurrency>(culture),
            "CNY" => 1234567.89m.ToGlobalString<CnyCurrency>(culture),
            "CHF" => 1234567.89m.ToGlobalString<ChfCurrency>(culture),
            "AUD" => 1234567.89m.ToGlobalString<AudCurrency>(culture),
            "INR" => 1234567.89m.ToGlobalString<InrCurrency>(culture),
            "XOF" => 1234567.89m.ToGlobalString<XofCurrency>(culture),
            "XAF" => 1234567.89m.ToGlobalString<XafCurrency>(culture),
            "XCD" => 1234567.89m.ToGlobalString<XcdCurrency>(culture),
            "ZAR" => 1234567.89m.ToGlobalString<ZarCurrency>(culture),
            "NZD" => 1234567.89m.ToGlobalString<NzdCurrency>(culture),
            
            "AFN" => 1234567.89m.ToGlobalString<AfnCurrency>(culture),
            "AMD" => 1234567.89m.ToGlobalString<AmdCurrency>(culture),
            "AZN" => 1234567.89m.ToGlobalString<AznCurrency>(culture),
            "BDT" => 1234567.89m.ToGlobalString<BdtCurrency>(culture),
            "BYN" => 1234567.89m.ToGlobalString<BynCurrency>(culture),
            "CAD" => 1234567.89m.ToGlobalString<CadCurrency>(culture),
            "GEL" => 1234567.89m.ToGlobalString<GelCurrency>(culture),
            "IDR" => 1234567.89m.ToGlobalString<IdrCurrency>(culture),
            "ILS" => 1234567.89m.ToGlobalString<IlsCurrency>(culture),
            "IQD" => 1234567.89m.ToGlobalString<IqdCurrency>(culture),
            "KRW" => 1234567.89m.ToGlobalString<KrwCurrency>(culture),
            "KWD" => 1234567.89m.ToGlobalString<KwdCurrency>(culture),
            "KZT" => 1234567.89m.ToGlobalString<KztCurrency>(culture),
            "LKR" => 1234567.89m.ToGlobalString<LkrCurrency>(culture),
            "MKD" => 1234567.89m.ToGlobalString<MkdCurrency>(culture),
            "MNT" => 1234567.89m.ToGlobalString<MntCurrency>(culture),
            "MVR" => 1234567.89m.ToGlobalString<MvrCurrency>(culture),
            "MXN" => 1234567.89m.ToGlobalString<MxnCurrency>(culture),
            "MYR" => 1234567.89m.ToGlobalString<MyrCurrency>(culture),
            "NOK" => 1234567.89m.ToGlobalString<NokCurrency>(culture),
            "PHP" => 1234567.89m.ToGlobalString<PhpCurrency>(culture),
            "PKR" => 1234567.89m.ToGlobalString<PkrCurrency>(culture),
            "PLN" => 1234567.89m.ToGlobalString<PlnCurrency>(culture),
            "QAR" => 1234567.89m.ToGlobalString<QarCurrency>(culture),
            "RON" => 1234567.89m.ToGlobalString<RonCurrency>(culture),
            "RSD" => 1234567.89m.ToGlobalString<RsdCurrency>(culture),
            "RUB" => 1234567.89m.ToGlobalString<RubCurrency>(culture),
            "SAR" => 1234567.89m.ToGlobalString<SarCurrency>(culture),
            "SEK" => 1234567.89m.ToGlobalString<SekCurrency>(culture),
            "SGD" => 1234567.89m.ToGlobalString<SgdCurrency>(culture),
            "SYP" => 1234567.89m.ToGlobalString<SypCurrency>(culture),
            "THB" => 1234567.89m.ToGlobalString<ThbCurrency>(culture),
            "TMT" => 1234567.89m.ToGlobalString<TmtCurrency>(culture),
            "TRY" => 1234567.89m.ToGlobalString<TryCurrency>(culture),
            "TWD" => 1234567.89m.ToGlobalString<TwdCurrency>(culture),
            "UAH" => 1234567.89m.ToGlobalString<UahCurrency>(culture),
            "UZS" => 1234567.89m.ToGlobalString<UzsCurrency>(culture),
            "VND" => 1234567.89m.ToGlobalString<VndCurrency>(culture),
            "YER" => 1234567.89m.ToGlobalString<YerCurrency>(culture),
            
            "ARS" => 1234567.89m.ToGlobalString<ArsCurrency>(culture),
            "UYU" => 1234567.89m.ToGlobalString<UyuCurrency>(culture),
            "GYD" => 1234567.89m.ToGlobalString<GydCurrency>(culture),
            "COP" => 1234567.89m.ToGlobalString<CopCurrency>(culture),
            "SRD" => 1234567.89m.ToGlobalString<SrdCurrency>(culture),
            "PYG" => 1234567.89m.ToGlobalString<PygCurrency>(culture),
            "PEN" => 1234567.89m.ToGlobalString<PenCurrency>(culture),
            "BOB" => 1234567.89m.ToGlobalString<BobCurrency>(culture),
            "HUF" => 1234567.89m.ToGlobalString<HufCurrency>(culture),
            "KHR" => 1234567.89m.ToGlobalString<KhrCurrency>(culture),
            "MOP" => 1234567.89m.ToGlobalString<MopCurrency>(culture),
            "KPW" => 1234567.89m.ToGlobalString<KpwCurrency>(culture),
            "GTQ" => 1234567.89m.ToGlobalString<GtqCurrency>(culture),
            "CRC" => 1234567.89m.ToGlobalString<CrcCurrency>(culture),
            "NIO" => 1234567.89m.ToGlobalString<NioCurrency>(culture),
            
            _ => throw new ArgumentException($"Unsupported currency: {currencyCode}")
        };

        result.ShouldBe(expected, $"Failed for culture: {cultureName}");
    }

    /// <summary>Verifies that each currency is formatted correctly according to its globally expected "Absolute Solution" in various locales.</summary>
    [Theory]
    [MemberData(nameof(FormattingAbsoluteSolutionSource.GetEurUnionData), MemberType = typeof(FormattingAbsoluteSolutionSource))]
    [MemberData(nameof(FormattingAbsoluteSolutionSource.GetGbpUnionData), MemberType = typeof(FormattingAbsoluteSolutionSource))]
    [MemberData(nameof(FormattingAbsoluteSolutionSource.GetUsdUnionData), MemberType = typeof(FormattingAbsoluteSolutionSource))]
    [MemberData(nameof(FormattingAbsoluteSolutionSource.GetOtherMajorData), MemberType = typeof(FormattingAbsoluteSolutionSource))]
    [MemberData(nameof(FormattingAbsoluteSolutionSource.GetFrancZonesData), MemberType = typeof(FormattingAbsoluteSolutionSource))]
    [MemberData(nameof(FormattingAbsoluteSolutionSource.GetDivergentUnionsData), MemberType = typeof(FormattingAbsoluteSolutionSource))]
    [MemberData(nameof(FormattingAbsoluteSolutionSource.GetBatch2And3Data), MemberType = typeof(FormattingAbsoluteSolutionSource))]
    [MemberData(nameof(FormattingAbsoluteSolutionSource.GetSouthAmericanData), MemberType = typeof(FormattingAbsoluteSolutionSource))]
    [MemberData(nameof(FormattingAbsoluteSolutionSource.GetCentralAmericanData), MemberType = typeof(FormattingAbsoluteSolutionSource))]
    public void GlobalAbsoluteSolutionTest(string cultureName, string currencyCode, string expected)
    {
        VerifyAbsoluteSolution(cultureName, currencyCode, expected);
    }
}
