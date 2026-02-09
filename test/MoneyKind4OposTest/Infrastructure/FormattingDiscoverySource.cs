using Xunit;

namespace MoneyKind4OposTest.Infrastructure;

/// <summary>探索対象のロケールと通貨コードを定義するクラス</summary>
public static class FormattingDiscoverySource
{
    public static TheoryData<string, string> GetDiscoveryData()
    {
        var data = new TheoryData<string, string>
        {
            // 探索完了後はここを空にする
            // 新しい通貨を追加する際にここにロケールと通貨コードを追加してテストを実行する
        };
        return data;
    }
}
