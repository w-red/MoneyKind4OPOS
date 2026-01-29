using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Extensions;
using Shouldly;
using System.Globalization;

namespace MoneyKind4OposTest;

/// <summary>
/// Verifies the "Absolute Solution" for all implemented currencies across various 
/// monetary unions and multilingual nations.
/// This complete suite acts as a definitive requirement document, 
/// synchronized with exact character outputs from Windows/.NET 10.
/// </summary>
public class MoneyKindGlobalLocaleTest
{
    private static class Uni
    {
        public const string Space = " ";            // Standard Space (U+0020)
        public const string NBSP = "\u00A0";        // Non-Breaking Space
        public const string NNBSP = "\u202F";       // Narrow Non-Breaking Space
        public const string Apos = "\u2019";        // Right Single Quotation Mark (Swiss separator)
        public const string Yen = "\u00A5";         // Yen Symbol
        public const string Pound = "\u00A3";       // Pound Symbol
        public const string Euro = "\u20AC";        // Euro Symbol
        public const string Rupee = "\u20B9";       // Rupee Symbol
        public const string Lev = "\u043B\u0432.";  // Bulgarian Lev
    }

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

    [Theory]
    [InlineData("de-DE", $"1.234,56{Uni.Space}{Uni.Euro}")]             // Germany
    [InlineData("fr-FR", $"1{Uni.NNBSP}234,56{Uni.Space}{Uni.Euro}")]   // France (NNBSP/Space pair)
    [InlineData("it-IT", $"1.234,56{Uni.Space}{Uni.Euro}")]             // Italy
    [InlineData("es-ES", $"1.234,56{Uni.Space}{Uni.Euro}")]             // Spain
    [InlineData("nl-BE", $"{Uni.Euro}{Uni.Space}1.234,56")]             // Belgium (Dutch): Prefix
    [InlineData("fr-BE", $"1{Uni.NNBSP}234,56{Uni.Space}{Uni.Euro}")]   // Belgium (French): NNBSP
    [InlineData("de-BE", $"1.234,56{Uni.Space}{Uni.Euro}")]             // Belgium (German)
    [InlineData("nl-NL", $"{Uni.Euro}{Uni.Space}1.234,56")]             // Netherlands: Prefix
    [InlineData("en-IE", $"{Uni.Euro}1,234.56")]                        // Ireland: En-style
    [InlineData("et-EE", $"1{Uni.NBSP}234,56{Uni.Space}{Uni.Euro}")]    // Estonia: NBSP
    [InlineData("el-GR", $"1.234,56{Uni.Space}{Uni.Euro}")]             // Greece
    [InlineData("sk-SK", $"1{Uni.NBSP}234,56{Uni.Space}{Uni.Euro}")]    // Slovakia
    [InlineData("sl-SI", $"1.234,56{Uni.Space}{Uni.Euro}")]             // Slovenia
    [InlineData("pt-PT", $"1{Uni.NBSP}234,56{Uni.Space}{Uni.Euro}")]    // Portugal
    [InlineData("lv-LV", $"1{Uni.NBSP}234,56{Uni.Space}{Uni.Euro}")]    // Latvia
    [InlineData("lt-LT", $"1{Uni.NBSP}234,56{Uni.Space}{Uni.Euro}")]    // Lithuania
    [InlineData("mt-MT", $"{Uni.Euro}1,234.56")]                        // Malta (Maltese)
    [InlineData("en-MT", $"{Uni.Euro}1,234.56")]                        // Malta (English)
    [InlineData("ca-AD", $"1.234,56{Uni.Space}{Uni.Euro}")]             // Andorra
    [InlineData("fr-MC", $"1{Uni.NNBSP}234,56{Uni.Space}{Uni.Euro}")]   // Monaco
    [InlineData("it-SM", $"1.234,56{Uni.Space}{Uni.Euro}")]             // San Marino
    [InlineData("it-VA", $"1.234,56{Uni.Space}{Uni.Euro}")]             // Vatican City
    [InlineData("bg-BG", $"1{Uni.NBSP}234,56{Uni.Space}{Uni.Euro}")]     // Bulgaria (Lev) -> Should stay Euro
    [InlineData("el-CY", $"1.234,56{Uni.Space}{Uni.Euro}")]             // Cyprus (Greek)
    [InlineData("tr-CY", $"{Uni.Euro}1.234,56")]                        // Cyprus (Turkish): Prefix
    [InlineData("be-BY", $"1{Uni.NBSP}234,56{Uni.Space}{Uni.Euro}")]    // Belarus (Br) -> Should stay Euro
    public void Eur_Union_Absolute_Solution_Test(string cultureName, string expected)
    {
        VerifyAbsoluteSolution(cultureName, "EUR", expected);
    }

