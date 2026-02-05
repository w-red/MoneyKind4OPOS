using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest;

/// <summary>Verifies the correctness of ISO 4217 codes and basic properties for key currencies.</summary>
public class CurrencyIsoCodeTest
{
    [Theory]
    // Major Currencies
    [InlineData(typeof(JpyCurrency), Iso4217.JPY, 392, 1.0)]
    [InlineData(typeof(UsdCurrency), Iso4217.USD, 840, 0.01)]
    [InlineData(typeof(EurCurrency), Iso4217.EUR, 978, 0.01)]
    [InlineData(typeof(GbpCurrency), Iso4217.GBP, 826, 0.01)]
    [InlineData(typeof(CnyCurrency), Iso4217.CNY, 156, 0.01)]
    [InlineData(typeof(InrCurrency), Iso4217.INR, 356, 0.50)]
    [InlineData(typeof(ChfCurrency), Iso4217.CHF, 756, 0.05)]
    [InlineData(typeof(AudCurrency), Iso4217.AUD, 36, 0.05)]
    [InlineData(typeof(CadCurrency), Iso4217.CAD, 124, 0.05)]
    [InlineData(typeof(NokCurrency), Iso4217.NOK, 578, 1.0)]
    [InlineData(typeof(SekCurrency), Iso4217.SEK, 752, 1.0)]
    [InlineData(typeof(DkkCurrency), Iso4217.DKK, 208, 0.50)]
    [InlineData(typeof(NzdCurrency), Iso4217.NZD, 554, 0.10)]
    [InlineData(typeof(SgdCurrency), Iso4217.SGD, 702, 0.05)]
    [InlineData(typeof(HkdCurrency), Iso4217.HKD, 344, 0.10)]
    [InlineData(typeof(KrwCurrency), Iso4217.KRW, 410, 1.0)]
    [InlineData(typeof(TwdCurrency), Iso4217.TWD, 158, 1.0)]
    // High Value / Fixed Rate (Group A & B)
    [InlineData(typeof(KwdCurrency), Iso4217.KWD, 414, 0.001)]
    [InlineData(typeof(BhdCurrency), Iso4217.BHD, 48, 0.005)]
    [InlineData(typeof(OmrCurrency), Iso4217.OMR, 512, 0.005)]
    [InlineData(typeof(JodCurrency), Iso4217.JOD, 400, 0.01)]
    [InlineData(typeof(AedCurrency), Iso4217.AED, 784, 0.25)]
    [InlineData(typeof(QarCurrency), Iso4217.QAR, 634, 0.01)]
    [InlineData(typeof(SarCurrency), Iso4217.SAR, 682, 0.01)]
    [InlineData(typeof(KydCurrency), Iso4217.KYD, 136, 0.01)]
    [InlineData(typeof(BndCurrency), Iso4217.BND, 96, 0.01)]
    // Other Common Currencies
    [InlineData(typeof(BrlCurrency), Iso4217.BRL, 986, 0.01)]
    [InlineData(typeof(BynCurrency), Iso4217.BYN, 933, 0.01)]
    [InlineData(typeof(ClpCurrency), Iso4217.CLP, 152, 1.0)]
    [InlineData(typeof(CzkCurrency), Iso4217.CZK, 203, 1.0)]
    [InlineData(typeof(IlsCurrency), Iso4217.ILS, 376, 0.10)]
    [InlineData(typeof(KztCurrency), Iso4217.KZT, 398, 1.0)]
    [InlineData(typeof(MxnCurrency), Iso4217.MXN, 484, 0.05)]
    [InlineData(typeof(PlnCurrency), Iso4217.PLN, 985, 0.01)]
    [InlineData(typeof(RubCurrency), Iso4217.RUB, 643, 0.01)]
    [InlineData(typeof(UzsCurrency), Iso4217.UZS, 860, 50.0)]
    [InlineData(typeof(ZarCurrency), Iso4217.ZAR, 710, 0.10)]
    // Regional Unions
    [InlineData(typeof(XafCurrency), Iso4217.XAF, 950, 1.0)]
    [InlineData(typeof(XofCurrency), Iso4217.XOF, 952, 1.0)]
    [InlineData(typeof(XcdCurrency), Iso4217.XCD, 951, 0.05)]
    [InlineData(typeof(VndCurrency), Iso4217.VND, 704, 1000.0)]
    [InlineData(typeof(IdrCurrency), Iso4217.IDR, 360, 50.0)]
    [InlineData(typeof(ThbCurrency), Iso4217.THB, 764, 0.25)]
    [InlineData(typeof(PhpCurrency), Iso4217.PHP, 608, 0.01)]
    [InlineData(typeof(MyrCurrency), Iso4217.MYR, 458, 0.05)]
    [InlineData(typeof(LakCurrency), Iso4217.LAK, 418, 500.0)]
    [InlineData(typeof(BdtCurrency), Iso4217.BDT, 50, 1.0)]
    [InlineData(typeof(PkrCurrency), Iso4217.PKR, 586, 1.0)]
    [InlineData(typeof(KgsCurrency), Iso4217.KGS, 417, 1.0)]
    [InlineData(typeof(LkrCurrency), Iso4217.LKR, 144, 1.0)]
    [InlineData(typeof(NprCurrency), Iso4217.NPR, 524, 1.0)]
    [InlineData(typeof(MmkCurrency), Iso4217.MMK, 104, 100.0)]
    [InlineData(typeof(BtnCurrency), Iso4217.BTN, 64, 0.05)]
    [InlineData(typeof(MvrCurrency), Iso4217.MVR, 462, 0.01)]
    public void Currency_ShouldHaveCorrectIsoCodeAndMinimumUnit(
        Type currencyType,
        Iso4217 expectedEnum,
        int expectedNumeric,
        double expectedMinUnit)
    {
        // Access static abstract properties via reflection
        var codeProp = currencyType
            .GetProperty(nameof(ICurrency.Code));
        var minUnitProp = currencyType
            .GetProperty(nameof(ICurrency.MinimumUnit));

        var actualCode = (Iso4217)codeProp!
            .GetValue(null)!;
        var actualMinUnit = (decimal)minUnitProp!
            .GetValue(null)!;

        // Verify Enum value
        actualCode
            .ShouldBe(expectedEnum);

        // Verify underlying Numeric value (ISO 4217 Standard)
        ((int)actualCode)
            .ShouldBe(expectedNumeric);

        // Verify Minimum Unit
        actualMinUnit
            .ShouldBe((decimal)expectedMinUnit);
    }

    [Fact]
    public void Iso4217_Enum_ShouldContainCorrectValues()
    {
        // Direct verification of some known codes
        ((int)Iso4217.JPY).ShouldBe(392);
        ((int)Iso4217.USD).ShouldBe(840);
        ((int)Iso4217.EUR).ShouldBe(978);
        ((int)Iso4217.GBP).ShouldBe(826);
        ((int)Iso4217.CNY).ShouldBe(156);
        ((int)Iso4217.CHF).ShouldBe(756);
        ((int)Iso4217.INR).ShouldBe(356);
        ((int)Iso4217.AUD).ShouldBe(36);
    }
}
