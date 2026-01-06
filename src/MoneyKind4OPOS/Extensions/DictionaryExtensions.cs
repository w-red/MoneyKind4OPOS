namespace MoneyKind4OPOS.Extensions;

/// <summary>IDictionary extensions.</summary>
public static class DictionaryExtensions
{
    extension<TKey, TValue>(IDictionary<TKey, TValue> dict)
    {
        /// <summary>IDictionary extends <see cref="Dictionary.GetValueOrDefault"/>.</summary>
        public TValue GetValueOrDefault(
            TKey key,
            TValue defaultValue = default!)
        {
            return dict.TryGetValue(key, out var value) 
                ? value : defaultValue;
        }
    }
}
