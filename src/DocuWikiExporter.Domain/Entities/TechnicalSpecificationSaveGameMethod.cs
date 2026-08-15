namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "TechnicalSpecification_SaveGameMethod".</summary>
public class TechnicalSpecificationSaveGameMethod : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "TechnicalSpecificationID".</summary>
    public string? TechnicalSpecificationID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "SaveGameMethodID".</summary>
    public string? SaveGameMethodID { get; set; }

    /// <summary>Navigation über FK SaveGameMethodID → SaveGameMethod.ID.</summary>
    public SaveGameMethod? SaveGameMethod { get; set; }

    /// <summary>Navigation über FK TechnicalSpecificationID → TechnicalSpecification.ID.</summary>
    public TechnicalSpecification? TechnicalSpecification { get; set; }

}
