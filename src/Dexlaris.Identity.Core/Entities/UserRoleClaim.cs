using Dexlaris.Domain.Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Dexlaris.IdentityManager.Entities;

public class UserRoleClaim : IdentityRoleClaim<int>, IModifiedOnEntity, IBaseEntity
{
    public UserRoleClaim()
    {
    }

    public UserRoleClaim(string roleClaimDescription = null, string roleClaimGroup = null) : base()
    {
        Description = roleClaimDescription;
        Group = roleClaimGroup;
    }

    public string? Description { get; set; }

    public string? Group { get; set; }

    public int? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public virtual UserRole Role { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; }

    public int CreatedById { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public int? ModifiedById { get; set; }

    // mutations
    public void Update(int roleId, string claimType, string claimValue, string? claimGroup = null, string? description = null)
    {
        ClaimType = claimType;
        ClaimValue = claimValue;
        Group = claimGroup;
        Description = description;
        RoleId = roleId;
    }
}