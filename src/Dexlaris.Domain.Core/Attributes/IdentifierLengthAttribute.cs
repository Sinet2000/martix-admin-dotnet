using System.ComponentModel.DataAnnotations;

namespace Dexlaris.Domain.Core.Attributes
{
    /// <summary>
    /// Sets string length to (Min = 1, Max = 24)
    /// </summary>
    public class IdentifierLengthAttribute : StringLengthAttribute
    {
        private const int MaxLength = 24;
        private const int MinLength = 1;

        public IdentifierLengthAttribute()
            : base(MaxLength)
        {
            MinimumLength = MinLength;
        }
    }
}