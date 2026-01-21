using MoneyKind4Opos.Currencies.Interfaces;

namespace MoneyKind4Opos.Extensions;

/// <summary>Extension methods for currency formatting.</summary>
public static class CurrencyExtensions
{
    extension(decimal amount)
    {
        /// <summary>To local string. (e.g. TCurrency:CNY "1角2分")</summary>
        public string ToLocalString<TCurrency>()
            where TCurrency : ICurrencyFormattable<TCurrency>
        {
            return TCurrency.ToLocalString(amount);
        }

        /// <summary>To local string. (e.g. TCurrency:CNY "¥15.33")</summary>
        public string ToGlobalString<TCurrency>()
            where TCurrency : ICurrencyFormattable<TCurrency>
        {
            return TCurrency.ToGlobalString(amount);
        }

        /// <summary>To Currency string. using specified currency type.</summary>
        public string ToCurrencyString<TCurrency>()
            where TCurrency : ICurrencyFormattable<TCurrency>
        {
            return TCurrency.ToCurrencyString(amount);
        }
    }

}
