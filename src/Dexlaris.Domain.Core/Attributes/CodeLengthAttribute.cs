using System.ComponentModel.DataAnnotations;

namespace Dexlaris.Domain.Core.Attributes
{
    /// <summary>
    /// Sets string length to (Min = 1, Max = 64)
    /// </summary>
    public class CodeLengthAttribute : StringLengthAttribute
    {
        private const int MinLength = 1;
        private const int MaxLength = 64;

        public CodeLengthAttribute()
            : base(MaxLength)
        {
            MinimumLength = MinLength;
        }
    }
}