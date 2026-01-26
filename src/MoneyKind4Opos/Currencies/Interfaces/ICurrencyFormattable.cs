using System.Globalization;

namespace MoneyKind4Opos.Currencies.Interfaces;

/// <summary>Interface for objects that can be formatted as currency using Global and Local options.</summary>
/// <typeparam name="TSelf">The implementing type to allow static access.</typeparam>
public interface ICurrencyFormattable<TSelf> : ICurrency
    where TSelf : ICurrencyFormattable<TSelf>
{
    /// <summary>Global (Standard/International) formatting options.</summary>
    static abstract CurrencyFormattingOptions Global { get; }

    /// <summary>Local (Regional/Customary) formatting options.</summary>
    static abstract CurrencyFormattingOptions Local { get; }

    /// <summary>Whether to use zero padding for fractional parts (used by MoneyKind).</summary>
    static abstract bool IsZeroPadding { get; }

    /// <summary>Converts to a standard international currency string.</summary>
    public static virtual string ToGlobalString(decimal amount, CultureInfo? culture = null) =>
        TSelf.Global.Format(amount, culture);

    /// <summary>Converts to a local customary currency string.</summary>
    public static virtual string ToLocalString(decimal amount, CultureInfo? culture = null) =>
        TSelf.Local.Format(amount, culture);

    /// <summary>Standard currency alias for conversion.</summary>
    public static virtual string ToCurrencyString(decimal amount, CultureInfo? culture = null) =>
        TSelf.ToLocalString(amount, culture);
}
