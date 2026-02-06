using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies.Interfaces;
using MoneyKind4OposTest.Infrastructure;
using Shouldly;

namespace MoneyKind4OposTest.Currencies.Metadata;

/// <summary>Verifies the correctness of ISO 4217 codes and basic properties for all implemented currencies.</summary>
public class CurrencyMetadataTest
{
    [Theory]
    [MemberData(nameof(CurrencyMetadataSource.GetCurrencyMetadata), MemberType = typeof(CurrencyMetadataSource))]
    public void CurrencyShouldHaveCorrectIsoCodeAndMinimumUnit(
        Type currencyType,
        Iso4217 expectedEnum,
        int expectedNumeric,
        double expectedMinUnit)
    {
        // Access static abstract properties via reflection
        var codeProp = currencyType.GetProperty(nameof(ICurrency.Code));
        var minUnitProp = currencyType.GetProperty(nameof(ICurrency.MinimumUnit));

        var actualCode = (Iso4217)codeProp!.GetValue(null)!;
        var actualMinUnit = (decimal)minUnitProp!.GetValue(null)!;

        // Verify Enum value
        actualCode.ShouldBe(expectedEnum);

        // Verify underlying Numeric value (ISO 4217 Standard)
        ((int)actualCode).ShouldBe(expectedNumeric);

        // Verify Minimum Unit
        actualMinUnit.ShouldBe((decimal)expectedMinUnit);
    }

    [Fact]
    public void Iso4217EnumShouldContainCorrectValues()
    {
        // Direct verification of key codes as integrity check
        ((int)Iso4217.JPY).ShouldBe(392);
        ((int)Iso4217.USD).ShouldBe(840);
        ((int)Iso4217.EUR).ShouldBe(978);
        ((int)Iso4217.GBP).ShouldBe(826);
    }
}
