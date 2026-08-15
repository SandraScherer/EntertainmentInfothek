namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "TechnicalSpecification_MediaType".</summary>
public class TechnicalSpecificationMediaType : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "TechnicalSpecificationID".</summary>
    public string? TechnicalSpecificationID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "MediaTypeID".</summary>
    public string? MediaTypeID { get; set; }

    /// <summary>Navigation über FK MediaTypeID → MediaType.ID.</summary>
    public MediaType? MediaType { get; set; }

    /// <summary>Navigation über FK TechnicalSpecificationID → TechnicalSpecification.ID.</summary>
    public TechnicalSpecification? TechnicalSpecification { get; set; }

}
