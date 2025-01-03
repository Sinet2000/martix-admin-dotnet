using System.ComponentModel.DataAnnotations;

namespace Dexlaris.Domain.Core.Attributes
{
    /// <summary>
    /// Sets string length to (Min = 5, Max = 320)
    /// </summary>
    public class EmailLengthAttribute : StringLengthAttribute
    {
        private const int MinLength = 5;
        private const int MaxLength = 320;

        public EmailLengthAttribute()
            : base(MaxLength)
        {
            MinimumLength = MinLength;
        }
    }
}