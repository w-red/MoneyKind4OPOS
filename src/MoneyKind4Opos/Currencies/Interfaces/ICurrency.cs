using MoneyKind4Opos.Codes;

namespace MoneyKind4Opos.Currencies.Interfaces;

/// <summary>Core Interface of Currency</summary>
public interface ICurrency
{
    /// <summary>Currency code.</summary>
    static abstract Iso4217 Code { get; }

    /// <summary>Minimum unit.</summary>
    static abstract decimal MinimumUnit { get; }

    /// <summary>Subsidiary units.</summary>
    static abstract IEnumerable<ISubsidiaryUnit> SubsidiaryUnits { get; }

    /// <summary>Generates a default format string based on a decimal scale.</summary>
    /// <param name="unit">The minimum unit value.</param>
    /// <param name="isZeroPadding">If true, use '0' for padding instead of '#'.</param>
    /// <returns>A format string like "0", "0.00" or "#", "#.##".</returns>
    public static string GetDefaultFormat(
        decimal unit,
        bool isZeroPadding = false)
    {
        var fill = isZeroPadding ? '0' : '#';

        return unit.Scale switch
        {
            <= 0 => $"{fill}",
            var s => $"{fill}." + new string(fill, s)
        };
    }
}
