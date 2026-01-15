using MoneyKind4Opos.Currencies;

namespace MoneyKind4Opos;

/// <summary>Interface of MoneyKind</summary>
/// <typeparam name="TCurrency">Currency type</typeparam>
/// <typeparam name="TSelf">Self type</typeparam>
public interface IMoneyKind<TCurrency, TSelf>
    where TCurrency : ICurrency, ICashCountFormattable<TCurrency>
    where TSelf : IMoneyKind<TCurrency, TSelf>, new()
{
    /// <summary>Cash face and count.</summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><description>Key: Face, <see cref="CashFaceInfo"/></description></item>
    /// <item><description>Value: Count</description></item></list>
    /// </remarks>
    IDictionary<CashFaceInfo, int> Counts { get; }

    /// <summary>Access count by face value (auto-detect type).</summary>
    /// <param name="faceValue">Face value</param>
    /// <returns>Count</returns>
    int this[decimal faceValue] { get; set; }

    /// <summary>Access count by face value and type.</summary>
    /// <param name="faceValue">Face value</param>
    /// <param name="type">Cash type</param>
    /// <returns>Count</returns>
    int this[decimal faceValue, CashType type] { get; set; }

    /// <summary>Convert to cash counts string with optional formats.</summary>
    /// <param name="coinFormat">Format for coin faces. If null, uses TCurrency.DefaultFormat.</param>
    /// <param name="billFormat">Format for bill faces. If null, uses "#".</param>
    /// <returns>Cash counts string</returns>
    string ToCashCountsString(string? coinFormat = null, string? billFormat = null) =>
        TCurrency.ToCashCountsString(Counts, coinFormat, billFormat);

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
