using System.Globalization;
using MoneyKind4OposTest.Infrastructure;

namespace MoneyKind4OposTest;

/// <summary>
/// 新規通貨実装時に、OSの標準フォーマット（絶対解）を特定するためのユーティリティテスト。
/// Infrastructure/FormattingDiscoverySource.cs に対象を追加して実行する。
/// </summary>
public class FormattingDiscoveryTest
{
    [Theory]
    [MemberData(nameof(FormattingDiscoverySource.GetDiscoveryData), MemberType = typeof(FormattingDiscoverySource))]
    public void DiscoverFormats(string cultureName, string currencyCode)
    {
        try
        {
            var culture = new CultureInfo(cultureName);
            var amount = 1234567.89m;
            // Shouldlyの巨大な差分出力を避け、簡潔に結果を表示する
            throw new Exception($"RESULT [{currencyCode}]: {amount.ToString("C", culture)}");
        }
        catch (CultureNotFoundException)
        {
            // OSでサポートされていないロケールの場合
            throw new Exception($"RESULT: CULTURE_NOT_SUPPORTED");
        }
        catch (Exception ex) when (!ex.Message.StartsWith("RESULT:"))
        {
            throw new Exception($"RESULT: ERROR: {ex.Message}");
        }
    }
}
