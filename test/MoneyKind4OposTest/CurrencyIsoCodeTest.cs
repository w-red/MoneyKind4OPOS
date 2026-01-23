using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest;

/// <summary>
/// Verifies the correctness of ISO 4217 codes and basic properties for key currencies.
/// </summary>
public class CurrencyIsoCodeTest
{
    [Theory]
    [InlineData(typeof(JpyCurrency), Iso4217.JPY, 392, 1.0)]
    [InlineData(typeof(UsdCurrency), Iso4217.USD, 840, 0.01)]
    [InlineData(typeof(EurCurrency), Iso4217.EUR, 978, 0.01)]
    [InlineData(typeof(CnyCurrency), Iso4217.CNY, 156, 0.01)]
    public void Currency_ShouldHaveCorrectIsoCodeAndMinimumUnit(
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
    public void Iso4217_Enum_ShouldContainCorrectValues()
    {
        // Direct verification of some known codes
        ((int)Iso4217.JPY).ShouldBe(392);
        ((int)Iso4217.USD).ShouldBe(840);
        ((int)Iso4217.EUR).ShouldBe(978);
        ((int)Iso4217.CNY).ShouldBe(156);
    }
}
