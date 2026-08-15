namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "TechnicalSpecification_SupportedVideoResolution".</summary>
public class TechnicalSpecificationSupportedVideoResolution : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "TechnicalSpecificationID".</summary>
    public string? TechnicalSpecificationID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "VideoResolutionID".</summary>
    public string? VideoResolutionID { get; set; }

    /// <summary>Navigation über FK TechnicalSpecificationID → TechnicalSpecification.ID.</summary>
    public TechnicalSpecification? TechnicalSpecification { get; set; }

    /// <summary>Navigation über FK VideoResolutionID → VideoResolution.ID.</summary>
    public VideoResolution? VideoResolution { get; set; }

}
