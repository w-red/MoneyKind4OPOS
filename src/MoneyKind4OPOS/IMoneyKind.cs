namespace MoneyKind4Opos;

/// <summary>Interface of MoneyKind</summary>
/// <typeparam name="TCurrency">Currency type</typeparam>
/// <typeparam name="TSelf">Self type</typeparam>
public interface IMoneyKind<TCurrency, TSelf>
    where TCurrency : ICurrency
    where TSelf : IMoneyKind<TCurrency, TSelf>, new()
{
    /// <summary>Cash face and count.</summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><description>Key: Face, <see cref="CashFaceInfo"/></description></item>
    /// <item><description>Value: Count</description></item></list>
    /// </remarks>
    IDictionary<CashFaceInfo, int> Counts { get; }

    /// <summary>Convert to cash counts string.</summary>
    /// <returns>Cash counts string</returns>
    string ToCashCountsString();

    /// <summary>Parse.</summary>
    /// <param name="cashCounts">Cash counts string</param>
    /// <returns>parse result</returns>
    static abstract TSelf Parse(string cashCounts);

    /// <summary>Total amount.</summary>
    /// <returns>Total amount</returns>
    decimal TotalAmount();

    /// <summary>Coin amount.</summary>
    /// <returns>Coin amount</returns>
    decimal CoinAmount();

    /// <summary>Bill amount.</summary>
    /// <returns>Bill amount</returns>
    decimal BillAmount();
}
