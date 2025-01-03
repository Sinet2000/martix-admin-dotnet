using System.ComponentModel.DataAnnotations;

namespace Dexlaris.Domain.Core.Attributes
{
    /// <summary>
    /// Range[1..int.MaxValue] DataAnnotation.
    /// </summary>
    public class IdRangeAttribute() : RangeAttribute(1, int.MaxValue);
}