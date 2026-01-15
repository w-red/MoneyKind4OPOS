using MoneyKind4Opos.Currencies;
using Shouldly;

namespace MoneyKind4OPOSTest.InterfaceTests;

/// <summary>ICurrency contract tests.</summary>
public class ICurrencyContractTest
{
    [Theory]
    [InlineData(typeof(JpyCurrency))]
    [InlineData(typeof(UsdCurrency))]
    [InlineData(typeof(EurCurrency))]
    [InlineData(typeof(GbpCurrency))]
    [InlineData(typeof(CnyCurrency))]
    public void Coins_ShouldNotBeNull(Type currencyType)
    {
        var coins = GetCoins(currencyType);
        coins.ShouldNotBeNull();
    }

    [Theory]
    [InlineData(typeof(JpyCurrency))]
    [InlineData(typeof(UsdCurrency))]
    [InlineData(typeof(EurCurrency))]
    [InlineData(typeof(GbpCurrency))]
    [InlineData(typeof(CnyCurrency))]
    public void Bills_ShouldNotBeNull(Type currencyType)
    {
        var bills = GetBills(currencyType);
        bills.ShouldNotBeNull();
    }

    [Theory]
    [InlineData(typeof(JpyCurrency))]
    [InlineData(typeof(UsdCurrency))]
    [InlineData(typeof(EurCurrency))]
    [InlineData(typeof(GbpCurrency))]
    [InlineData(typeof(CnyCurrency))]
    public void Coins_ShouldHaveUniqueValues(Type currencyType)
    {
        var coins = GetCoins(currencyType);
        var values = coins.Select(c => c.Value).ToList();
        values.ShouldBeUnique();
    }

    [Theory]
    [InlineData(typeof(JpyCurrency))]
    [InlineData(typeof(UsdCurrency))]
    [InlineData(typeof(EurCurrency))]
    [InlineData(typeof(GbpCurrency))]
    [InlineData(typeof(CnyCurrency))]
    public void Bills_ShouldHaveUniqueValues(Type currencyType)
    {
        var bills = GetBills(currencyType);
        var values = bills.Select(b => b.Value).ToList();
        values.ShouldBeUnique();
    }

    [Theory]
    [InlineData(typeof(JpyCurrency))]
    [InlineData(typeof(UsdCurrency))]
    [InlineData(typeof(EurCurrency))]
    [InlineData(typeof(GbpCurrency))]
    [InlineData(typeof(CnyCurrency))]
    public void MinimumUnit_ShouldBePositive(Type currencyType)
    {
        var minimumUnit = GetMinimumUnit(currencyType);
        minimumUnit.ShouldBeGreaterThan(0);
    }

    [Theory]
    [InlineData(typeof(JpyCurrency))]
    [InlineData(typeof(UsdCurrency))]
    [InlineData(typeof(EurCurrency))]
    [InlineData(typeof(GbpCurrency))]
    [InlineData(typeof(CnyCurrency))]
    public void MinimumUnit_ShouldMatchSmallestCoinValue(Type currencyType)
    {
        var minimumUnit = GetMinimumUnit(currencyType);
        var coins = GetCoins(currencyType);
        
        if (coins.Any())
        {
            var smallestCoin = coins.Min(c => c.Value);
            minimumUnit.ShouldBe(smallestCoin);
        }
    }

    // ヘルパーメソッド: リフレクションを使って静的プロパティを取得
    private static IEnumerable<CashFaceInfo> GetCoins(Type currencyType)
    {
        var property = currencyType.GetProperty("Coins");
        return (IEnumerable<CashFaceInfo>)property!.GetValue(null)!;
    }

    private static IEnumerable<CashFaceInfo> GetBills(Type currencyType)
    {
        var property = currencyType.GetProperty("Bills");
        return (IEnumerable<CashFaceInfo>)property!.GetValue(null)!;
    }

    private static decimal GetMinimumUnit(Type currencyType)
    {
        var property = currencyType.GetProperty("MinimumUnit");
        return (decimal)property!.GetValue(null)!;
    }
}
