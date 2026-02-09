using Xunit;

namespace MoneyKind4OposTest.Infrastructure;

/// <summary>探索対象のロケールと通貨コードを定義するクラス</summary>
public static class FormattingDiscoverySource
{
    public static TheoryData<string, string> GetDiscoveryData()
    {
        var data = new TheoryData<string, string>
        {
            // ここに新しく調査したいロケールを追加していく
            { "es-PA", "PAB" }, // パナマ
            { "en-BZ", "BZD" }, // ベリーズ
            { "es-HN", "HNL" }, // ホンジュラス
            { "pt-TL", "USD" }, // 東ティモール (ポルトガル語)
            { "tet-TL", "USD" }, // 東ティモール (テトゥン語)
        };
        return data;
    }
}
