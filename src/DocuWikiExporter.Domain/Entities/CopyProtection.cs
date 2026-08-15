namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "CopyProtection".</summary>
public class CopyProtection : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "Name".</summary>
    public string? Name { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "CopyProtection" verweisen.</summary>
    public ICollection<TechnicalSpecificationCopyProtection> TechnicalSpecificationCopyProtectionByCopyProtectionID { get; set; } = new List<TechnicalSpecificationCopyProtection>();

}
