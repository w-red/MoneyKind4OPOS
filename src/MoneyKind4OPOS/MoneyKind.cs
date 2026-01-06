using MoneyKind4Opos;

namespace MoneyKind4OPOS;

/// <summary>MoneyKind implementation.</summary>
public class MoneyKind<TCurrency>
    : IMoneyKind<TCurrency, MoneyKind<TCurrency>>
    where TCurrency : ICurrency
{
    /// <inheritdoc/>
    public IDictionary<CashFaceInfo, int> Counts { get; } = new Dictionary<CashFaceInfo, int>();

    /// <summary>Initializes a new instance of the <see cref="MoneyKind{TCurrency}"/> class.</summary>
    public MoneyKind()
    {
    }
}
