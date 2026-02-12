using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;
using System.Reflection;
using Xunit;

namespace MoneyKind4OposTest.Currencies.Generic;

public class DenominationPolicyTest
{
    [Theory]
    [InlineData(typeof(MopCurrency), 10.0, CashType.Coin, CashUsagePolicy.NonRecyclable)]
    [InlineData(typeof(IrrCurrency), 1000.0, CashType.Coin, CashUsagePolicy.NonRecyclable)]
    [InlineData(typeof(OmrCurrency), 0.005, CashType.Coin, CashUsagePolicy.NonRecyclable)]
    [InlineData(typeof(KwdCurrency), 0.001, CashType.Coin, CashUsagePolicy.NonRecyclable)]
    [InlineData(typeof(KztCurrency), 1.0, CashType.Coin, CashUsagePolicy.NonRecyclable)]
    [InlineData(typeof(CrcCurrency), 5.0, CashType.Coin, CashUsagePolicy.NonRecyclable)]
    [InlineData(typeof(JodCurrency), 0.01, CashType.Coin, CashUsagePolicy.NonRecyclable)]
    [InlineData(typeof(QarCurrency), 0.01, CashType.Coin, CashUsagePolicy.NonRecyclable)]
    [InlineData(typeof(UzsCurrency), 50.0, CashType.Coin, CashUsagePolicy.NonRecyclable)]
    [InlineData(typeof(TjsCurrency), 0.01, CashType.Coin, CashUsagePolicy.NonRecyclable)]
    [InlineData(typeof(CupCurrency), 0.01, CashType.Coin, CashUsagePolicy.NonRecyclable)]
    [InlineData(typeof(SrdCurrency), 0.01, CashType.Coin, CashUsagePolicy.NonRecyclable)]
    [InlineData(typeof(EgpCurrency), 0.05, CashType.Coin, CashUsagePolicy.NonRecyclable)]
    [InlineData(typeof(GnfCurrency), 1.0, CashType.Coin, CashUsagePolicy.NonRecyclable)]
    [InlineData(typeof(GhsCurrency), 0.01, CashType.Coin, CashUsagePolicy.NonRecyclable)]
    [InlineData(typeof(NgnCurrency), 0.50, CashType.Coin, CashUsagePolicy.NonRecyclable)]
    [InlineData(typeof(RwfCurrency), 1.0, CashType.Coin, CashUsagePolicy.NonRecyclable)]
    [InlineData(typeof(BifCurrency), 1.0, CashType.Coin, CashUsagePolicy.NonRecyclable)]
    [InlineData(typeof(DjfCurrency), 1.0, CashType.Coin, CashUsagePolicy.NonRecyclable)]
    [InlineData(typeof(KmfCurrency), 1.0, CashType.Coin, CashUsagePolicy.NonRecyclable)]
    [InlineData(typeof(ScrCurrency), 0.01, CashType.Coin, CashUsagePolicy.NonRecyclable)]
    [InlineData(typeof(MurCurrency), 0.05, CashType.Coin, CashUsagePolicy.NonRecyclable)]
    [InlineData(typeof(UgxCurrency), 50.0, CashType.Coin, CashUsagePolicy.NonRecyclable)]
    [InlineData(typeof(CdfCurrency), 50.0, CashType.Bill, CashUsagePolicy.NonRecyclable)]
    [InlineData(typeof(BhdCurrency), 0.50, CashType.Coin, CashUsagePolicy.NonRecyclable)]
    [InlineData(typeof(NadCurrency), 0.05, CashType.Coin, CashUsagePolicy.NonRecyclable)]
    [InlineData(typeof(MznCurrency), 0.01, CashType.Coin, CashUsagePolicy.NonRecyclable)]
    [InlineData(typeof(AllCurrency), 1.0, CashType.Coin, CashUsagePolicy.NonRecyclable)]
    [InlineData(typeof(MdlCurrency), 0.01, CashType.Coin, CashUsagePolicy.NonRecyclable)]
    [InlineData(typeof(MdlCurrency), 1.0, CashType.Bill, CashUsagePolicy.NonRecyclable)]
    public void UsagePolicy_ShouldBeConfiguredCorrectly(Type currencyType, decimal value, CashType type, CashUsagePolicy expectedPolicy)
    {
        // Arrange
        var coinsProp = currencyType.GetProperty("Coins", BindingFlags.Public | BindingFlags.Static);
        var billsProp = currencyType.GetProperty("Bills", BindingFlags.Public | BindingFlags.Static);

        IEnumerable<CashFaceInfo> items = [];

        if (type == CashType.Coin)
        {
            items = (IEnumerable<CashFaceInfo>)coinsProp!.GetValue(null)!;
        }
        else
        {
            items = (IEnumerable<CashFaceInfo>)billsProp!.GetValue(null)!;
        }

        // Act
        var targetItem = items.FirstOrDefault(x => x.Value == value);

        // Assert
        targetItem.ShouldNotBeNull($"Item with value {value} and type {type} not found in {currencyType.Name}");
        targetItem.Usage.ShouldBe(expectedPolicy, $"Item {targetItem} in {currencyType.Name} should have policy {expectedPolicy}");
    }
}
