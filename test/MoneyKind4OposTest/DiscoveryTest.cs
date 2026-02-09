using System.Globalization;
using Xunit;
using Shouldly;

namespace MoneyKind4OposTest;

public class DiscoveryTest
{
    [Theory]
    [InlineData("es-GT", "GTQ")]
    [InlineData("es-CR", "CRC")]
    [InlineData("es-NI", "NIO")]
    public void DiscoverFormats(string cultureName, string currencyCode)
    {
        var culture = new CultureInfo(cultureName);
        var amount = 1234567.89m;
        var formatted = amount.ToString("C", culture);
        
        // This will fail and show the actual value in the error message
        formatted.ShouldBe("DISCOVERY");
    }
}
