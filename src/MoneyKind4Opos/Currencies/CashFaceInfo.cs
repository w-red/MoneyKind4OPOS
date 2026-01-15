namespace MoneyKind4Opos.Currencies;

/// <summary>Cash face information.</summary>
/// <param name="Value">Face value.</param>
/// <param name="Type">Face type.</param>
/// <param name="Name">Global face name.</param>
/// <param name="LocalName">Local face name.</param>
public record CashFaceInfo(
    decimal Value,
    CashType Type,
    string? Name = null,
    string? LocalName = null)
{
    /// <summary>Local face name. Falls back to <see cref="Name"/> if not specified.</summary>
    public string? LocalName { get; init; } =
        LocalName ?? Name;
}
