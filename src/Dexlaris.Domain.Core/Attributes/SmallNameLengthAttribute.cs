using System.ComponentModel.DataAnnotations;

namespace Dexlaris.Domain.Core.Attributes
{
    /// <summary>
    /// Sets string length to (Min = 2, Max = 128)
    /// </summary>
    public class SmallNameLengthAttribute : StringLengthAttribute
    {
        public const int MaxLength = 128;
        private const int MinLength = 2;

        public SmallNameLengthAttribute()
            : base(MaxLength)
        {
            MinimumLength = MinLength;
        }
    }
}