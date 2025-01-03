using System.ComponentModel.DataAnnotations;

namespace Dexlaris.Domain.Core.Attributes
{
    /// <summary>
    /// Sets string length to (Min = 2, Max = 1024)
    /// </summary>
    public class DescriptionLengthAttribute : StringLengthAttribute
    {
        public const int MaxLength = 1024;
        private const int MinLength = 2;

        public DescriptionLengthAttribute()
            : base(MaxLength)
        {
            MinimumLength = MinLength;
        }
    }
}