    [Theory]
    [InlineData("en-GB", $"{Uni.Pound}1,234.56")]
    [InlineData("cy-GB", $"{Uni.Pound}1,234.56")]   // Wales
    [InlineData("gd-GB", $"{Uni.Pound}1,234.56")]   // Scotland
    [InlineData("en-GG", $"{Uni.Pound}1,234.56")]   // Guernsey
    [InlineData("en-JE", $"{Uni.Pound}1,234.56")]   // Jersey
    [InlineData("en-IM", $"{Uni.Pound}1,234.56")]   // Isle of Man
    [InlineData("en-GI", $"{Uni.Pound}1,234.56")]   // Gibraltar
    [InlineData("en-SH", $"{Uni.Pound}1,234.56")]   // Saint Helena
    [InlineData("en-FK", $"{Uni.Pound}1,234.56")]   // Falkland Islands
    [InlineData("en-MS", $"{Uni.Pound}1,234.56")]   // Montserrat: Enforce Pound symbol
    [InlineData("en-VG", $"{Uni.Pound}1,234.56")]   // British Virgin Islands: Enforce Pound symbol
    public void Gbp_Union_Absolute_Solution_Test(string cultureName, string expected)
    {
        VerifyAbsoluteSolution(cultureName, "GBP", expected);
    }

    [Theory]
    [InlineData("en-US", "$1,234.56")]
    [InlineData("en-MH", "$1,234.56")]                          // Marshall Islands
    [InlineData("en-FM", "$1,234.56")]                          // Micronesia: Identity forced to $
    [InlineData("en-PW", "$1,234.56")]                          // Palau: Identity forced to $
    [InlineData("en-AS", "$1,234.56")]                          // American Samoa
    [InlineData("en-VI", "$1,234.56")]                          // US Virgin Islands
    [InlineData("en-TC", "$1,234.56")]                          // Turks and Caicos: Identity forced to $
    [InlineData("en-VG", "$1,234.56")]                          // British Virgin Islands: Identity forced to $
    [InlineData("en-BQ", "$1,234.56")]                          // Caribbean NL (En)
    [InlineData("nl-BQ", $"${Uni.Space}1.234,56")]              // Caribbean NL (Nl): Prefix Space
    [InlineData("es-EC", "$1.234,56")]                          // Ecuador
    [InlineData("es-PA", "$1,234.56")]                          // Panama: Identity forced to $
    [InlineData("pt-TL", $"1{Uni.NBSP}234,56{Uni.Space}$")]     // Timor-Leste: Postfix Identity forced to $
    [InlineData("en-ZW", "$1,234.56")]                          // Zimbabwe: Identity forced to $
    [InlineData("es-SV", "$1,234.56")]                          // El Salvador: Uses $
    public void Usd_Union_Absolute_Solution_Test(string cultureName, string expected)
    {
        VerifyAbsoluteSolution(cultureName, "USD", expected);
    }

    [Theory]
    [InlineData("ja-JP", $"{Uni.Yen}1,234")]
    public void Jpy_Absolute_Solution_Test(string cultureName, string expected)
    {
        VerifyAbsoluteSolution(cultureName, "JPY", expected);
    }

    [Theory]
    [InlineData("zh-CN", $"{Uni.Yen}1,234.56")]                 // China
    [InlineData("zh-HK", $"{Uni.Yen}1,234.56")]                 // Hong Kong: Enforce Yen symbol
    [InlineData("zh-MO", $"{Uni.Yen}1,234.56")]                 // Macau: Enforce Yen symbol
    public void Cny_Absolute_Solution_Test(string cultureName, string expected)
    {
        VerifyAbsoluteSolution(cultureName, "CNY", expected);
    }

    [Theory]
    [InlineData("de-CH", $"CHF{Uni.Space}1{Uni.Apos}234.50")]   // Swiss German
    [InlineData("fr-CH", $"1{Uni.NNBSP}234.50{Uni.Space}CHF")]  // Swiss French: Postfix
    [InlineData("it-CH", $"CHF{Uni.Space}1{Uni.Apos}234.50")]   // Swiss Italian
    [InlineData("rm-CH", $"1{Uni.Apos}234.50{Uni.Space}CHF")]   // Romansh: Postfix
    public void Chf_Absolute_Solution_Test(string cultureName, string expected)
    {
        VerifyAbsoluteSolution(cultureName, "CHF", expected);
    }

