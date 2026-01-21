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
    public static virtual string ToGlobalString(decimal amount) =>
        TSelf.Global.Format(amount);

    /// <summary>Converts to a local customary currency string.</summary>
    public static virtual string ToLocalString(decimal amount) =>
        TSelf.Local.Format(amount);

    /// <summary>Standard alias for conversion.</summary>
    public static virtual string ToCurrencyString(decimal amount) =>
        TSelf.ToLocalString(amount);
}
