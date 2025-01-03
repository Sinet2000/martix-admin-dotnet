using Dexlaris.Domain.Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Dexlaris.IdentityManager.Entities;

public class UserRole : IdentityRole<int>, IModifiedOnEntity
{
    public UserRole()
    {
    }

    public UserRole(string roleName, string? roleDescription = null)
        : base(roleName)
    {
        Description = roleDescription;
    }

    public string? Description { get; set; }

    public int? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = default!;

    public int CreatedById { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public int? ModifiedById { get; set; }

    public ICollection<UserRoleClaim> RoleClaims { get; set; } = new HashSet<UserRoleClaim>();
}