    [Theory]
    [InlineData("en-AU", "AUD1,234.00")]  // Australia
    [InlineData("en-KI", "AUD1,234.00")]  // Kiribati
    [InlineData("en-NR", "AUD1,234.00")]  // Nauru
    [InlineData("en-TV", "AUD1,234.00")]  // Tuvalu
    public void Aud_Absolute_Solution_Test(string cultureName, string expected)
    {
        VerifyAbsoluteSolution(cultureName, "AUD", expected);
    }

    [Theory]
    [InlineData("hi-IN", $"{Uni.Rupee}1,00,00,000.00")]
    [InlineData("ur-IN", $"{Uni.Rupee} 1\u066C00\u066C00\u066C000\u066B00")]
    public void Inr_Union_Absolute_Solution_Test(string cultureName, string expected)
    {
        VerifyAbsoluteSolution(cultureName, "INR", expected);
    }

    [Theory]
    [InlineData("fr-SN", $"1{Uni.NNBSP}234{Uni.Space}XOF")]  // Senegal
    [InlineData("fr-CI", $"1{Uni.NNBSP}234{Uni.Space}XOF")]  // Côte d'Ivoire
    [InlineData("fr-BJ", $"1{Uni.NNBSP}234{Uni.Space}XOF")]  // Benin
    [InlineData("fr-BF", $"1{Uni.NNBSP}234{Uni.Space}XOF")]  // Burkina Faso
    [InlineData("fr-GW", $"1{Uni.NNBSP}234{Uni.Space}XOF")]  // Guinea-Bissau
    [InlineData("fr-ML", $"1{Uni.NNBSP}234{Uni.Space}XOF")]  // Mali
    [InlineData("fr-NE", $"1{Uni.NNBSP}234{Uni.Space}XOF")]  // Niger
    [InlineData("fr-TG", $"1{Uni.NNBSP}234{Uni.Space}XOF")]  // Togo
    public void Xof_Union_Absolute_Solution_Test(string cultureName, string expected)
    {
        VerifyAbsoluteSolution(cultureName, "XOF", expected);
    }

    [Theory]
    [InlineData("fr-CM", $"1{Uni.NNBSP}234{Uni.Space}XAF")]  // Cameroon
    [InlineData("fr-CF", $"1{Uni.NNBSP}234{Uni.Space}XAF")]  // Central African Republic
    [InlineData("fr-TD", $"1{Uni.NNBSP}234{Uni.Space}XAF")]  // Chad
    [InlineData("fr-CG", $"1{Uni.NNBSP}234{Uni.Space}XAF")]  // Republic of the Congo
    [InlineData("fr-GQ", $"1{Uni.NNBSP}234{Uni.Space}XAF")]  // Equatorial Guinea
    [InlineData("fr-GA", $"1{Uni.NNBSP}234{Uni.Space}XAF")]  // Gabon
    public void Xaf_Union_Absolute_Solution_Test(string cultureName, string expected)
    {
        VerifyAbsoluteSolution(cultureName, "XAF", expected);
    }

    [Theory]
    [InlineData("en-AG", "EC$1,234.55")]  // Antigua and Barbuda
    [InlineData("en-DM", "EC$1,234.55")]  // Dominica
    [InlineData("en-GD", "EC$1,234.55")]  // Grenada
    [InlineData("en-KN", "EC$1,234.55")]  // Saint Kitts and Nevis
    [InlineData("en-LC", "EC$1,234.55")]  // Saint Lucia
    [InlineData("en-VC", "EC$1,234.55")]  // Saint Vincent and the Grenadines
    public void Xcd_Union_Absolute_Solution_Test(string cultureName, string expected)
    {
        VerifyAbsoluteSolution(cultureName, "XCD", expected);
    }

    [Theory]
    [InlineData("en-ZA", $"ZAR1{Uni.NBSP}234,50")]  // South Africa (English)
    [InlineData("af-ZA", $"ZAR1{Uni.NBSP}234,50")]  // South Africa (Afrikaans)
    [InlineData("en-NA", "ZAR1,234.50")]            // Namibia (English)
    [InlineData("af-NA", $"ZAR1{Uni.NBSP}234,50")]  // Namibia (Afrikaans)
    public void Zar_Union_Absolute_Solution_Test(string cultureName, string expected)
    {
        VerifyAbsoluteSolution(cultureName, "ZAR", expected);
    }

    [Theory]
    [InlineData("en-NZ", "NZ$1,234.50")]  // New Zealand
    [InlineData("en-CK", "NZ$1,234.50")]  // Cook Islands
    [InlineData("en-NU", "NZ$1,234.50")]  // Niue
    [InlineData("en-TK", "NZ$1,234.50")]  // Tokelau
    public void Nzd_Union_Absolute_Solution_Test(string cultureName, string expected)
    {
        VerifyAbsoluteSolution(cultureName, "NZD", expected);
    }
}
