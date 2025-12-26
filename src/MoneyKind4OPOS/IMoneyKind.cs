namespace MoneyKind4Opos;

/// <summary>Interface of MoneyKind</summary>
public interface IMoneyKind
{
    /// <summary>Cash face and count.</summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><description>Key: Face<see cref="CashFaceInfo"/></description></item>
    /// <item><description>Value: Count</description></item></list>
    /// </remarks>
    public IDictionary<CashFaceInfo, int> Counts { get; }
}
