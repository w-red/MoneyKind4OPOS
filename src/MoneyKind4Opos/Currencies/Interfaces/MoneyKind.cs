using MoneyKind4Opos.Extensions;

namespace MoneyKind4Opos.Currencies.Interfaces;

/// <summary>MoneyKind implementation.</summary>
/// <typeparam name="TCurrency">Currency type</typeparam>
public class MoneyKind<TCurrency>
    : IMoneyKind<TCurrency, MoneyKind<TCurrency>>
    where TCurrency : 
        ICurrency, 
        ICashCountFormattable<TCurrency>,
        ICurrencyFormattable<TCurrency>
{
    /// <summary>default string format used for displaying coin values.</summary>
    private static readonly string _defaultCoinFormat =
        ICurrency
        .GetDefaultFormat(
            TCurrency.MinimumUnit,
            TCurrency.IsZeroPadding);

    /// <summary>default string format used for displaying bill values.</summary>
    private static readonly string _defaultBillFormat = _defaultCoinFormat;

    /// <summary>Lookup for coin faces by value.</summary>
    private static readonly Dictionary<decimal, CashFaceInfo> _coinFaceLookup =
        TCurrency
        .Coins
        .GroupBy(f => f.Value)
        .ToDictionary(
            g => g.Key,
            g => g.OrderBy(f => f.Type).First());

    /// <summary>Lookup for bill faces by value.</summary>
    private static readonly Dictionary<decimal, CashFaceInfo> _billFaceLookup =
        TCurrency
        .Bills
        .GroupBy(f => f.Value)
        .ToDictionary(
            g => g.Key,
            g => g.OrderBy(f => f.Type).First());

    /// <summary>Lookup for money faces by value.</summary>
    private static readonly Dictionary<(decimal faceValue, CashType Type), CashFaceInfo> _faceLookup =
        TCurrency
        .Coins.Concat(TCurrency.Bills)
        .GroupBy(f => (Value: f.Value, f.Type))
        .ToDictionary(
            g => g.Key,
            g => g.First());

    /// <summary>Lookup for money faces by value (auto type).</summary>
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
        get => 
            GetCount(
                _autoFaceLookup
                .GetValueOrDefault(faceValue));
        set => 
            SetCount(
                _autoFaceLookup
                .GetValueOrDefault(faceValue), value);
    }

    /// <inheritdoc/>
    public int this[decimal faceValue, CashType type]
    {
        get => GetCount(
            _faceLookup
            .GetValueOrDefault((faceValue, type)));
        set => SetCount(
            _faceLookup
            .GetValueOrDefault((faceValue, type)), value);
    }

    /// <summary>Gets the count for a specific cash face safely.</summary>
    private int GetCount(CashFaceInfo? face) =>
        face is { } f ? Counts.GetValueOrDefault(f, 0) : 0;

    /// <summary>Sets the count for a specific cash face safely.</summary>
    private void SetCount(CashFaceInfo? face, int value)
    {
        if (face is { } f) Counts[f] = value;
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
        if (cashCounts.Split(';') is [var coinsec, var billsec, ..])
        {
            ParseSection(
                coinsec,
                _coinFaceLookup,
                ret.Counts);
            ParseSection(
                billsec,
                _billFaceLookup,
                ret.Counts);
        }
        else if (cashCounts.Split(';') is [var coins])
        {
            ParseSection(
                coins,
                _coinFaceLookup,
                ret.Counts);
        }

        return ret;
    }

    /// <inheritdoc/>
    public decimal TotalAmount() =>
        Counts
        .Sum(kvp => kvp.Key.Value * kvp.Value);

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
        IReadOnlyDictionary<decimal, CashFaceInfo> faceLookup,
        IDictionary<CashFaceInfo, int> counts)
    {
        var query = sec
            .Split(',',
                StringSplitOptions.RemoveEmptyEntries
                | StringSplitOptions.TrimEntries)
            .Select(s => s.Split(':'))
            .Select(parts =>
                parts is [var vs, var cs]
                && decimal.TryParse(vs, out var v)
                && int.TryParse(cs, out var c)
                ? (IsSucess: true, Value: v, Count: c)
                : (IsSucess: false, Value: 0m, Count: 0))
            .Select(svc =>
                svc.IsSucess
                && faceLookup.TryGetValue(svc.Value, out var face)
                ? (Face: face, svc.Count)
                : (Face: null, Count: 0))
            .Where(w => w.Face is not null)
            .Select(s => (Face: s.Face!, s.Count));

        foreach (var (face, count) in query)
        {
            counts[face] = count;
        }
    }
}
