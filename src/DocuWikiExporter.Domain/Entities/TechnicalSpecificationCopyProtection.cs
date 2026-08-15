namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "TechnicalSpecification_CopyProtection".</summary>
public class TechnicalSpecificationCopyProtection : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "TechnicalSpecificationID".</summary>
    public string? TechnicalSpecificationID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "CopyProtectionID".</summary>
    public string? CopyProtectionID { get; set; }

    /// <summary>Navigation über FK CopyProtectionID → CopyProtection.ID.</summary>
    public CopyProtection? CopyProtection { get; set; }

    /// <summary>Navigation über FK TechnicalSpecificationID → TechnicalSpecification.ID.</summary>
    public TechnicalSpecification? TechnicalSpecification { get; set; }

}
