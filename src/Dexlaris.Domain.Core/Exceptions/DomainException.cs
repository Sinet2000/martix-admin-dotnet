namespace Dexlaris.Domain.Core.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string context, string message)
            : base(message)
        {
            Context = context;
        }

        public DomainException(string context, string message, Exception innerException)
            : base(message, innerException)
        {
            Context = context;
        }

        public string Context { get; init; }
    }
}