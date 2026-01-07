using MoneyKind4OPOS.Extensions;

namespace MoneyKind4Opos;

/// <summary>Interface of MoneyKind</summary>
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
    public IDictionary<CashFaceInfo, int> Counts { get; }

    /// <summary>Convert to cash counts string.</summary>
    public string ToCashCountsString()
    {
        var coinsPart =
            TCurrency.Coins
            .Select(
                f => $"{f.Value}:{Counts.GetValueOrDefault(f, 0)}");
        var billsPart =
            TCurrency.Bills
            .Select(
                f => $"{f.Value}:{Counts.GetValueOrDefault(f, 0)}");

        return $"{string.Join(",", coinsPart)};{string.Join(",", billsPart)}";
    }

    /// <summary>Parse.</summary>
    /// <param name="cashCounts">Cash counts string</param>
    /// <returns>parse result</returns>
    public static virtual TSelf Parse(string cashCounts)
    {
        var ret = new TSelf();
        var sections = cashCounts.Split(';');
        if (sections.Length > 0)
        {
            ParseSection(sections[0], TCurrency.Coins, ret.Counts);
        }
        if (sections.Length > 1)
        {
            ParseSection(sections[1], TCurrency.Bills, ret.Counts);
        }

        return ret;
    }

    /// <summary>Total amount.</summary>
    public decimal TotalAmount() =>
        Counts
        .Sum(kvp => kvp.Key.Value * kvp.Value);

    /// <summary>Coin amount.</summary>
    public decimal CoinAmount() =>
        Counts
        .Where(kvp => kvp.Key.Type == CashType.Coin)
        .Sum(kvp => kvp.Key.Value * kvp.Value);

    /// <summary>Bill amount.</summary>
    public decimal BillAmount() =>
        Counts
        .Where(kvp => kvp.Key.Type == CashType.Bill)
        .Sum(kvp => kvp.Key.Value * kvp.Value);

    /// <summary>Parse face section.</summary>
    private static void ParseSection(
        string sec,
        IEnumerable<CashFaceInfo> faces,
        IDictionary<CashFaceInfo, int> counts)
    {
        var parsed =
            sec
            .Split(',',
                StringSplitOptions.RemoveEmptyEntries
                | StringSplitOptions.TrimEntries)
            .Select(s => s.Split(':'))
            .Select(
                p =>
                    p is [var vs, var cs]
                    && decimal.TryParse(vs, out var v)
                    && int.TryParse(cs, out var c)
                    ? (Face:
                        faces.FirstOrDefault(f => f.Value == v),
                        Count: c)
                    : (Face: null, Count: 0)
            )
            .Where(t => t.Face is not null);

        foreach (var (face, count) in parsed)
        {
            counts[face!] = count;
        }
    }
}
