using System.Diagnostics.CodeAnalysis;
using System.Security;

namespace Dexlaris.Core.Common.Extensions
{
    public static class StringExt
    {
        /// <summary>
        /// Tries to convert the specified string to boolean.
        /// </summary>
        /// <param name="value">Nullable string that represents the boolean value.</param>
        /// <param name="defaultValue">The default value to return if conversion was not usccessfull.</param>
        public static bool ToBoolSafe(this string? value, bool defaultValue = false)
        {
            return bool.TryParse(value, out bool result) ? result : defaultValue;
        }

        public static bool ToBool(this string value)
        {
            return bool.Parse(value);
        }

        /// <summary>
        /// Is not null and not whitespace.
        /// </summary>
        public static bool HasValue([NotNullWhen(true)] this string? value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Is null or whitespace.
        /// </summary>
        public static bool IsNullOrEmpty([NotNullWhen(false)] this string? value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static string ToFirstCharLower(this string? value)
        {
            if (!string.IsNullOrEmpty(value) && char.IsUpper(value[0]))
            {
                return value.Length == 1 ? char.ToLower(value[0]).ToString() : char.ToLower(value[0]) + value[1..];
            }

            return value ?? string.Empty;
        }

        public static string? ToFirstCharUpper(this string? value)
        {
            if (!string.IsNullOrEmpty(value) && char.IsLower(value[0]))
            {
                return value.Length == 1 ? char.ToUpper(value[0]).ToString() : char.ToUpper(value[0]) + value[1..];
            }

            return value ?? string.Empty;
        }


        /// <summary>
        /// Encodes the deprected chars that can't be allowed in Sieve search filter.
        /// </summary>
        public static string ToSieveFilterValue(this string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }

            return value.Replace(",", @"\,");
        }

        public static string TrimToLength(this string value, int length)
        {
            value = value.Trim();

            return value.Length > length ? value[..length].Trim() : value.Trim();
        }

        public static string TruncateWithDots(this string input, int maxLength = 20)
        {
            return input.Length <= maxLength
                ? input
                : // No need to truncate, return the original string
                string.Concat(input.AsSpan(0, maxLength), "...");
        }

        /// <summary>
        /// Pads a numeric string with leading zeros to meet the specified minimum length.
        /// </summary>
        /// <param name="numberString">The numeric string to pad.</param>
        /// <param name="minLength">The minimum length the resulting string should have.</param>
        /// <returns>A string representing the padded numeric value.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="numberString"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="numberString"/> is not a valid number.</exception>
        public static string PadNumber(this string numberString, int minLength)
        {
            ArgumentNullException.ThrowIfNull(numberString);

            if (!int.TryParse(numberString, out _))
            {
                throw new ArgumentException("Input string is not a valid number.");
            }

            int lengthDiff = minLength - numberString.Length;
            if (lengthDiff <= 0)
            {
                return numberString;
            }

            return new string('0', lengthDiff) + numberString;
        }

        public static string EnsureEndsWith(this string value, char ch)
        {
            if (value.Length <= 0) return value;
            if (value.EndsWith(ch))
            {
                return value;
            }

            return value + ch;

        }
    }
}