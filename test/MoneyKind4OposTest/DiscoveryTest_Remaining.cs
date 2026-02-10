using System.Globalization;
using MoneyKind4OposTest.Infrastructure;

namespace MoneyKind4OposTest;
#if MONEYKIND_DISCOVERY

/// <summary>
/// Utility test for identifying the OS standard format (absolute solution) when implementing a new currency.
/// Add targets to Infrastructure/FormattingDiscoverySource.cs and execute.
/// </summary>
public class FormattingDiscoveryTest
{
    /// <summary>Discovers and outputs the OS standard currency format for a given culture and currency.</summary>
    /// <param name="cultureName">Target culture name.</param>
    /// <param name="currencyCode">Target currency ISO code.</param>
    [Theory]
    [MemberData(nameof(FormattingDiscoverySource.GetDiscoveryData), MemberType = typeof(FormattingDiscoverySource))]
    public void DiscoverFormats(string cultureName, string currencyCode)
    {
        try
        {
            var culture = new CultureInfo(cultureName);
            var amount = 1234567.89m;
            // Avoid large diff output from Shouldly and display results concisely.
            throw new Exception($"RESULT [{currencyCode}]: {amount.ToString("C", culture)}");
        }
        catch (CultureNotFoundException)
        {
            // When the locale is not supported by the OS.
            throw new Exception($"RESULT: CULTURE_NOT_SUPPORTED");
        }
        catch (Exception ex) when (!ex.Message.StartsWith("RESULT:"))
        {
            throw new Exception($"RESULT: ERROR: {ex.Message}");
        }
    }
}
#endif
