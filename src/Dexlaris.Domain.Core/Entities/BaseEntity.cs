using Dexlaris.Domain.Core.Interfaces;
using Sieve.Attributes;

namespace Dexlaris.Domain.Core.Entities;

public abstract class BaseEntity : IBaseEntity
{
    [Sieve(CanSort = true)]
    public virtual int Id { get; set; }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj)) return true;

        if (obj is not BaseEntity other) return false;

        return Id != default && other.Id != default && Id.Equals(other.Id);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(GetType(), Id);
    }

    public static bool operator ==(BaseEntity left, BaseEntity right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(BaseEntity left, BaseEntity right)
    {
        return !Equals(left, right);
    }
}