namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "TechnicalSpecification_MacOSSprocket".</summary>
public class TechnicalSpecificationMacOSSprocket : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "TechnicalSpecificationID".</summary>
    public string? TechnicalSpecificationID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "MacOSSprocketID".</summary>
    public string? MacOSSprocketID { get; set; }

    /// <summary>Navigation über FK MacOSSprocketID → MacOSSprocket.ID.</summary>
    public MacOSSprocket? MacOSSprocket { get; set; }

    /// <summary>Navigation über FK TechnicalSpecificationID → TechnicalSpecification.ID.</summary>
    public TechnicalSpecification? TechnicalSpecification { get; set; }

}
