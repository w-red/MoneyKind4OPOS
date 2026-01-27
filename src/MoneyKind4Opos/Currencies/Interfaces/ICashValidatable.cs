namespace MoneyKind4Opos.Currencies.Interfaces;

/// <summary>
/// Provides cash count validation capabilities for a specific currency.
/// This interface enables validation of denominations and counts for OPOS/UPOS devices.
/// </summary>
/// <typeparam name="TCurrency">The currency type to validate.</typeparam>
public interface ICashCountValidatable<TCurrency>
    where TCurrency :
        ICurrency,
        ICashCountFormattable<TCurrency>
{
    /// <summary>Validates whether the specified face value is a valid denomination for the currency.</summary>
    /// <param name="faceValue">The face value to validate.</param>
    /// <returns>Is the face Valid?</returns>
    bool IsValidFaceValue(decimal faceValue);

    /// <summary>Validates whether the specified count is valid (non-negative integer).</summary>
    /// <param name="count">The count to validate.</param>
    /// <returns>Is the count valid?</returns>
    /// <remarks>
    /// Counts must always be non-negative because they represent physical quantities.
    /// <see cref="Subtract"/> method prevents counts from becoming negative by throwing an exception
    /// if insufficient inventory is available.
    /// </remarks>
    bool IsValidCount(int count);

    /// <summary>Attempts to set the count for a specific face value with auto-detected cash type.</summary>
    /// <param name="faceValue">The face value.</param>
    /// <param name="count">The count to set.</param>
    /// <param name="error">The error message if validation fails; otherwise, null.</param>
    /// <returns>Is succeed?</returns>
    bool TrySetCashCount(decimal faceValue, int count, out string? error);

    /// <summary>Attempts to set the count for a specific face value and cash type.</summary>
    /// <param name="faceValue">The face value.</param>
    /// <param name="type">The cash type (Coin or Bill).</param>
    /// <param name="count">The count to set.</param>
    /// <param name="error">The error message if validation fails; otherwise, null.</param>
    /// <returns>Is succeed?</returns>
    bool TrySetCashCount(decimal faceValue, CashType type, int count, out string? error);

    /// <summary>
    /// Validates a CashCounts string for parsing and collects warnings.
    /// Invalid denominations are skipped (not treated as errors).
    /// </summary>
    /// <param name="cashCounts">The CashCounts string to validate.</param>
    /// <param name="warnings">A collection of warning messages encountered during validation.</param>
    /// <returns>Always returns true (validation collects warnings, not errors).</returns>
    bool TryValidateParse(string cashCounts, out List<string> warnings);
}
