namespace MoneyKind4Opos.Currencies.Interfaces;

/// <summary>Result of change calculation.</summary>
public record ChangeCalculationResult<TCurrency, TSelf>
    where TCurrency : ICurrency, ICashCountFormattable<TCurrency>
    where TSelf : IMoneyKind<TCurrency, TSelf>, new()
{
    /// <summary>Is succeed or not.</summary>
    /// <remarks>(eq. RemainingAmount == 0)</remarks>
    public bool IsSucceed => RemainingAmount == 0;

    /// <summary>Partially paid change.</summary>
    public required TSelf PayableChange { get; init; }

    /// <summary>Remaining amount that could not be paid.</summary>
    public required decimal RemainingAmount { get; init; }

    /// <summary>Missing change and counts to complete the payment.</summary>
    public required TSelf MissingChange { get; init; }
}
