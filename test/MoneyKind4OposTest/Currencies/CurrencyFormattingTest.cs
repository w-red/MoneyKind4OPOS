using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Extensions;
using Shouldly;

namespace MoneyKind4OPOSTest.Currencies;

/// <summary>Tests for currency formatting logic (ToLocalString / ToGlobalString).</summary>
public class CurrencyFormattingTest
{
    [Theory]
    [InlineData(12.34, "12.34元", "¥12.34")]
    [InlineData(0.50, "5角", "¥0.50")]
    [InlineData(0.02, "2分", "¥0.02")]
    [InlineData(0.12, "1角2分", "¥0.12")]
    [InlineData(0, "0.00元", "¥0.00")]
    public void Cny_Formatting_ShouldBeCorrect(
        decimal amount,
        string expectedLocal,
        string expectedGlobal)
    {
        amount.ToLocalString<CnyCurrency>().ShouldBe(expectedLocal);
        amount.ToGlobalString<CnyCurrency>().ShouldBe(expectedGlobal);
    }

    [Theory]
    [InlineData(1000, "1,000円", "¥1,000")]
    public void Jpy_Formatting_ShouldBeCorrect(
        decimal amount,
        string expectedLocal,
        string expectedGlobal)
    {
        amount.ToLocalString<JpyCurrency>().ShouldBe(expectedLocal);
        amount.ToGlobalString<JpyCurrency>().ShouldBe(expectedGlobal);
    }

    [Theory]
    [InlineData(1.23, "$1.23", "$1.23")]
    public void Usd_Formatting_ShouldBeCorrect(
        decimal amount,
        string expectedLocal,
        string expectedGlobal)
    {
        amount.ToLocalString<UsdCurrency>().ShouldBe(expectedLocal);
        amount.ToGlobalString<UsdCurrency>().ShouldBe(expectedGlobal);
    }
}
