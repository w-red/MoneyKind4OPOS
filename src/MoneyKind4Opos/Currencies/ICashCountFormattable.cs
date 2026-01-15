using MoneyKind4Opos.Extensions;

namespace MoneyKind4Opos.Currencies;

/// <summary>Defines capabilities for CashCount string formatting (for OPOS/UPOS devices).</summary>
public interface ICashCountFormattable<TSelf> : ICurrency
    where TSelf : ICashCountFormattable<TSelf>
{
    /// <summary>Coin faces.</summary>
    static abstract IEnumerable<CashFaceInfo> Coins { get; }
    /// <summary>Bill faces.</summary>
    static abstract IEnumerable<CashFaceInfo> Bills { get; }

    /// <summary>Formats cash counts into a string.</summary>
    /// <param name="counts">The cash counts.</param>
    /// <returns>The formatted cash counts string.</returns>
    public static virtual string ToCashCountsString(
        IDictionary<CashFaceInfo, int> counts,
        string? coinFormat = null,
        string? billFormat = null)
    {
        var coinParts =
            string.Join(
                ",",
                TSelf
                .Coins
                .Select(
                    f => $"{f.Value.ToString(coinFormat)}:{counts.GetValueOrDefault(f, 0)}"));
        var billParts =
            string.Join(
                ",",
                TSelf
                .Bills
                .Select(
                    f => $"{f.Value.ToString(billFormat)}:{counts.GetValueOrDefault(f, 0)}"));

        return $"{coinParts};{billParts}";
    }
}
