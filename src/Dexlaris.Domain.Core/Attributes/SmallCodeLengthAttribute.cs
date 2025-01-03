using System.ComponentModel.DataAnnotations;

namespace Dexlaris.Domain.Core.Attributes
{
    /// <summary>
    /// Sets string length to (Min = 1, Max = 32)
    /// </summary>
    public class SmallCodeLengthAttribute : StringLengthAttribute
    {
        private const int MinLength = 1;
        private const int MaxLength = 32;

        public SmallCodeLengthAttribute()
            : base(MaxLength)
        {
            MinimumLength = MinLength;
        }
    }
}