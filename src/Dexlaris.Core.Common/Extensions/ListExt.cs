using System.Diagnostics.CodeAnalysis;

namespace Dexlaris.Core.Common.Extensions
{
    public static class ListExt
    {
        public static bool IsNullOrEmpty<T>([NotNullWhen(false)] this IList<T>? values)
        {
            return values is null || values.Count == 0;
        }

        public static bool IsNullOrEmpty<T>([NotNullWhen(false)] this IEnumerable<T>? values)
        {
            return values is null || !values.Any();
        }

        /// <summary>
        /// Is not null and has at least one item.
        /// </summary>
        public static bool HasValue<T>([NotNullWhen(true)] this IList<T>? values)
        {
            return values is not null && values.Count > 0;
        }

        /// <summary>
        /// Is not null and has at least one item.
        /// </summary>
        public static bool HasValue<T>([NotNullWhen(true)] this IEnumerable<T>? values)
        {
            return values is not null && values.Any();
        }
    }
}