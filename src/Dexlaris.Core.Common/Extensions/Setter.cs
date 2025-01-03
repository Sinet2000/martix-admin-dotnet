using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Ardalis.GuardClauses;

namespace Dexlaris.Core.Common.Extensions;

public static class ValueGuard
{
    public static string EnsureNotEmptyAndTrim([NotNull] string? value, [CallerArgumentExpression("value")] string? paramName = null)
    {
        Guard.Against.NullOrWhiteSpace(value, paramName);
        return value.Trim();
    }

    public static Guid EnsureNotNull([NotNull] Guid? value, [CallerArgumentExpression("value")] string? paramName = null)
    {
        Guard.Against.Null(value, paramName);
        return value.Value;
    }

    public static int EnsurePositive(int value, [CallerArgumentExpression("value")] string? paramName = null)
    {
        return Guard.Against.NegativeOrZero(value, paramName);
    }

    public static long EnsurePositive(long value, [CallerArgumentExpression("value")] string? paramName = null)
    {
        return Guard.Against.NegativeOrZero(value, paramName);
    }

    public static int? EnsurePositiveIfNotNull(int? value, [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (value.HasValue)
        {
            Guard.Against.NegativeOrZero(value.Value, paramName);
        }
        return value;
    }

    public static long? EnsurePositiveIfNotNull(long? value, [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (value.HasValue)
        {
            Guard.Against.NegativeOrZero(value.Value, paramName);
        }
        return value;
    }

    public static string? TrimOrNull(string? value)
    {
        return string.IsNullOrWhiteSpace(value) ? null : value.Trim();
    }

    public static string? TrimOrDefault(string? value, string? defaultValue)
    {
        return string.IsNullOrWhiteSpace(value) ? defaultValue : value.Trim();
    }

    public static bool GetValueOrDefault(bool? value)
    {
        return value ?? false;
    }
}
