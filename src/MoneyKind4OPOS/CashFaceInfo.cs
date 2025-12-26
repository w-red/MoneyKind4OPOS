using MoneyKind4Opos;

namespace MoneyKind4Opos;

/// <summary>Cash face information</summary>
/// <param name="Value">Face value</param>
/// <param name="Type">Face type</param>
/// <param name="Name">Face name</param>
public record CashFaceInfo(
    decimal Value,
    CashType Type,
    string? Name = null
);
