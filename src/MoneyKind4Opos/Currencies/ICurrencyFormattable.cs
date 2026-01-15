using System.Globalization;

namespace MoneyKind4Opos.Currencies;

/// <summary>Interface of Currency Formattable, for display.</summary>
public interface ICurrencyFormattable<TSelf> : ICurrency
    where TSelf : ICurrencyFormattable<TSelf>
{
    /// <summary>Currency symbol (e.g. "$", "¥").</summary>
    static abstract string Symbol { get; }

    /// <summary>Display format for currency values.</summary>
    static abstract CurrencyDisplayFormat DisplayFormat { get; }

    /// <summary>Cached NumberFormatInfo.</summary>
    static abstract NumberFormatInfo NumberFormat { get; }

    /// <summary>Whether to use zero padding for fractional parts.</summary>
    static abstract bool IsZeroPadding { get; }

    /// <summary>Convert to currency string with optional format.</summary>
    /// <param name="amount">Amount.</param>
    /// <param name="format">Format.</param>
    public static virtual string ToCurrencyString(decimal amount)
    {
        // at first, use standard currency format
        var formatted = amount.ToString("C", TSelf.NumberFormat);

        if (amount % 1 == 0 &&
            !string.IsNullOrEmpty(TSelf.DisplayFormat.DecimalZeroReplacement))
        {
            var digits = TSelf.NumberFormat.CurrencyDecimalDigits;
            var zeroPart =
                0
                .ToString($"F{digits}", TSelf.NumberFormat)[1..];

            formatted = formatted.Replace(
                zeroPart,
                $"{TSelf.DisplayFormat.DecimalSeparator}{TSelf.DisplayFormat.DecimalZeroReplacement}");
        }
        return formatted;
    }
}
