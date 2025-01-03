using Ardalis.GuardClauses;
using Dexlaris.Domain.Core.Attributes;
using Dexlaris.Domain.Core.Entities;
using Dexlaris.Domain.Core.Interfaces;

namespace Dexlaris.IdentityManager.Entities
{
    public class UserInvite : BaseEntity, IModifiedOnEntity
    {
        public UserInvite(DateTime expire, User user, Guid key)
        {
            User = user;
            Expire = expire;

            UserId = Guard.Against.NegativeOrZero(user.Id);
            Key = Guard.Against.NullOrEmpty(key);
        }

        public UserInvite(DateTime expire, Guid key)
        {
            Expire = expire;

            Key = Guard.Against.NullOrEmpty(key);
        }

        [IdRange]
        public int UserId { get; private set; }

        public User User { get; private set; } = null!;

        public DateTime Expire { get; private set; }

        public Guid Key { get; private set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public int CreatedById { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string? ModifiedBy { get; set; }

        public int? ModifiedById { get; set; }

        public void SetExpire(DateTime expireDate)
        {
            Expire = expireDate;
        }
    }
}