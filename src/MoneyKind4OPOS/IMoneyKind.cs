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
            TCurrency.Coins
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
            ParseSection(
                sections[0],
                TCurrency.Coins,
                ret.Counts);
        }
        if (sections.Length > 1)
        {
            ParseSection(
                sections[1],
                TCurrency.Bills,
                ret.Counts);
        }

        return ret;
    }

    /// <summary>Parse face section.</summary>
    private static void ParseSection(
        string sec,
        IEnumerable<CashFaceInfo> faces,
        IDictionary<CashFaceInfo, int> counts)
    {
        foreach (var ent in sec
            .Split(',').Select(s => s.Split(':')))
        {
            if (ent.Length == 2 && 
                decimal.TryParse(ent[0], out var val))
            {
                if (int.TryParse(ent[1], out var cnt))
                {
                    // 利用可能な額面リストから一致するものを探す
                    var face = faces
                        .FirstOrDefault(f => f.Value == val);
                    if (face != null)
                    {
                        counts[face] = cnt;
                    }
                }
            }
        }
    }
}
