using System.ComponentModel;

namespace Dexlaris.IdentityManager.Entities.Enums;

public enum EmailSubject
{
    [Description("Paroles atiestatīšanas pieprasījums")]
    ForgotPassword,

    [Description("Lūdzu, izveidojiet savu lietotāju")]
    UserInvite,

    [Description("Izveidoto konta dati")]
    UserInviteCredentials,

    [Description("Lūdzu, apstipriniet savu kontu")]
    ConfirmAccount,
}