using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Data.Structure
{
    public static class Extensions
    {
        /// <summary>
        /// Get the string slice between the two indexes.
        /// Inclusive for start index, exclusive for end index.
        /// </summary>
        public static string Slice(this string source, int start, int end)
        {
            if (end < 0) // Keep this for negative end support
            {
                end = source.Length + end;
            }

            int len = end - start; // Calculate length
            return source.Substring(start, len); // Return Substring of length
        }

        public static Func<T1, T3> Compose<T1, T2, T3>(this Func<T1, T2> f, Func<T2, T3> g)
        {
            return (x) => g(f(x));
        }


        public static IEnumerable<char> Join(this IEnumerable<char> str) => string.Join(string.Empty, str);
        public static IEnumerable<char> Join(this IEnumerable<char> str, string join) => string.Join(join, str);

        public static string Join(this IEnumerable<string> str, string join) => string.Join(@join, str);

        public static string Join(this string str) => string.Join(string.Empty, str);
        public static bool IsNullOrEmpty(this string? str) => string.IsNullOrEmpty(str);
        public static bool IsNullOrWhiteSpace(this string? str) => string.IsNullOrWhiteSpace(str);
        public static bool ContainsIgnoreCase(this string? str, string val) => str?.Contains(val, StringComparison.OrdinalIgnoreCase) == true;

        public static string ReplaceMultipleWhiteSpacesWithOne(this string? str)
        {
            const RegexOptions options = RegexOptions.None;
            var regex = new Regex("[ ]{2,}", options);
            return regex.Replace(str.Trim(), " ");
        }

        public static Action<T> AndThen<T>(this Action<T> first, Action<T> next)
        {
            return e =>
            {
                first(e);
                next(e);
            };
        }
    }
}