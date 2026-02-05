namespace MoneyKind4OposTest.Infrastructure;

public static class FormattingAbsoluteSolutionSource
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
    }

    public static TheoryData<string, string, string> GetEurUnionData()
    {
        var data = new TheoryData<string, string, string>();
        data.Add("de-DE", "EUR", $"1.234,56{Uni.Space}{Uni.Euro}");
        data.Add("fr-FR", "EUR", $"1{Uni.NNBSP}234,56{Uni.Space}{Uni.Euro}");
        data.Add("it-IT", "EUR", $"1.234,56{Uni.Space}{Uni.Euro}");
        data.Add("es-ES", "EUR", $"1.234,56{Uni.Space}{Uni.Euro}");
        data.Add("nl-BE", "EUR", $"{Uni.Euro}{Uni.Space}1.234,56");
        data.Add("fr-BE", "EUR", $"1{Uni.NNBSP}234,56{Uni.Space}{Uni.Euro}");
        data.Add("de-BE", "EUR", $"1.234,56{Uni.Space}{Uni.Euro}");
        data.Add("nl-NL", "EUR", $"{Uni.Euro}{Uni.Space}1.234,56");
        data.Add("en-IE", "EUR", $"{Uni.Euro}1,234.56");
        data.Add("et-EE", "EUR", $"1{Uni.NBSP}234,56{Uni.Space}{Uni.Euro}");
        data.Add("el-GR", "EUR", $"1.234,56{Uni.Space}{Uni.Euro}");
        data.Add("sk-SK", "EUR", $"1{Uni.NBSP}234,56{Uni.Space}{Uni.Euro}");
        data.Add("sl-SI", "EUR", $"1.234,56{Uni.Space}{Uni.Euro}");
        data.Add("pt-PT", "EUR", $"1{Uni.NBSP}234,56{Uni.Space}{Uni.Euro}");
        data.Add("lv-LV", "EUR", $"1{Uni.NBSP}234,56{Uni.Space}{Uni.Euro}");
        data.Add("lt-LT", "EUR", $"1{Uni.NBSP}234,56{Uni.Space}{Uni.Euro}");
        data.Add("mt-MT", "EUR", $"{Uni.Euro}1,234.56");
        data.Add("en-MT", "EUR", $"{Uni.Euro}1,234.56");
        data.Add("ca-AD", "EUR", $"1.234,56{Uni.Space}{Uni.Euro}");
        data.Add("fr-MC", "EUR", $"1{Uni.NNBSP}234,56{Uni.Space}{Uni.Euro}");
        data.Add("it-SM", "EUR", $"1.234,56{Uni.Space}{Uni.Euro}");
        data.Add("it-VA", "EUR", $"1.234,56{Uni.Space}{Uni.Euro}");
        data.Add("bg-BG", "EUR", $"1{Uni.NBSP}234,56{Uni.Space}{Uni.Euro}");
        data.Add("el-CY", "EUR", $"1.234,56{Uni.Space}{Uni.Euro}");
        data.Add("tr-CY", "EUR", $"{Uni.Euro}1.234,56");
        data.Add("be-BY", "EUR", $"1{Uni.NBSP}234,56{Uni.Space}{Uni.Euro}");
        return data;
    }

    public static TheoryData<string, string, string> GetGbpUnionData()
    {
        var data = new TheoryData<string, string, string>();
        data.Add("en-GB", "GBP", $"{Uni.Pound}1,234.56");
        data.Add("cy-GB", "GBP", $"{Uni.Pound}1,234.56");
        data.Add("gd-GB", "GBP", $"{Uni.Pound}1,234.56");
        data.Add("en-GG", "GBP", $"{Uni.Pound}1,234.56");
        data.Add("en-JE", "GBP", $"{Uni.Pound}1,234.56");
        data.Add("en-IM", "GBP", $"{Uni.Pound}1,234.56");
        data.Add("en-GI", "GBP", $"{Uni.Pound}1,234.56");
        data.Add("en-SH", "GBP", $"{Uni.Pound}1,234.56");
        data.Add("en-FK", "GBP", $"{Uni.Pound}1,234.56");
        data.Add("en-MS", "GBP", $"{Uni.Pound}1,234.56");
        data.Add("en-VG", "GBP", $"{Uni.Pound}1,234.56");
        return data;
    }

    public static TheoryData<string, string, string> GetUsdUnionData()
    {
        var data = new TheoryData<string, string, string>();
        data.Add("en-US", "USD", "$1,234.56");
        data.Add("en-MH", "USD", "$1,234.56");
        data.Add("en-FM", "USD", "$1,234.56");
        data.Add("en-PW", "USD", "$1,234.56");
        data.Add("en-AS", "USD", "$1,234.56");
        data.Add("en-VI", "USD", "$1,234.56");
        data.Add("en-TC", "USD", "$1,234.56");
        data.Add("en-VG", "USD", "$1,234.56");
        data.Add("en-BQ", "USD", "$1,234.56");
        data.Add("nl-BQ", "USD", $"${Uni.Space}1.234,56");
        data.Add("es-EC", "USD", "$1.234,56");
        data.Add("es-PA", "USD", "$1,234.56");
        data.Add("pt-TL", "USD", $"1{Uni.NBSP}234,56{Uni.Space}$");
        data.Add("en-ZW", "USD", "$1,234.56");
        data.Add("es-SV", "USD", "$1,234.56");
        return data;
    }

    public static TheoryData<string, string, string> GetOtherMajorData()
    {
        var data = new TheoryData<string, string, string>();
        data.Add("ja-JP", "JPY", $"{Uni.Yen}1,234");
        data.Add("zh-CN", "CNY", $"{Uni.Yen}1,234.56");
        data.Add("zh-HK", "CNY", $"{Uni.Yen}1,234.56");
        data.Add("zh-MO", "CNY", $"{Uni.Yen}1,234.56");
        data.Add("de-CH", "CHF", $"CHF{Uni.Space}1{Uni.Apos}234.50");
        data.Add("fr-CH", "CHF", $"1{Uni.NNBSP}234.50{Uni.Space}CHF");
        data.Add("it-CH", "CHF", $"CHF{Uni.Space}1{Uni.Apos}234.50");
        data.Add("rm-CH", "CHF", $"1{Uni.Apos}234.50{Uni.Space}CHF");
        data.Add("en-AU", "AUD", "AUD1,234.00");
        data.Add("en-KI", "AUD", "AUD1,234.00");
        data.Add("en-NR", "AUD", "AUD1,234.00");
        data.Add("en-TV", "AUD", "AUD1,234.00");
        data.Add("hi-IN", "INR", $"{Uni.Rupee}1,00,00,000.00");
        data.Add("ur-IN", "INR", $"{Uni.Rupee} 1\u066C00\u066C00\u066C000\u066B00");
        return data;
    }

    public static TheoryData<string, string, string> GetFrancZonesData()
    {
        var data = new TheoryData<string, string, string>();
        // XOF
        data.Add("fr-SN", "XOF", $"1{Uni.NNBSP}234{Uni.Space}XOF");
        data.Add("fr-CI", "XOF", $"1{Uni.NNBSP}234{Uni.Space}XOF");
        data.Add("fr-BJ", "XOF", $"1{Uni.NNBSP}234{Uni.Space}XOF");
        data.Add("fr-BF", "XOF", $"1{Uni.NNBSP}234{Uni.Space}XOF");
        data.Add("fr-GW", "XOF", $"1{Uni.NNBSP}234{Uni.Space}XOF");
        data.Add("fr-ML", "XOF", $"1{Uni.NNBSP}234{Uni.Space}XOF");
        data.Add("fr-NE", "XOF", $"1{Uni.NNBSP}234{Uni.Space}XOF");
        data.Add("fr-TG", "XOF", $"1{Uni.NNBSP}234{Uni.Space}XOF");
        // XAF
        data.Add("fr-CM", "XAF", $"1{Uni.NNBSP}234{Uni.Space}XAF");
        data.Add("fr-CF", "XAF", $"1{Uni.NNBSP}234{Uni.Space}XAF");
        data.Add("fr-TD", "XAF", $"1{Uni.NNBSP}234{Uni.Space}XAF");
        data.Add("fr-CG", "XAF", $"1{Uni.NNBSP}234{Uni.Space}XAF");
        data.Add("fr-GQ", "XAF", $"1{Uni.NNBSP}234{Uni.Space}XAF");
        data.Add("fr-GA", "XAF", $"1{Uni.NNBSP}234{Uni.Space}XAF");
        return data;
    }

    public static TheoryData<string, string, string> GetDivergentUnionsData()
    {
        var data = new TheoryData<string, string, string>();
        // XCD
        data.Add("en-AG", "XCD", "EC$1,234.55");
        data.Add("en-DM", "XCD", "EC$1,234.55");
        data.Add("en-GD", "XCD", "EC$1,234.55");
        data.Add("en-KN", "XCD", "EC$1,234.55");
        data.Add("en-LC", "XCD", "EC$1,234.55");
        data.Add("en-VC", "XCD", "EC$1,234.55");
        // ZAR
        data.Add("en-ZA", "ZAR", $"ZAR1{Uni.NBSP}234,50");
        data.Add("af-ZA", "ZAR", $"ZAR1{Uni.NBSP}234,50");
        data.Add("en-NA", "ZAR", "ZAR1,234.50");
        data.Add("af-NA", "ZAR", $"ZAR1{Uni.NBSP}234,50");
        // NZD
        data.Add("en-NZ", "NZD", "NZ$1,234.50");
        data.Add("en-CK", "NZD", "NZ$1,234.50");
        data.Add("en-NU", "NZD", "NZ$1,234.50");
        data.Add("en-TK", "NZD", "NZ$1,234.50");
        return data;
    }
}
