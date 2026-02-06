using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Extensions;
using Shouldly;

namespace MoneyKind4OposTest.Extensions;

/// <summary>Tests for C# 14 Extension Types defined in CurrencyExtensions.</summary>
public class ExtensionTypesTest
{
    [Theory]
    [InlineData(1500, "¥1,500")]
    [InlineData(1234567, "¥1,234,567")]
    [InlineData(999, "¥999")]
    public void DecimalToGlobalStringJpyShouldHandleDigitGrouping(decimal value, string expected)
    {
        // Verified: JPY Global uses "," as GroupSeparator
        var result = value.ToGlobalString<JpyCurrency>();
        result.ShouldBe(expected);
    }

    [Theory]
    [InlineData(1500, "1,500円")]
    [InlineData(1234567, "1,234,567円")]
    public void DecimalToLocalStringJpyShouldHandleDigitGrouping(decimal value, string expected)
    {
        var result = value.ToLocalString<JpyCurrency>();
        result.ShouldBe(expected);
    }

    [Fact]
    public void DecimalToGlobalStringEurShouldHandleEuropeanGrouping()
    {
        // EurCurrency Global: CurrencyPositivePattern = 3 (n €), GroupSeparator = ".", DecimalSeparator = ","
        decimal value = 1234.56m;
        var result = value.ToGlobalString<EurCurrency>();

        // Expected: "1.234,56 €" (Space before symbol, comma as decimal)
        result.ShouldBe("1.234,56 €");
    }

    [Fact]
    public void DecimalToCurrencyStringShouldUseLocalWithGrouping()
    {
        decimal value = 10000m;
        var result = value.ToCurrencyString<JpyCurrency>();

        // ToCurrencyString aliases ToLocalString by default
        result.ShouldBe("10,000円");
    }
}
