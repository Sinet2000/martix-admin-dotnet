using System.Diagnostics.CodeAnalysis;

namespace Dexlaris.Core.Common.Extensions
{
    public static class IntExt
    {
        /// <summary>
        /// Is not null and greater than zero.
        /// </summary>
        public static bool HasValue([NotNullWhen(true)] this int? value)
        {
            return value is > 0;
        }

        /// <summary>
        /// Is greater than zero.
        /// </summary>
        public static bool HasValue(this int value)
        {
            return value > 0;
        }

        /// <summary>
        /// Formats the number as a string with leading zeros if the number is between 0 and 9.
        /// </summary>
        /// <param name="number">The number to format.</param>
        /// <returns>The formatted number as a string.</returns>
        public static string FormatNumberWithLeadingZeros(this int number)
        {
            return number is >= 0 and <= 9 ? number.ToString("D2") : number.ToString();
        }
    }
}