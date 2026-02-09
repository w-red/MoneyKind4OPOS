using System.Globalization;
using System.Text;
using Xunit;

namespace MoneyKind4OposTest;

/// <summary>
/// 各通貨のOS標準「現地通貨記号（CurrencySymbol）」と詳細情報を調査するためのユーティリティテスト。
/// Phase 1: 主要通貨のLocal現地名の修正に必要なOS標準フォーマットを特定する。
/// </summary>
/// <remarks>
/// このテストは実際に値を検証するものではなく、調査結果を例外メッセージとして出力します。
/// 結果は Researched/LocalCurrencySymbol_Discovery.md に記録してください。
/// </remarks>
public class LocalCurrencySymbolDiscoveryTest
{
    private readonly StringBuilder _output = new();

    /// <summary>
    /// Phase 1対象: 主要通貨（G7+、アジア）のOS標準を調査
    /// </summary>
    [Fact]
    public void Discover_Phase1_MajorCurrencies()
    {
        var targets = new (string CultureName, string IsoCode, string ExpectedLocalName)[]
        {
            // 既に正しく実装されている通貨（確認用）
            ("ja-JP", "JPY", "円"),
            ("zh-CN", "CNY", "元?"),
            
            // Phase 1 調査対象
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
        _output.AppendLine("| Culture | ISO | OS CurrencySymbol | サンプル出力 | DecimalDigits | Pattern |");
        _output.AppendLine("| :--- | :--- | :--- | :--- | :---: | :--- |");

        foreach (var (cultureName, isoCode, expectedLocalName) in targets)
        {
            DiscoverAndOutput(cultureName, isoCode);
        }

        // 調査結果を例外として出力
        throw new Exception($"DISCOVERY RESULT:\n{_output}");
    }

    /// <summary>
    /// Phase 2対象: 欧州・中東・中央アジア通貨のOS標準を調査
    /// </summary>
    [Fact]
    public void Discover_Phase2_EuropeanAndMiddleEast()
    {
        var targets = new (string CultureName, string IsoCode)[]
        {
            // 欧州
            ("cs-CZ", "CZK"),
            ("hu-HU", "HUF"),
            ("ro-RO", "RON"),
            ("bg-BG", "BGN"),
            ("sr-Latn-RS", "RSD"),
            ("be-BY", "BYN"),
            
            // 中東
            ("ar-SA", "SAR"),
            ("ar-AE", "AED"),
            ("ar-KW", "KWD"),
            ("ar-QA", "QAR"),
            ("ar-BH", "BHD"),
            ("ar-OM", "OMR"),
            ("ar-JO", "JOD"),
            ("fa-IR", "IRR"),
            
            // 中央アジア
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

        // 調査結果を例外として出力
        throw new Exception($"DISCOVERY RESULT:\n{_output}");
    }

    /// <summary>
    /// Phase 3対象: アフリカ・オセアニア・カリブ海通貨のOS標準を調査
    /// </summary>
    [Fact]
    public void Discover_Phase3_AfricaOceaniaCaribbean()
    {
        var targets = new (string CultureName, string IsoCode)[]
        {
            // アフリカ
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
            
            // オセアニア
            ("en-FJ", "FJD"),
            ("en-PG", "PGK"),
            ("en-SB", "SBD"),
            ("en-VU", "VUV"),
            ("to-TO", "TOP"),
            ("sm", "WST"),
            ("fr-PF", "XPF"),
            
            // カリブ海
            ("en-JM", "JMD"),
            ("es-CU", "CUP"),
            ("fr-HT", "HTG"),
            ("en-TT", "TTD"),
            ("en-BS", "BSD"),
            ("en-BB", "BBD"),
            ("es-DO", "DOP"),
            ("en-AG", "XCD"),
            
            // 南米
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

        // 調査結果を例外として出力
        throw new Exception($"DISCOVERY RESULT:\n{_output}");
    }

    /// <summary>
    /// 全通貨について、登録されているCultureInfoからCurrencySymbolを網羅的に調査
    /// </summary>
    [Fact]
    public void Discover_AllCultures_CurrencySymbols()
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
                
                // 同じ通貨コード+言語の重複を除外（代表的なものだけ表示）
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
        // Markdownで問題になる文字をエスケープ
        return text
            .Replace("|", "\\|")
            .Replace("\u00A0", "NBSP")
            .Replace("\u202F", "NNBSP");
    }
}
