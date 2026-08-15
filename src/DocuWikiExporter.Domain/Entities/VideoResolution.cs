namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "VideoResolution".</summary>
public class VideoResolution : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "Resolution".</summary>
    public string? Resolution { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "VideoResolution" verweisen.</summary>
    public ICollection<TechnicalSpecificationSupportedVideoResolution> TechnicalSpecificationSupportedVideoResolutionByVideoResolutionID { get; set; } = new List<TechnicalSpecificationSupportedVideoResolution>();

}
