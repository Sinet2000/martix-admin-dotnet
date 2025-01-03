namespace Dexlaris.IdentityManager.Configuration;

public record IdentityConfig
{
    public const string SectionName = "IdentityConfiguration";

    public string DefaultPassword { get; set; } = null!;

    public int InviteExpireDays { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Username { get; set; } = null!;
}