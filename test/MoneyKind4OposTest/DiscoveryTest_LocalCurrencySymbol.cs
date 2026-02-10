using System.Globalization;
using System.Text;

namespace MoneyKind4OposTest;

/// <summary>
/// Utility test for investigating the OS standard "CurrencySymbol" and detailed information for each currency.
/// Phase 1: Identifies the OS standard formats necessary for localizing major currency names.
/// </summary>
/// <remarks>
/// This test does not verify values but outputs discovery results as exception messages.
/// Record results in Researched/LocalCurrencySymbol_Discovery.md.
/// </remarks>
public class LocalCurrencySymbolDiscoveryTest
{
    private readonly StringBuilder _output = new();

    /// <summary>
    /// Phase 1: Investigate OS standards for major currencies (G7+, Asia).
    /// </summary>
    [Fact]
    public void DiscoverPhase1MajorCurrencies()
    {
        var targets = new (string CultureName, string IsoCode, string ExpectedLocalName)[]
        {
            // Currencies already correctly implemented (for verification)
            ("ja-JP", "JPY", "円"),
            ("zh-CN", "CNY", "元?"),
            
            // Phase 1 investigation targets
            ("ko-KR", "KRW", "원?"),
            ("th-TH", "THB", "บาท?"),
            ("vi-VN", "VND", "đồng?"),
            ("hi-IN", "INR", "रुपये?"),
            ("tr-TR", "TRY", "₺?"),
            ("he-IL", "ILS", "₪?"),
            ("ru-RU", "RUB", "₽ or руб.?"),
            ("uk-UA", "UAH", "₴ or грн.?"),
            ("pl-PL", "PLN", "zł?"),
        };

        _output.AppendLine("# Local Currency Symbol Discovery - Phase 1");
        _output.AppendLine("");
        _output.AppendLine("| Culture | ISO | OS CurrencySymbol | Sample Output | DecimalDigits | Pattern |");
        _output.AppendLine("| :--- | :--- | :--- | :--- | :---: | :--- |");

        foreach (var (cultureName, isoCode, expectedLocalName) in targets)
        {
            DiscoverAndOutput(cultureName, isoCode);
        }

        // Output discovery results as an exception
        throw new Exception($"DISCOVERY RESULT:\n{_output}");
    }

    /// <summary>
    /// Phase 2: Investigate OS standards for European, Middle Eastern, and Central Asian currencies.
    /// </summary>
    [Fact]
    public void DiscoverPhase2EuropeanAndMiddleEast()
    {
        var targets = new (string CultureName, string IsoCode)[]
        {
            // Europe
            ("cs-CZ", "CZK"),
            ("hu-HU", "HUF"),
            ("ro-RO", "RON"),
            ("bg-BG", "BGN"),
            ("sr-Latn-RS", "RSD"),
            ("be-BY", "BYN"),
            
            // Middle East
            ("ar-SA", "SAR"),
            ("ar-AE", "AED"),
            ("ar-KW", "KWD"),
            ("ar-QA", "QAR"),
            ("ar-BH", "BHD"),
            ("ar-OM", "OMR"),
            ("ar-JO", "JOD"),
            ("fa-IR", "IRR"),
            
            // Central Asia
            ("kk-KZ", "KZT"),
            ("uz-Latn-UZ", "UZS"),
            ("ky-KG", "KGS"),
            ("tg-Cyrl-TJ", "TJS"),
            ("tk-TM", "TMT"),
            ("az-Latn-AZ", "AZN"),
            ("hy-AM", "AMD"),
            ("ka-GE", "GEL"),
        };

        _output.AppendLine("# Local Currency Symbol Discovery - Phase 2");
        _output.AppendLine("");
        _output.AppendLine("| Culture | ISO | OS CurrencySymbol | サンプル出力 | DecimalDigits | Pattern |");
        _output.AppendLine("| :--- | :--- | :--- | :--- | :---: | :--- |");

        foreach (var (cultureName, isoCode) in targets)
        {
            DiscoverAndOutput(cultureName, isoCode);
        }

        // Output discovery results as an exception
        throw new Exception($"DISCOVERY RESULT:\n{_output}");
    }

