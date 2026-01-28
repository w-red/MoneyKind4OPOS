using MoneyKind4Opos.Extensions;

namespace MoneyKind4Opos.Currencies.Interfaces;

/// <summary>MoneyKind implementation.</summary>
/// <typeparam name="TCurrency">Currency type</typeparam>
public class MoneyKind<TCurrency>
    : IMoneyKind<TCurrency, MoneyKind<TCurrency>>,
        ICashCountValidatable<TCurrency>
    where TCurrency :
        ICurrency,
        ICashCountFormattable<TCurrency>,
        ICurrencyFormattable<TCurrency>
{
    /// <summary>default string format used for displaying coin values.</summary>
    protected static readonly string _defaultCoinFormat =
        ICurrency
        .GetDefaultFormat(
            TCurrency.MinimumUnit,
            TCurrency.IsZeroPadding);

    /// <summary>default string format used for displaying bill values.</summary>
    protected static readonly string _defaultBillFormat = _defaultCoinFormat;

    /// <summary>Lookup for coin faces by value.</summary>
    protected static readonly Dictionary<decimal, CashFaceInfo> _coinFaceLookup =
        TCurrency
        .Coins
        .GroupBy(f => f.Value)
        .ToDictionary(
            g => g.Key,
            g => g.OrderBy(f => f.Type).First());

    /// <summary>Lookup for bill faces by value.</summary>
    protected static readonly Dictionary<decimal, CashFaceInfo> _billFaceLookup =
        TCurrency
        .Bills
        .GroupBy(f => f.Value)
        .ToDictionary(
            g => g.Key,
            g => g.OrderBy(f => f.Type).First());

    /// <summary>Lookup for money faces by value.</summary>
    protected static readonly Dictionary<(decimal faceValue, CashType Type), CashFaceInfo> _faceLookup =
        TCurrency
        .Coins.Concat(TCurrency.Bills)
        .GroupBy(f => (f.Value, f.Type))
        .ToDictionary(
            g => g.Key,
            g => g.First());

    /// <summary>Lookup for money faces by value (auto type).</summary>
    protected static readonly Dictionary<decimal, CashFaceInfo> _autoFaceLookup =
        TCurrency.Coins.Concat(TCurrency.Bills)
        .GroupBy(f => f.Value)
        .ToDictionary(
            g => g.Key,
            g => g.OrderBy(f => f.Type).First());

    /// <inheritdoc/>
    public IDictionary<CashFaceInfo, int> Counts { get; } =
        new Dictionary<CashFaceInfo, int>();

    /// <summary>Initializes a new instance of the <see cref="MoneyKind{TCurrency}"/> class.</summary>
    public MoneyKind()
    {
        // Initialize all supported denominations with 0 counts.
        // This supports direct indexer access (e.g., Counts[face] += value)
        // without KeyNotFoundException.
        foreach (var face in TCurrency.Bills.Concat(TCurrency.Coins))
        {
            Counts[face] = 0;
        }
    }

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
    protected int GetCount(CashFaceInfo? face) =>
        face is { } f ?
        Counts.GetValueOrDefault(f, 0) : 0;

    /// <summary>Sets the count for a specific cash face safely.</summary>
    protected void SetCount(CashFaceInfo? face, int value)
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
        var sections = cashCounts.Split(';');

        switch (sections)
        {
        case [var coinSec, var billSec, ..]:
            ParseSection(
                coinSec,
                _coinFaceLookup,
                ret.Counts);
            ParseSection(
                billSec,
                _billFaceLookup,
                ret.Counts);
            break;
        case [var coinSec]:
            ParseSection(
                coinSec,
                _coinFaceLookup,
                ret.Counts);
            break;
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

    /// <summary>All faces in descending order for greedy algorithm.</summary>
    protected static readonly IReadOnlyList<CashFaceInfo> _allDescendingFaces =
        [.. TCurrency.Bills.Concat(TCurrency.Coins)
        .Where(f => f.Value > 0)
        .OrderByDescending(f => f.Value)
        .ThenByDescending(f => f.Type)];

    /// <inheritdoc/>
    public void Add(MoneyKind<TCurrency> other)
    {
        var filtered = other.Counts
            .Where(kv => kv.Value != 0);
        foreach (var kvp in filtered)
        {
            Counts[kvp.Key] +=
                kvp.Value;
        }
    }

    /// <inheritdoc/>
    public void Subtract(MoneyKind<TCurrency> other)
    {
        var filtered = other.Counts
            .Where(kv => kv.Value != 0);
        foreach (var kvp in filtered)
        {
            var current = Counts[kvp.Key];
            if (current < kvp.Value)
            {
                throw new InvalidOperationException(
                    $"Insufficient inventory for {kvp.Key.Value} ({kvp.Key.Type}). " +
                    $"Current: {current}, Required: {kvp.Value}");
            }
            Counts[kvp.Key] -= kvp.Value;
        }
    }

    /// <inheritdoc/>
    public bool IsPayable(decimal amount)
    {
        return CalculateChangeDetail(amount).IsSucceed;
    }

    /// <inheritdoc/>
    public MoneyKind<TCurrency> CalculateChange(decimal amount)
    {
        return CalculateChangeDetail(amount).PayableChange;
    }

    /// <inheritdoc/>
    public ChangeCalculationResult<TCurrency, MoneyKind<TCurrency>>
        CalculateChangeDetail(decimal amount)
    {
        // Pass 1: Calculate what can be paid given the current inventory
        var payable =
            Calculate(amount, useInventory: true);
        var remaining =
            amount - payable.TotalAmount();

        // Pass 2: Calculate the ideal breakdown for the remaining (missing) amount
        var missing =
            Calculate(remaining, useInventory: false);

        return new ChangeCalculationResult<TCurrency, MoneyKind<TCurrency>>
        {
            PayableChange = payable,
            RemainingAmount = remaining,
            MissingChange = missing
        };
    }

    /// <summary>Calculates a denominations breakdown for a given amount.</summary>
    /// <param name="amount">Amount to calculate</param>
    /// <param name="useInventory"><list type="bullet">
    /// <item><term>true</term>uses current inventory to limit available denominations.</item>
    /// <item><term>false</term>assumes infinite stock.</item>
    /// </list></param>
    protected MoneyKind<TCurrency> Calculate(decimal amount, bool useInventory)
    {
        var ret = new MoneyKind<TCurrency>();
        var remaining = amount;

        if (remaining <= 0)
        {
            return ret;
        }

        foreach (var face in _allDescendingFaces)
        {
            var neededCount = (int)(remaining / face.Value);
            if (neededCount > 0)
            {
                var availableCount =
                    useInventory ?
                    Counts[face] : int.MaxValue;
                var takableCount =
                    Math.Min(neededCount, availableCount);

                if (takableCount > 0)
                {
                    ret.Counts[face] = takableCount;
                    remaining -= face.Value * takableCount;
                }
            }
        }
        return ret;
    }

    /// <summary>Parse face section.</summary>
    protected static void ParseSection(
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

    /// <inheritdoc/>
    public bool IsValidFaceValue(decimal faceValue) =>
        _autoFaceLookup.ContainsKey(faceValue);
    /// <inheritdoc/>
    public bool IsValidCount(int count) =>
        count >= 0;

    /// <inheritdoc/>
    public bool TrySetCashCount(
        decimal faceValue,
        int count,
        out string? error)
    {
        // Validate count
        if (!IsValidCount(count))
        {
            error = $"Count {count} must be greater than or equal to 0.";
            return false;
        }

        // Validate and retrieve face value with auto type detection
        var face = _autoFaceLookup.GetValueOrDefault(faceValue);
        if (face is null)
        {
            error = $"Face value {faceValue} is not a valid denomination for {TCurrency.Code}.";
            return false;
        }

        // Set the count
        Counts[face] = count;
        error = null;
        return true;
    }

    /// <inheritdoc/>
    public bool TrySetCashCount(
        decimal faceValue,
        CashType type,
        int count,
        out string? error)
    {
        // Validate count
        if (!IsValidCount(count))
        {
            error = $"Count {count} must be greater than or equal to 0.";
            return false;
        }

        // Validate and retrieve face value with specific type
        var face = _faceLookup.GetValueOrDefault((faceValue, type));
        if (face is null)
        {
            error = $"Face value {faceValue} of type {type} is not a valid denomination for {TCurrency.Code}.";
            return false;
        }

        // Set the count
        Counts[face] = count;
        error = null;
        return true;
    }

    /// <inheritdoc/>
    public bool TryValidateParse(string cashCounts, out List<string> warnings)
    {
        warnings = [];

        if (string.IsNullOrEmpty(cashCounts))
        {
            return true; // Empty string is valid (all zero counts)
        }

        var sections = cashCounts.Split(';');

        // Validate coin section if present
        if (sections.Length > 0 && !string.IsNullOrEmpty(sections[0]))
        {
            ValidateSection(sections[0], _coinFaceLookup, warnings);
        }

        // Validate bill section if present
        if (sections.Length > 1 && !string.IsNullOrEmpty(sections[1]))
        {
            ValidateSection(sections[1], _billFaceLookup, warnings);
        }

        return true; // Always returns true (warnings are collected, not errors)
    }

    /// <summary>Validates a section of the CashCounts string and collects warnings.</summary>
    protected static void ValidateSection(
        string section,
        Dictionary<decimal, CashFaceInfo> faceLookup,
        List<string> warnings)
    {
        foreach (var item in section.Split(','))
        {
            if (string.IsNullOrWhiteSpace(item))
                continue;

            var parts = item.Split(':');
            if (parts.Length != 2)
            {
                warnings.Add($"Invalid format for item '{item}'. Expected 'value:count'.");
                continue;
            }

            if (!decimal.TryParse(parts[0], out var faceValue))
            {
                warnings.Add($"Invalid face value '{parts[0]}' in item '{item}'.");
                continue;
            }

            if (!int.TryParse(parts[1], out var count))
            {
                warnings.Add($"Invalid count '{parts[1]}' in item '{item}'.");
                continue;
            }

            if (!faceLookup.ContainsKey(faceValue))
            {
                warnings.Add($"Face value {faceValue} is not a valid denomination for {TCurrency.Code}.");
            }

            if (count < 0)
            {
                warnings.Add($"Count {count} in item '{item}' must be greater than or equal to 0.");
            }
        }
    }
}
