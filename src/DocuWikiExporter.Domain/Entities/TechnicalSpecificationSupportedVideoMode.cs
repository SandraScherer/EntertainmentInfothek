namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "TechnicalSpecification_SupportedVideoMode".</summary>
public class TechnicalSpecificationSupportedVideoMode : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "TechnicalSpecificationID".</summary>
    public string? TechnicalSpecificationID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "VideoModeID".</summary>
    public string? VideoModeID { get; set; }

    /// <summary>Navigation über FK TechnicalSpecificationID → TechnicalSpecification.ID.</summary>
    public TechnicalSpecification? TechnicalSpecification { get; set; }

    /// <summary>Navigation über FK VideoModeID → VideoMode.ID.</summary>
    public VideoMode? VideoMode { get; set; }

}
