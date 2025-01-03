namespace Dexlaris.IdentityManager.Configuration;

public record JwtConfig
{
    public const string SectionName = "JwtConfiguration";

    public string Secret { get; set; } = null!;

    public string JwtIssuer { get; set; } = null!;

    public string JwtAudience { get; set; } = null!;
}