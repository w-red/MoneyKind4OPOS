namespace MoneyKind4Opos.Extensions;

/// <summary>IDictionary extensions.</summary>
public static class DictionaryExtensions
{
    /// <summary>Extends IDictionary with C# 14 extension types.</summary>
    /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
    /// <param name="dict">The dictionary to extend.</param>
    extension<TKey, TValue>(IDictionary<TKey, TValue> dict)
    {
        /// <summary>IDictionary extends <see cref="Dictionary{TKey, TValue}.GetValueOrDefault(TKey, TValue)"/>.</summary>
        /// <param name="key">The key to locate.</param>
        /// <param name="defaultValue">The default value to return if the key is not found.</param>
        /// <returns>The value associated with the key, or defaultValue if no such key exists.</returns>
        public TValue GetValueOrDefault(
            TKey key,
            TValue defaultValue = default!)
        {
            return dict.TryGetValue(key, out var value)
                ? value : defaultValue;
        }
    }
}
