using System.ComponentModel.DataAnnotations;

namespace Dexlaris.Domain.Core.Attributes;

/// <summary>
/// /// Sets string length to (Min = 1, Max = 250)
/// </summary>
public class ShortDescriptionLengthAttribute : StringLengthAttribute
{
    public const int MaxLength = 250;
    private const int MinLength = 1;

    public ShortDescriptionLengthAttribute()
        : base(MaxLength)
    {
        MinimumLength = MinLength;
    }
}