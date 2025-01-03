using Dexlaris.Domain.Core.Attributes;
using Dexlaris.Domain.Core.Interfaces;

namespace Dexlaris.Domain.Core.Entities
{
    public abstract class EntityWithSoftDelete : BaseEntity, ISoftDelete
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        [SmallNameLength]
        public string? DeletedBy { get; set; }

        public int? DeletedById { get; set; }

        bool ISoftDelete.ForceDelete { get; set; }
    }
}