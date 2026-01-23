using MoneyKind4Opos.Currencies.Interfaces;
using Shouldly;

namespace MoneyKind4OPOSTest;

public class DecimalHashTest
{
    [Fact]
    public void Decimal_HashCode_ShouldBeScaleInvariant()
    {
        decimal d1 = 1.0m;
        decimal d2 = 1.00m;
        decimal d3 = 1m;

        // Numerical equality
        (d1 == d2).ShouldBeTrue();
        (d2 == d3).ShouldBeTrue();

        // Hash code equality (The core of our assumption for .NET 9+)
        var h1 = d1.GetHashCode();
        var h2 = d2.GetHashCode();
        var h3 = d3.GetHashCode();

        h1.ShouldBe(h2, $"Hash codes for {d1} and {d2} are different: {h1} vs {h2}");
        h2.ShouldBe(h3, $"Hash codes for {d2} and {d3} are different: {h2} vs {h3}");

        // Dictionary lookup test
        var dict = new Dictionary<decimal, string>
        {
            [1.00m] = "Match"
        };
        dict.ContainsKey(1m).ShouldBeTrue("Dictionary failed to find 1m when 1.00m was the key.");
        dict.ContainsKey(1.0m).ShouldBeTrue("Dictionary failed to find 1.0m when 1.00m was the key.");
    }

    [Fact]
    public void MoneyKind_Indexer_ShouldBeScaleInvariant()
    {
        // Using JPY as a concrete example
        var mk = new MoneyKind<MoneyKind4Opos.Currencies.JpyCurrency>();
        
        // 1. Set using high precision
        mk[100.000m] = 10;
        
        // 2. Access using low precision
        mk[100m].ShouldBe(10);
        
        // 3. Update using intermediate precision
        mk[100.0m] = 20;
        
        // 4. Verify original key also reflects change
        mk[100.000m].ShouldBe(20);
        
        // 5. Verify it didn't create multiple entries in the underlying dictionary
        // (MoneyKind initializes all supported denominations, so we check they aren't unexpectedly increased)
        mk.Counts.Values.Sum().ShouldBe(20); 
    }
}