    /// <summary>
    /// Phase 3: Investigate OS standards for African, Oceanian, and Caribbean currencies.
    /// </summary>
    [Fact]
    public void DiscoverPhase3AfricaOceaniaCaribbean()
    {
        var targets = new (string CultureName, string IsoCode)[]
        {
            // Africa
            ("en-EG", "EGP"),
            ("en-NG", "NGN"),
            ("en-GH", "GHS"),
            ("en-KE", "KES"),
            ("sw-TZ", "TZS"),
            ("en-UG", "UGX"),
            ("am-ET", "ETB"),
            ("en-ZA", "ZAR"),
            ("en-ZW", "ZWG"),
            ("en-BW", "BWP"),
            ("en-NA", "NAD"),
            ("fr-MA", "MAD"),
            ("fr-DZ", "DZD"),
            ("fr-TN", "TND"),
            
            // Oceania
            ("en-FJ", "FJD"),
            ("en-PG", "PGK"),
            ("en-SB", "SBD"),
            ("en-VU", "VUV"),
            ("to-TO", "TOP"),
            ("sm", "WST"),
            ("fr-PF", "XPF"),
            
            // Caribbean
            ("en-JM", "JMD"),
            ("es-CU", "CUP"),
            ("fr-HT", "HTG"),
            ("en-TT", "TTD"),
            ("en-BS", "BSD"),
            ("en-BB", "BBD"),
            ("es-DO", "DOP"),
            ("en-AG", "XCD"),
            
            // South America
            ("pt-BR", "BRL"),
            ("es-AR", "ARS"),
            ("es-CL", "CLP"),
            ("es-CO", "COP"),
            ("es-PE", "PEN"),
            ("es-VE", "VED"),
        };

        _output.AppendLine("# Local Currency Symbol Discovery - Phase 3");
        _output.AppendLine("");
        _output.AppendLine("| Culture | ISO | OS CurrencySymbol | サンプル出力 | DecimalDigits | Pattern |");
        _output.AppendLine("| :--- | :--- | :--- | :--- | :---: | :--- |");

        foreach (var (cultureName, isoCode) in targets)
        {
            DiscoverAndOutput(cultureName, isoCode);
        }

        // Output discovery results as an exception
        throw new Exception($"DISCOVERY RESULT:\n{_output}");
    }

    /// <summary>
    /// Phase 4: Investigate OS standards for Central American and Mexican currencies.
    /// </summary>
    [Fact]
    public void DiscoverPhase4CentralAmericaAndMexico()
    {
        var targets = new (string CultureName, string IsoCode)[]
        {
            ("es-MX", "MXN"),
            ("es-GT", "GTQ"),
            ("es-CR", "CRC"),
            ("es-NI", "NIO"),
            ("es-HN", "HNL"),
            ("es-SV", "USD"), // El Salvador uses USD
            ("en-BZ", "BZD"),
            ("es-PA", "PAB"),
        };

        _output.AppendLine("# Local Currency Symbol Discovery - Phase 4");
        _output.AppendLine("");
        _output.AppendLine("| Culture | ISO | OS CurrencySymbol | Sample Output | DecimalDigits | Pattern |");
        _output.AppendLine("| :--- | :--- | :--- | :--- | :---: | :--- |");

        foreach (var (cultureName, isoCode) in targets)
        {
            DiscoverAndOutput(cultureName, isoCode);
        }

        // Output discovery results as an exception
        throw new Exception($"DISCOVERY RESULT:\n{_output}");
    }

    /// <summary>
    /// Exhaustively investigate CurrencySymbols for all currencies from registered CultureInfo.
    /// </summary>
    [Fact]
    public void DiscoverAllCulturesCurrencySymbols()
    {
        _output.AppendLine("# All Cultures - Currency Symbol Discovery");
        _output.AppendLine("");
        _output.AppendLine("| Culture | ISOCurrencySymbol | CurrencySymbol | Native Name | DecimalDigits |");
        _output.AppendLine("| :--- | :--- | :--- | :--- | :---: |");

        var allCultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
        var seen = new HashSet<string>();

        foreach (var culture in allCultures.OrderBy(c => c.Name))
        {
            try
            {
                var region = new RegionInfo(culture.Name);
                var key = $"{region.ISOCurrencySymbol}_{culture.TwoLetterISOLanguageName}";
                
                // Exclude duplicates of the same currency code and language (show only representatives).
                if (seen.Contains(key)) continue;
                seen.Add(key);

                var nfi = culture.NumberFormat;
                _output.AppendLine(
                    $"| {culture.Name} " +
                    $"| {region.ISOCurrencySymbol} " +
                    $"| `{EscapeMarkdown(nfi.CurrencySymbol)}` " +
                    $"| {region.CurrencyNativeName} " +
                    $"| {nfi.CurrencyDecimalDigits} |");
            }
            catch
            {
                // Skip cultures without region info
            }
        }
    }

    private void DiscoverAndOutput(string cultureName, string isoCode)
    {
        try
        {
            var culture = new CultureInfo(cultureName);
            var nfi = culture.NumberFormat;
            var amount = 1234567.89m;
            var formatted = amount.ToString("C", culture);
            
            var pattern = nfi.CurrencyPositivePattern switch
            {
                0 => "$n",
                1 => "n$",
                2 => "$ n",
                3 => "n $",
                _ => "?"
            };

            _output.AppendLine(
                $"| {cultureName} " +
                $"| {isoCode} " +
                $"| `{EscapeMarkdown(nfi.CurrencySymbol)}` " +
                $"| `{EscapeMarkdown(formatted)}` " +
                $"| {nfi.CurrencyDecimalDigits} " +
                $"| {pattern} |");
        }
        catch (CultureNotFoundException)
        {
            _output.AppendLine($"| {cultureName} | {isoCode} | CULTURE NOT FOUND | - | - | - |");
        }
        catch (Exception ex)
        {
            _output.AppendLine($"| {cultureName} | {isoCode} | ERROR: {ex.Message} | - | - | - |");
        }
    }

    private static string EscapeMarkdown(string text)
    {
        // Escape characters that cause issues in Markdown.
        return text
            .Replace("|", "\\|")
            .Replace("\u00A0", "NBSP")
            .Replace("\u202F", "NNBSP");
    }
}
