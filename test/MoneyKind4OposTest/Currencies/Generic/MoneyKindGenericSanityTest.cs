using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using MoneyKind4OposTest.Infrastructure;
using Shouldly;
using System.Reflection;

namespace MoneyKind4OposTest.Currencies.Generic;

public class MoneyKindGenericSanityTest
{
    /// <summary>Verifies basic parsing, total calculation, and serialization round-trip for every currency implementation.</summary>
    [Theory]
    [MemberData(nameof(CurrencyMetadataSource.GetCurrencyMetadata), MemberType = typeof(CurrencyMetadataSource))]
    public void MoneyKindBasicSanityShouldWork(
        Type currencyType,
        Iso4217 _code,
        int _numeric,
        double _minUnit)
    {
        _ = _code;
        _ = _numeric;
        _ = _minUnit;

        string typeName = currencyType.Name;
        // Construct MoneyKind<TCurrency> type
        var moneyKindType = typeof(MoneyKind<>).MakeGenericType(currencyType);
        
        // 1. Get Methods
        var methods = moneyKindType.GetMethods(BindingFlags.Public | BindingFlags.Static);
        var parseMethod = methods.FirstOrDefault(m => m.Name == "Parse" && m.GetParameters().Length == 1 && m.GetParameters()[0].ParameterType == typeof(string));
        
        var totalAmountMethod = moneyKindType.GetMethod("TotalAmount", BindingFlags.Public | BindingFlags.Instance);
        var toCashCountsStringMethod = moneyKindType
            .GetMethod(
                "ToCashCountsString",
                BindingFlags.Public
                | BindingFlags.Instance,
                null,
                [typeof(string), typeof(string)],
                null);

        parseMethod.ShouldNotBeNull($"{typeName}: Parse method not found");
        totalAmountMethod.ShouldNotBeNull($"{typeName}: TotalAmount method not found");
        toCashCountsStringMethod.ShouldNotBeNull($"{typeName}: ToCashCountsString method not found");

        // 2. Empty Parse Check
        var emptyInstance = parseMethod.Invoke(
            null, [""]);
        var emptyTotal = (decimal)totalAmountMethod.Invoke(emptyInstance, null)!;
        emptyTotal.ShouldBe(0m, $"{typeName}: Empty total should be 0");

        // 3. ToCashCountsString & Round-trip Consistency
        var coinsProp = currencyType.GetProperty("Coins", BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
        var billsProp = currencyType.GetProperty("Bills", BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
        
        var coins = (IEnumerable<CashFaceInfo>)coinsProp!.GetValue(null)!;
        var bills = (IEnumerable<CashFaceInfo>)billsProp!.GetValue(null)!;

        var instance = Activator.CreateInstance(moneyKindType);
        
        // Use explicit indexer this[decimal, CashType] to avoid overlaps (e.g. NPR/AFN)
        var setItemExplicitMethod = moneyKindType
            .GetMethod(
                "set_Item",
                BindingFlags.Public
                | BindingFlags.Instance,
                null,
                [typeof(decimal), typeof(CashType), typeof(int)],
                null);
        setItemExplicitMethod.ShouldNotBeNull($"{typeName}: Explicit Indexer setter not found");

        decimal expectedTotal = 0m;

        if (coins.Any())
        {
            var firstCoin = coins.First();
            setItemExplicitMethod
                .Invoke(
                    instance,
                    [
                        firstCoin.Value,
                        CashType.Coin,
                        1
                    ]);
            expectedTotal += firstCoin.Value;
        }

        if (bills.Any())
        {
            var lastBill = bills.OrderBy(b => b.Value).Last(); // Pick largest bill to avoid overlap with coin if possible
            setItemExplicitMethod
                .Invoke(
                    instance,
                    [
                        lastBill.Value,
                        CashType.Bill,
                        2
                    ]); 
            expectedTotal += lastBill.Value * 2;
        }

        if (expectedTotal > 0)
        {
            // Verify Total
            var total = (decimal)totalAmountMethod.Invoke(instance, null)!;
            total.ShouldBe(expectedTotal, $"{typeName}: Initial total mismatch");

            // Verify Round-trip
            var serialized = (string)toCashCountsStringMethod
                .Invoke(
                    instance, [null!, null!]
                )!;
            var reParsed = parseMethod
                .Invoke(
                    null,
                    [serialized]);
            var reParsedTotal = (decimal)totalAmountMethod.Invoke(reParsed, null)!;
            
            reParsedTotal.ShouldBe(expectedTotal, $"{typeName}: Round-trip total mismatch (Serialized: '{serialized}')");
        }
    }
}
