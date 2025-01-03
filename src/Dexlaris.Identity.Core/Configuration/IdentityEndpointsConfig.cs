namespace Dexlaris.IdentityManager.Configuration;

public record IdentityEndpointsConfig
{
    public const string SectionName = "IdentityEndpointsConfiguration";

    public string InvitePath { get; set; } = "/identity/invite";

    public string ConfirmEmailPath { get; set; } = "/identity/confirm-email";

    public string ResetPasswordPath { get; set; } = "/identity/reset-password";
}