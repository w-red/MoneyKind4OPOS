using MoneyKind4Opos.Currencies;
using MoneyKind4Opos.Extensions;

namespace MoneyKind4Opos;

/// <summary>MoneyKind implementation.</summary>
/// <typeparam name="TCurrency">Currency type</typeparam>
public class MoneyKind<TCurrency>
    : IMoneyKind<TCurrency, MoneyKind<TCurrency>>
    where TCurrency : 
        ICurrency, 
        ICashCountFormattable<TCurrency>,
        ICurrencyFormattable<TCurrency>
{
    private static readonly string _defaultCoinFormat =
        ICurrency
        .GetDefaultFormat(TCurrency.MinimumUnit, TCurrency.IsZeroPadding);

    private static readonly string _defaultBillFormat =
        ICurrency
        .GetDefaultFormat(1m, TCurrency.IsZeroPadding);

    private static readonly Dictionary<(decimal faceValue, CashType Type), CashFaceInfo> _faceLookup =
        TCurrency.Coins.Concat(TCurrency.Bills)
        .ToDictionary(f => (f.Value, f.Type));

    private static readonly Dictionary<decimal, CashFaceInfo> _autoFaceLookup =
        TCurrency.Coins.Concat(TCurrency.Bills)
        .GroupBy(f => f.Value)
        .ToDictionary(
            g => g.Key,
            g => g.OrderBy(f => f.Type).First());

    /// <inheritdoc/>
    public IDictionary<CashFaceInfo, int> Counts { get; } =
        new Dictionary<CashFaceInfo, int>();

    /// <summary>Initializes a new instance of the <see cref="MoneyKind{TCurrency}"/> class.</summary>
    public MoneyKind() { }

    /// <inheritdoc/>
    public int this[decimal faceValue]
    {
        get => _autoFaceLookup.TryGetValue(faceValue, out var face) ? Counts.GetValueOrDefault(face, 0) : 0;
        set
        {
            if (_autoFaceLookup.TryGetValue(faceValue, out var face))
            {
                Counts[face] = value;
            }
        }
    }

    /// <inheritdoc/>
    public int this[decimal faceValue, CashType type]
    {
        get => _faceLookup.TryGetValue((faceValue, type), out var face) ? Counts.GetValueOrDefault(face, 0) : 0;
        set
        {
            if (_faceLookup.TryGetValue((faceValue, type), out var face))
            {
                Counts[face] = value;
            }
        }
    }

    /// <inheritdoc/>
    public string ToCashCountsString(
        string? coinFormat = null,
        string? billFormat = null) =>
        TCurrency.ToCashCountsString(
            Counts,
            coinFormat ?? _defaultCoinFormat,
            billFormat ?? _defaultBillFormat);

    /// <inheritdoc/>
    public static MoneyKind<TCurrency> Parse(string cashCounts)
    {
        var ret = new MoneyKind<TCurrency>();
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

    /// <inheritdoc/>
    public decimal TotalAmount() =>
        Counts.Sum(kvp => kvp.Key.Value * kvp.Value);

    /// <inheritdoc/>
    public decimal CoinAmount() =>
        Counts
        .Where(kvp => kvp.Key.Type == CashType.Coin)
        .Sum(kvp => kvp.Key.Value * kvp.Value);

    /// <inheritdoc/>
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
                    ? (Face: faces.FirstOrDefault(f => f.Value == v), Count: c)
                    : (Face: null, Count: 0)
            )
            .Where(t => t.Face is not null);

        foreach (var (face, count) in parsed)
        {
            counts[face!] = count;
        }
    }
}
