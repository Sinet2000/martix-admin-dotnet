namespace Dexlaris.Domain.Core.Interfaces
{
    public interface ISoftDelete
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public string? DeletedBy { get; set; }

        public int? DeletedById { get; set; }

        internal protected bool ForceDelete { get; set; }

        public void SetForceDelete(bool shouldDelete = true)
        {
            ForceDelete = shouldDelete;
        }

        public bool IsForceDelete()
        {
            return ForceDelete;
        }

        public void UndoSoftDelete(ISoftDelete entity)
        {
            IsDeleted = false;
            DeletedOn = null;
            DeletedBy = null;
        }
    }
}