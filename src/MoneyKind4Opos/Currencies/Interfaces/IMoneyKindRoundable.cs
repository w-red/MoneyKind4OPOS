namespace MoneyKind4Opos.Currencies.Interfaces;

/// <summary>Provides rounding capabilities for money amounts based on currency's minimum unit.</summary>
/// <typeparam name="TCurrency">The currency type.</typeparam>
/// <typeparam name="TSelf">The implementing type.</typeparam>
public interface IMoneyKindRoundable<TCurrency, TSelf>
    where TCurrency : ICurrency, ICashCountFormattable<TCurrency>
    where TSelf : IMoneyKindRoundable<TCurrency, TSelf>, new()
{
    /// <summary>Rounds the amount to the nearest multiple of the currency's minimum unit.</summary>
    /// <param name="amount">The amount to round.</param>
    /// <param name="rounding">The rounding mode to apply. Default is MidpointRounding.ToEven.</param>
    /// <returns>The rounded amount.</returns>
    /// <remarks>
    /// The rounding is performed by dividing the amount by MinimumUnit, rounding to the nearest integer,
    /// and then multiplying back by MinimumUnit.
    /// Example: For AUD with MinimumUnit=0.05, 99.99 rounds to 100.00 (default ToEven mode).
    /// </remarks>
    decimal RoundToMinimumUnit(
        decimal amount,
        MidpointRounding rounding = MidpointRounding.ToEven);

    /// <summary>Validates whether the amount is a valid multiple of the currency's minimum unit.</summary>
    /// <param name="amount">The amount to validate.</param>
    /// <returns>True if the amount is a valid multiple of the minimum unit; otherwise, false.</returns>
    /// <remarks>
    /// This method checks if the amount can be exactly expressed using the currency's denominations.
    /// Example: For AUD with MinimumUnit=0.05, 100.03 returns false (not a multiple of 0.05).
    /// </remarks>
    bool IsRoundedToMinimumUnit(decimal amount);
}
