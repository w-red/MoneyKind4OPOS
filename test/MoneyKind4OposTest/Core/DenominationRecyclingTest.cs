using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OposTest.Core;

public class DenominationRecyclingTest
{
    [Fact]
    public void JpyCalculateChangeShouldSkipTwoThousandYenByDefault()
    {
        var mk = new MoneyKind<JpyCurrency>();
        mk[1000m] = 10;
        mk[2000m] = 10; // 2000 Yen is NonRecyclable

        // Request 2000 Yen change
        var result = mk.CalculateChange(2000m);

        // Should use two 1000 Yen bills instead of one 2000 Yen bill
        result[1000m].ShouldBe(2);
        result[2000m].ShouldBe(0);
        result.TotalAmount().ShouldBe(2000m);
    }

    [Fact]
    public void JpyCalculateChangeShouldUseTwoThousandYenIfOnlyRecyclableIsFalse()
    {
        var mk = new MoneyKind<JpyCurrency>();
        mk[1000m] = 10;
        mk[2000m] = 10;

        // Request 2000 Yen change with onlyRecyclable: false
        var result = mk.CalculateChange(2000m, onlyRecyclable: false);

        // Should use one 2000 Yen bill
        result[2000m].ShouldBe(1);
        result[1000m].ShouldBe(0);
    }

    [Fact]
    public void JpyCalculateChangeShouldSkipTenThousandYenByDefault()
    {
        var mk = new MoneyKind<JpyCurrency>();
        mk[1000m] = 20;
        mk[10000m] = 5; // 10000 Yen is CollectionOnly

        // Request 10000 Yen change
        var result = mk.CalculateChange(10000m);

        // Should use ten 1000 Yen bills
        result[1000m].ShouldBe(10);
        result[10000m].ShouldBe(0);
    }

    [Fact]
    public void UsdCalculateChangeShouldSkipTwoDollarBillByDefault()
    {
        var mk = new MoneyKind<UsdCurrency>();
        mk[1m] = 10;
        mk[2m] = 10; // $2 is NonRecyclable

        // Request $2 change
        var result = mk.CalculateChange(2m);

        // Should use two $1 bills
        result[1m].ShouldBe(2);
        result[2m].ShouldBe(0);
    }
}
