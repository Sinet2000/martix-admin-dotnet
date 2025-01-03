namespace Dexlaris.Domain.Core.Interfaces
{
    public interface IModifiedOnEntity
    {
        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public int CreatedById { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string? ModifiedBy { get; set; }

        public int? ModifiedById { get; set; }
    }
}