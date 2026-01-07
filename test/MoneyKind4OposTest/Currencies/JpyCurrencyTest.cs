using MoneyKind4Opos.Codes;
using MoneyKind4Opos.Currencies;
using Shouldly;

namespace MoneyKind4OPOSTest.Currencies;

public class JpyCurrencyTest
{
    [Fact]
    public void Property_ShouldBe_Correct()
    {
        JpyCurrency.Code.ShouldBe(Iso4217.JPY);
        JpyCurrency.MinimumUnit.ShouldBe(1m);
    }

    [Fact]
    public void Faces_Should_MatchExpected()
    {
        var coins = JpyCurrency.Coins.Select(f => f.Value).ToArray();
        coins.ShouldBe([1m, 5m, 10m, 50m, 100m, 500m]);

        var bills = JpyCurrency.Bills.Select(f => f.Value).ToArray();
        bills.ShouldBe([1000m, 2000m, 5000m, 10000m]);
    }
}
