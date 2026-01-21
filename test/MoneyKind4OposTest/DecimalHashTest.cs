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
}
