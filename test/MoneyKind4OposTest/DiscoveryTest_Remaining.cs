using System.Globalization;
using MoneyKind4OposTest.Infrastructure;
using Shouldly;
using Xunit;

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
            var formatted = amount.ToString("C", culture);
            
            // あえて失敗させることで、テスト結果から実際の値を取得する
            formatted.ShouldBe("DISCOVERY_REQUIRED");
        }
        catch (CultureNotFoundException)
        {
            // OSでサポートされていないロケールの場合
            $"CULTURE_NOT_SUPPORTED: {cultureName}".ShouldBe("DISCOVERY_REQUIRED");
        }
        catch (Exception ex)
        {
            $"ERROR: {ex.Message}".ShouldBe("DISCOVERY_REQUIRED");
        }
    }
}
