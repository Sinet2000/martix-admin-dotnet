using Dexlaris.Domain.Core.Interfaces;

namespace Dexlaris.Domain.Core.Entities;

public class FileEntity : BaseEntity, IFileEntity, IModifiedOnEntity
{
    public FileEntity()
    {
    }

    public FileEntity(string filePath, string fileName)
    {
        FilePath = filePath;
        FileName = fileName;
    }

    public string FileName { get; set; } = null!;

    public string FilePath { get; set; } = null!;

    public bool IsSoftDeleted { get; set; } = false;

    public DateTime? ExpirationDate { get; set; }

    public string? EncryptionKey { get; set; }

    public string? EncryptionIV { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = string.Empty;

    public int CreatedById { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public int? ModifiedById { get; set; }

    // mutations
    public void SetFilePath(string filePath)
    {
        FilePath = filePath;
    }

    public void SetFileName(string fileName)
    {
        FileName = fileName;
    }

    public void SetToSoftDeleted(string newFilePath, DateTime expirationDate)
    {
        FileName = Path.GetFileName(newFilePath);
        FilePath = newFilePath;
        IsSoftDeleted = true;
        ExpirationDate = expirationDate;
    }
}