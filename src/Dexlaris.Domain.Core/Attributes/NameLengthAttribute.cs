using System.ComponentModel.DataAnnotations;

namespace Dexlaris.Domain.Core.Attributes
{
    /// <summary>
    /// Sets string length to (Min = 2, Max = 256)
    /// </summary>
    public class NameLengthAttribute : StringLengthAttribute
    {
        public const int MaxLength = 256;
        private const int MinLength = 2;

        public NameLengthAttribute()
            : base(MaxLength)
        {
            MinimumLength = MinLength;
        }
    }
}