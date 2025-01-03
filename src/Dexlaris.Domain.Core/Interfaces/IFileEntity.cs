namespace Dexlaris.Domain.Core.Interfaces;

public interface IFileEntity : IBaseEntity
{
    public string FileName { get; set; }

    public string FilePath { get; set; }

    public bool IsSoftDeleted { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public string? EncryptionKey { get; set; }

    public string? EncryptionIV { get; set; }

    public void SetToSoftDeleted(string newFilePath, DateTime expirationDate);
}