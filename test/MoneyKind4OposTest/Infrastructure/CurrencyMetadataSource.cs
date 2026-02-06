using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies;

namespace MoneyKind4OposTest.Infrastructure;

public static class CurrencyMetadataSource
{
    public static TheoryData<Type, Iso4217, int, double> GetCurrencyMetadata()
    {
        var data = new TheoryData<Type, Iso4217, int, double>();

        // Major Currencies
        data.Add(typeof(JpyCurrency), Iso4217.JPY, 392, 1.0);
        data.Add(typeof(UsdCurrency), Iso4217.USD, 840, 0.01);
        data.Add(typeof(EurCurrency), Iso4217.EUR, 978, 0.01);
        data.Add(typeof(GbpCurrency), Iso4217.GBP, 826, 0.01);
        data.Add(typeof(CnyCurrency), Iso4217.CNY, 156, 0.01);
        data.Add(typeof(InrCurrency), Iso4217.INR, 356, 0.50);
        data.Add(typeof(ChfCurrency), Iso4217.CHF, 756, 0.05);
        data.Add(typeof(AudCurrency), Iso4217.AUD, 36, 0.05);
        data.Add(typeof(CadCurrency), Iso4217.CAD, 124, 0.05);
        data.Add(typeof(NokCurrency), Iso4217.NOK, 578, 1.0);
        data.Add(typeof(SekCurrency), Iso4217.SEK, 752, 1.0);
        data.Add(typeof(DkkCurrency), Iso4217.DKK, 208, 0.50);
        data.Add(typeof(NzdCurrency), Iso4217.NZD, 554, 0.10);
        data.Add(typeof(SgdCurrency), Iso4217.SGD, 702, 0.05);
        data.Add(typeof(HkdCurrency), Iso4217.HKD, 344, 0.10);
        data.Add(typeof(KrwCurrency), Iso4217.KRW, 410, 1.0);
        data.Add(typeof(TwdCurrency), Iso4217.TWD, 158, 1.0);

        // Middle East / High Value
        data.Add(typeof(KwdCurrency), Iso4217.KWD, 414, 0.001);
        data.Add(typeof(BhdCurrency), Iso4217.BHD, 48, 0.005);
        data.Add(typeof(OmrCurrency), Iso4217.OMR, 512, 0.005);
        data.Add(typeof(JodCurrency), Iso4217.JOD, 400, 0.01);
        data.Add(typeof(AedCurrency), Iso4217.AED, 784, 0.25);
        data.Add(typeof(QarCurrency), Iso4217.QAR, 634, 0.01);
        data.Add(typeof(SarCurrency), Iso4217.SAR, 682, 0.01);
        data.Add(typeof(KydCurrency), Iso4217.KYD, 136, 0.01);
        data.Add(typeof(BndCurrency), Iso4217.BND, 96, 0.01);

        // Common Currencies
        data.Add(typeof(BrlCurrency), Iso4217.BRL, 986, 0.01);
        data.Add(typeof(BynCurrency), Iso4217.BYN, 933, 0.01);
        data.Add(typeof(ClpCurrency), Iso4217.CLP, 152, 1.0);
        data.Add(typeof(CzkCurrency), Iso4217.CZK, 203, 1.0);
        data.Add(typeof(IlsCurrency), Iso4217.ILS, 376, 0.10);
        data.Add(typeof(KztCurrency), Iso4217.KZT, 398, 1.0);
        data.Add(typeof(MxnCurrency), Iso4217.MXN, 484, 0.05);
        data.Add(typeof(PlnCurrency), Iso4217.PLN, 985, 0.01);
        data.Add(typeof(RubCurrency), Iso4217.RUB, 643, 0.01);
        data.Add(typeof(UzsCurrency), Iso4217.UZS, 860, 50.0);
        data.Add(typeof(ZarCurrency), Iso4217.ZAR, 710, 0.10);

        // Unions & Regional
        data.Add(typeof(XafCurrency), Iso4217.XAF, 950, 1.0);
        data.Add(typeof(XofCurrency), Iso4217.XOF, 952, 1.0);
        data.Add(typeof(XcdCurrency), Iso4217.XCD, 951, 0.05);
        data.Add(typeof(VndCurrency), Iso4217.VND, 704, 1000.0);
        data.Add(typeof(IdrCurrency), Iso4217.IDR, 360, 50.0);
        data.Add(typeof(ThbCurrency), Iso4217.THB, 764, 0.25);
        data.Add(typeof(PhpCurrency), Iso4217.PHP, 608, 0.01);
        data.Add(typeof(MyrCurrency), Iso4217.MYR, 458, 0.05);
        data.Add(typeof(LakCurrency), Iso4217.LAK, 418, 500.0);
        data.Add(typeof(BdtCurrency), Iso4217.BDT, 50, 1.0);
        data.Add(typeof(PkrCurrency), Iso4217.PKR, 586, 1.0);
        data.Add(typeof(KgsCurrency), Iso4217.KGS, 417, 1.0);
        data.Add(typeof(LkrCurrency), Iso4217.LKR, 144, 1.0);
        data.Add(typeof(NprCurrency), Iso4217.NPR, 524, 1.0);
        data.Add(typeof(MmkCurrency), Iso4217.MMK, 104, 100.0);
        data.Add(typeof(BtnCurrency), Iso4217.BTN, 64, 0.05);
        data.Add(typeof(MvrCurrency), Iso4217.MVR, 462, 0.01);
        data.Add(typeof(AfnCurrency), Iso4217.AFN, 971, 1.0);
        data.Add(typeof(IrrCurrency), Iso4217.IRR, 364, 1000.0);
        data.Add(typeof(MntCurrency), Iso4217.MNT, 496, 1.0);
        data.Add(typeof(TjsCurrency), Iso4217.TJS, 972, 0.01);
        data.Add(typeof(TmtCurrency), Iso4217.TMT, 934, 0.01);

        // Caucasian & Middle East (Newly Added)
        data.Add(typeof(AznCurrency), Iso4217.AZN, 944, 0.01);
        data.Add(typeof(AmdCurrency), Iso4217.AMD, 51, 10.0);
        data.Add(typeof(YerCurrency), Iso4217.YER, 886, 1.0);
        data.Add(typeof(IqdCurrency), Iso4217.IQD, 368, 250.0);
        data.Add(typeof(GelCurrency), Iso4217.GEL, 981, 0.05);
        data.Add(typeof(SypCurrency), Iso4217.SYP, 760, 1.0);
        data.Add(typeof(TryCurrency), Iso4217.TRY, 949, 0.01);
        data.Add(typeof(LbpCurrency), Iso4217.LBP, 422, 250.0);

        // Balkan & Eastern Europe
        data.Add(typeof(AllCurrency), Iso4217.ALL, 8, 1.0);
        data.Add(typeof(UahCurrency), Iso4217.UAH, 980, 0.10);
        data.Add(typeof(MkdCurrency), Iso4217.MKD, 807, 1.0);
        data.Add(typeof(RsdCurrency), Iso4217.RSD, 941, 1.0);
        data.Add(typeof(BamCurrency), Iso4217.BAM, 977, 0.05);
        data.Add(typeof(MdlCurrency), Iso4217.MDL, 498, 0.01);
        data.Add(typeof(RonCurrency), Iso4217.RON, 946, 0.01);

        return data;
    }
}
