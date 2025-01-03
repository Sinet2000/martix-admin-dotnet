using Ardalis.GuardClauses;
using Dexlaris.Domain.Core.Attributes;
using Dexlaris.Domain.Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Dexlaris.IdentityManager.Entities
{
    public class User : IdentityUser<int>, IBaseEntity, IModifiedOnEntity, ISoftDelete
    {
        // relations

        public int? UserInviteId { get; set; }

        public UserInvite? UserInvite { get; set; }

        // props

        [NameLength]
        public string FirstName { get; set; } = null!;

        [NameLength]
        public string LastName { get; set; } = null!;

        public string? ProfilePictureDataUrl { get; set; }

        [PhoneLength]
        public string? Phone { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public string? DeletedBy { get; set; }

        public int? DeletedById { get; set; }

        public bool ForceDelete { get; set; }

        public int? LastModifiedBy { get; set; }

        public DateTime? LastModifiedOn { get; set; }

        public DateTime? PasswordLastChangeDate { get; set; }

        public DateTime? EmailLastChangeDate { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public int CreatedById { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string? ModifiedBy { get; set; }

        public int? ModifiedById { get; set; }

        public void SyncPasswordChangeDate()
        {
            PasswordLastChangeDate = DateTime.UtcNow;
        }

        public void UpdateInviteExpire(int inviteExpireDays)
        {
            Guard.Against.Null(UserInvite);
            UserInvite.SetExpire(DateTime.Now.AddDays(inviteExpireDays));
        }
    }
}