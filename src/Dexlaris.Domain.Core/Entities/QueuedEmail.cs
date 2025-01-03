using Dexlaris.Domain.Core.Attributes;

namespace Dexlaris.Domain.Core.Entities;

public class QueuedEmail : BaseEntity
{
    public QueuedEmail(string sender, string recipient, string subject, string body)
    {
        Sender = sender;
        Recipient = recipient;
        Subject = subject;
        Body = body;
    }

    private QueuedEmail()
    {
    }

    [EmailLength]
    public string Sender { get; private set; } = null!;

    [EmailLength]
    public string Recipient { get; private set; } = null!;

    [NameLength]
    public string Subject { get; private set; } = null!;

    [DescriptionLength]
    public string Body { get; private set; } = null!;

    public bool IsSent { get; private set; }

    public void MarkAsSent()
    {
        IsSent = true;
    }
}