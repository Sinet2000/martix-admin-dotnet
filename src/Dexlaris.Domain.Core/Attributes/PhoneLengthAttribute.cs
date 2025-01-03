using System.ComponentModel.DataAnnotations;

namespace Dexlaris.Domain.Core.Attributes
{
    /// <summary>
    /// /// Sets string length to (Min = 4, Max = 24)
    /// </summary>
    public class PhoneLengthAttribute : StringLengthAttribute
    {
        private const int MinLength = 4;
        public const int MaxLength = 24;

        public PhoneLengthAttribute()
            : base(MaxLength)
        {
            MinimumLength = MinLength;
        }
    }
}