namespace MoneyKind4Opos.Currencies;

/// <summary>Currency display format.</summary>
/// <param name="Placement">Symbol placement.</param>
/// <param name="HasSpace">format has space?</param>
/// <param name="DecimalZeroReplacement">Decimal zero replacement.
/// ex.:
/// <list type="bullet">
/// <item><term>null</term><description>no replacement, e.g. "123.00"</description></item>
/// <item><term>""</term><description>remove decimal part if zero, e.g. "123"</description></item>
/// <item><term>"--"</term><description>replace decimal part with "--", e.g. "123,--"</description></item>
/// <item><term>"00"</term><description>replace decimal part with "00", e.g. "123.00"</description></item>
/// </list>
/// </param>
/// <param name="GroupSeparator">Group separator.</param>
/// <param name="DecimalSeparator">Decimal separator.</param>
public record CurrencyDisplayFormat(
    SymbolPlacement Placement,
    bool HasSpace = false,
    string? DecimalZeroReplacement = null,
    string GroupSeparator = ",",
    string DecimalSeparator = "."
);
