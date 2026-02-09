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
        };
        return data;
    }
}
