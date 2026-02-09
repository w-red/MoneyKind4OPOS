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
        public const string Colon = "\u20A1";       // Colon Symbol (Costa Rica)
    }

    public static TheoryData<string, string, string> GetEurUnionData()
    {
        var data = new TheoryData<string, string, string>
        {
            { "de-DE", "EUR", $"1.234.567,89{Uni.Space}{Uni.Euro}" },
            { "fr-FR", "EUR", $"1{Uni.NNBSP}234{Uni.NNBSP}567,89{Uni.Space}{Uni.Euro}" },
            { "it-IT", "EUR", $"1.234.567,89{Uni.Space}{Uni.Euro}" },
            { "es-ES", "EUR", $"1.234.567,89{Uni.Space}{Uni.Euro}" },
            { "nl-BE", "EUR", $"{Uni.Euro}{Uni.Space}1.234.567,89" },
            { "fr-BE", "EUR", $"1{Uni.NNBSP}234{Uni.NNBSP}567,89{Uni.Space}{Uni.Euro}" },
            { "de-BE", "EUR", $"1.234.567,89{Uni.Space}{Uni.Euro}" },
            { "nl-NL", "EUR", $"{Uni.Euro}{Uni.Space}1.234.567,89" },
            { "en-IE", "EUR", $"{Uni.Euro}1,234,567.89" },
            { "et-EE", "EUR", $"1{Uni.NBSP}234{Uni.NBSP}567,89{Uni.Space}{Uni.Euro}" },
            { "el-GR", "EUR", $"1.234.567,89{Uni.Space}{Uni.Euro}" },
            { "sk-SK", "EUR", $"1{Uni.NBSP}234{Uni.NBSP}567,89{Uni.Space}{Uni.Euro}" },
            { "sl-SI", "EUR", $"1.234.567,89{Uni.Space}{Uni.Euro}" },
            { "pt-PT", "EUR", $"1{Uni.NBSP}234{Uni.NBSP}567,89{Uni.Space}{Uni.Euro}" },
            { "lv-LV", "EUR", $"1{Uni.NBSP}234{Uni.NBSP}567,89{Uni.Space}{Uni.Euro}" },
            { "lt-LT", "EUR", $"1{Uni.NBSP}234{Uni.NBSP}567,89{Uni.Space}{Uni.Euro}" },
            { "mt-MT", "EUR", $"{Uni.Euro}1,234,567.89" },
            { "en-MT", "EUR", $"{Uni.Euro}1,234,567.89" },
            { "ca-AD", "EUR", $"1.234.567,89{Uni.Space}{Uni.Euro}" },
            { "fr-MC", "EUR", $"1{Uni.NNBSP}234{Uni.NNBSP}567,89{Uni.Space}{Uni.Euro}" },
            { "it-SM", "EUR", $"1.234.567,89{Uni.Space}{Uni.Euro}" },
            { "it-VA", "EUR", $"1.234.567,89{Uni.Space}{Uni.Euro}" },
            { "bg-BG", "EUR", $"1{Uni.NBSP}234{Uni.NBSP}567,89{Uni.Space}{Uni.Euro}" },
            { "el-CY", "EUR", $"1.234.567,89{Uni.Space}{Uni.Euro}" },
            { "tr-CY", "EUR", $"{Uni.Euro}1.234.567,89" },
            { "be-BY", "EUR", $"1{Uni.NBSP}234{Uni.NBSP}567,89{Uni.Space}{Uni.Euro}" }
        };
        return data;
    }

    public static TheoryData<string, string, string> GetGbpUnionData()
    {
        var data = new TheoryData<string, string, string>
        {
            { "en-GB", "GBP", $"{Uni.Pound}1,234,567.89" },
            { "cy-GB", "GBP", $"{Uni.Pound}1,234,567.89" },
            { "gd-GB", "GBP", $"{Uni.Pound}1,234,567.89" },
            { "en-GG", "GBP", $"{Uni.Pound}1,234,567.89" },
            { "en-JE", "GBP", $"{Uni.Pound}1,234,567.89" },
            { "en-IM", "GBP", $"{Uni.Pound}1,234,567.89" },
            { "en-GI", "GBP", $"{Uni.Pound}1,234,567.89" },
            { "en-SH", "GBP", $"{Uni.Pound}1,234,567.89" },
            { "en-FK", "GBP", $"{Uni.Pound}1,234,567.89" },
            { "en-MS", "GBP", $"{Uni.Pound}1,234,567.89" },
            { "en-VG", "GBP", $"{Uni.Pound}1,234,567.89" }
        };
        return data;
    }

    public static TheoryData<string, string, string> GetUsdUnionData()
    {
        var data = new TheoryData<string, string, string>
        {
            { "en-US", "USD", "$1,234,567.89" },
            { "en-MH", "USD", "$1,234,567.89" },
            { "en-FM", "USD", "$1,234,567.89" },
            { "en-PW", "USD", "$1,234,567.89" },
            { "en-AS", "USD", "$1,234,567.89" },
            { "en-VI", "USD", "$1,234,567.89" },
            { "en-TC", "USD", "$1,234,567.89" },
            { "en-VG", "USD", "$1,234,567.89" },
            { "en-BQ", "USD", "$1,234,567.89" },
            { "nl-BQ", "USD", $"${Uni.Space}1.234.567,89" },
            { "es-EC", "USD", "$1.234.567,89" },
            { "es-PA", "USD", "$1,234,567.89" },
            { "en-ZW", "USD", "$1,234,567.89" },
            { "es-SV", "USD", "$1,234,567.89" }
        };
        return data;
    }

    public static TheoryData<string, string, string> GetOtherMajorData()
    {
        var data = new TheoryData<string, string, string>
        {
            { "ja-JP", "JPY", $"{Uni.Yen}1,234,568" },
            { "zh-CN", "CNY", $"{Uni.Yen}1,234,567.89" },
            { "zh-HK", "CNY", $"{Uni.Yen}1,234,567.89" },
            { "zh-MO", "CNY", $"{Uni.Yen}1,234,567.89" },
            { "de-CH", "CHF", $"CHF{Uni.Space}1{Uni.Apos}234{Uni.Apos}567.89" },
            { "fr-CH", "CHF", $"1{Uni.NNBSP}234{Uni.NNBSP}567.89{Uni.Space}CHF" },
            { "it-CH", "CHF", $"CHF{Uni.Space}1{Uni.Apos}234{Uni.Apos}567.89" },
            { "rm-CH", "CHF", $"1{Uni.Apos}234{Uni.Apos}567.89{Uni.Space}CHF" },
            { "en-AU", "AUD", "AUD1,234,567.89" },
            { "en-KI", "AUD", "AUD1,234,567.89" },
            { "en-NR", "AUD", "AUD1,234,567.89" },
            { "en-TV", "AUD", "AUD1,234,567.89" },
            { "hi-IN", "INR", $"{Uni.Rupee}12,34,567.89" },
            { "ur-IN", "INR", $"{Uni.Rupee} 12\u066C34\u066C567\u066B89" }
        };
        return data;
    }

    public static TheoryData<string, string, string> GetFrancZonesData()
    {
        var data = new TheoryData<string, string, string>
        {
            // XOF
            { "fr-SN", "XOF", $"1{Uni.NNBSP}234{Uni.NNBSP}568{Uni.Space}XOF" },
            { "fr-CI", "XOF", $"1{Uni.NNBSP}234{Uni.NNBSP}568{Uni.Space}XOF" },
            { "fr-BJ", "XOF", $"1{Uni.NNBSP}234{Uni.NNBSP}568{Uni.Space}XOF" },
            { "fr-BF", "XOF", $"1{Uni.NNBSP}234{Uni.NNBSP}568{Uni.Space}XOF" },
            { "fr-GW", "XOF", $"1{Uni.NNBSP}234{Uni.NNBSP}568{Uni.Space}XOF" },
            { "fr-ML", "XOF", $"1{Uni.NNBSP}234{Uni.NNBSP}568{Uni.Space}XOF" },
            { "fr-NE", "XOF", $"1{Uni.NNBSP}234{Uni.NNBSP}568{Uni.Space}XOF" },
            { "fr-TG", "XOF", $"1{Uni.NNBSP}234{Uni.NNBSP}568{Uni.Space}XOF" },
            // XAF
            { "fr-CM", "XAF", $"1{Uni.NNBSP}234{Uni.NNBSP}568{Uni.Space}XAF" },
            { "fr-CF", "XAF", $"1{Uni.NNBSP}234{Uni.NNBSP}568{Uni.Space}XAF" },
            { "fr-TD", "XAF", $"1{Uni.NNBSP}234{Uni.NNBSP}568{Uni.Space}XAF" },
            { "fr-CG", "XAF", $"1{Uni.NNBSP}234{Uni.NNBSP}568{Uni.Space}XAF" },
            { "fr-GQ", "XAF", $"1{Uni.NNBSP}234{Uni.NNBSP}568{Uni.Space}XAF" },
            { "fr-GA", "XAF", $"1{Uni.NNBSP}234{Uni.NNBSP}568{Uni.Space}XAF" }
        };
        return data;
    }

    public static TheoryData<string, string, string> GetDivergentUnionsData()
    {
        var data = new TheoryData<string, string, string>
        {
            // XCD
            { "en-AG", "XCD", "EC$1,234,567.89" },
            { "en-DM", "XCD", "EC$1,234,567.89" },
            { "en-GD", "XCD", "EC$1,234,567.89" },
            { "en-KN", "XCD", "EC$1,234,567.89" },
            { "en-LC", "XCD", "EC$1,234,567.89" },
            { "en-VC", "XCD", "EC$1,234,567.89" },
            // ZAR
            { "en-ZA", "ZAR", $"ZAR1{Uni.NBSP}234{Uni.NBSP}567,89" },
            { "af-ZA", "ZAR", $"ZAR1{Uni.NBSP}234{Uni.NBSP}567,89" },
            { "en-NA", "ZAR", "ZAR1,234,567.89" },
            { "af-NA", "ZAR", $"ZAR1{Uni.NBSP}234{Uni.NBSP}567,89" },
            // NZD
            { "en-NZ", "NZD", "NZ$1,234,567.89" },
            { "en-CK", "NZD", "NZ$1,234,567.89" },
            { "en-NU", "NZD", "NZ$1,234,567.89" },
            { "en-TK", "NZD", "NZ$1,234,567.89" }
        };
        return data;
    }

    public static TheoryData<string, string, string> GetBatch2And3Data()
    {
        var data = new TheoryData<string, string, string>
        {
            // Currencies H-O
            { "id-ID", "IDR", $"IDR1.234.567,89" },
            { "he-IL", "ILS", $"1,234,567.89{Uni.Space}₪" },
            { "ar-IQ", "IQD", $"1٬234٬568{Uni.Space}IQD" }, // 1234.56 rounded to 1235
            { "ko-KR", "KRW", $"₩1,234,568" }, // Rounded
            { "ar-KW", "KWD", $"1٬234٬567٫890{Uni.Space}Dinars" }, // 3 decimal digits
            { "kk-KZ", "KZT", $"1{Uni.NBSP}234{Uni.NBSP}567,89{Uni.Space}₸" },
            { "si-LK", "LKR", $"LKR1,234,567.89" },
            { "mk-MK", "MKD", $"1.234.567,89{Uni.Space}den" },
            { "mn-MN", "MNT", $"MNT{Uni.Space}1,234,567.89" },
            { "dv-MV", "MVR", $"MVR{Uni.Space}1,234,567.89" },
            { "es-MX", "MXN", $"Mex$1,234,567.89" },
            { "ms-MY", "MYR", $"MYR1,234,567.89" },
            { "nb-NO", "NOK", $"NOK{Uni.Space}1{Uni.NBSP}234{Uni.NBSP}567,89" },
            { "en-PH", "PHP", $"PHP1,234,567.89" },

            // Currencies P-Z
            { "ur-PK", "PKR", $"PKR1,234,567.89" },
            { "pl-PL", "PLN", $"1{Uni.NBSP}234{Uni.NBSP}567,89{Uni.Space}zł" },
            { "ar-QA", "QAR", $"1٬234٬567٫89{Uni.Space}QR" },
            { "ro-RO", "RON", $"1.234.567,89{Uni.Space}lei" },
            { "sr-Latn-RS", "RSD", $"1.234.567,89{Uni.Space}din." },
            { "ru-RU", "RUB", $"1{Uni.NBSP}234{Uni.NBSP}567,89{Uni.Space}₽" },
            { "ar-SA", "SAR", $"1٬234٬567٫89{Uni.Space}SR" },
            { "sv-SE", "SEK", $"1{Uni.NBSP}234{Uni.NBSP}567,89{Uni.Space}kr" },
            { "en-SG", "SGD", $"S$1,234,567.89" },
            { "ar-SY", "SYP", $"1٬234٬568{Uni.Space}SYP" },
            { "th-TH", "THB", $"THB1,234,567.89" },
            { "tk-TM", "TMT", $"1{Uni.NBSP}234{Uni.NBSP}567,89{Uni.Space}TMT" },
            { "tr-TR", "TRY", $"TRY1.234.567,89" },
            { "zh-TW", "TWD", $"TW$1,234,567.89" },
            { "uk-UA", "UAH", $"1{Uni.NBSP}234{Uni.NBSP}567,89{Uni.Space}₴" },
            { "uz-Latn-UZ", "UZS", $"1{Uni.NBSP}234{Uni.NBSP}567,89{Uni.Space}soʻm" },
            { "vi-VN", "VND", $"1.234.568{Uni.Space}VND" }, // Rounded
            { "ar-YE", "YER", $"1٬234٬568{Uni.Space}YER" },

            // Currencies A-G (Batch 1 samples)
            { "ps-AF", "AFN", $"AFN{Uni.Space}1٬234٬568" }, // Rounded
            { "hy-AM", "AMD", $"1{Uni.NBSP}234{Uni.NBSP}567,89{Uni.Space}AMD" },
            { "az-Latn-AZ", "AZN", $"1.234.567,89{Uni.Space}AZN" },
            { "bn-BD", "BDT", $"12,34,567.89BDT" },
            { "en-CA", "CAD", $"C$1,234,567.89" },
            { "fr-CA", "CAD", $"1{Uni.NBSP}234{Uni.NBSP}567,89{Uni.Space}C$" },
            { "ka-GE", "GEL", $"1{Uni.NBSP}234{Uni.NBSP}567,89{Uni.Space}GEL" },
            { "be-BY", "BYN", $"1{Uni.NBSP}234{Uni.NBSP}567,89{Uni.Space}Br" },
            { "hu-HU", "HUF", $"1{Uni.NBSP}234{Uni.NBSP}568{Uni.Space}Ft" },
            { "km-KH", "KHR", "1.234.568៛" },
            { "zh-MO", "MOP", "P1,234,567.89" },
            { "ko-KP", "KPW", "₩1,234,568" }
        };

        return data;
    }

    public static TheoryData<string, string, string> GetSouthAmericanData()
    {
        var data = new TheoryData<string, string, string>
        {
            { "es-AR", "ARS", $"ARS{Uni.Space}1.234.567,89" },
            { "es-UY", "UYU", $"UYU{Uni.Space}1.234.568" },
            { "en-GY", "GYD", $"G$1,234,568" }, // Rounded
            { "es-CO", "COP", $"COP{Uni.Space}1.234.567,89" },
            { "nl-SR", "SRD", $"SRD{Uni.Space}1.234.567,89" },
            { "es-PY", "PYG", $"PYG{Uni.Space}1.234.568" }, // Rounded
            { "es-PE", "PEN", $"PEN{Uni.Space}1,234,567.89" },
            { "es-BO", "BOB", $"BOB1.234.567,89" }
        };
        return data;
    }

    public static TheoryData<string, string, string> GetCentralAmericanData()
    {
        var data = new TheoryData<string, string, string>
        {
            { "es-GT", "GTQ", $"Q1,234,567.89" },
            { "es-CR", "CRC", $"{Uni.Colon}1{Uni.NBSP}234{Uni.NBSP}567,89" },
            { "es-NI", "NIO", $"C$1,234,567.89" },
            { "en-BZ", "BZD", $"$1,234,567.89" },
            { "es-HN", "HNL", $"L1,234,567.89" },
            { "es-PA", "PAB", $"B/.1,234,567.89" },
            { "pt-TL", "USD", $"1{Uni.NBSP}234{Uni.NBSP}567,89{Uni.Space}US$" },
            { "tet-TL", "USD", $"$1,234,567.89" }
        };
        return data;
    }
}
