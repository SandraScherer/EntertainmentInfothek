namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "VideoMode".</summary>
public class VideoMode : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "EnglishTitle".</summary>
    public string? EnglishTitle { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "GermanTitle".</summary>
    public string? GermanTitle { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "VideoMode" verweisen.</summary>
    public ICollection<TechnicalSpecificationSupportedVideoMode> TechnicalSpecificationSupportedVideoModeByVideoModeID { get; set; } = new List<TechnicalSpecificationSupportedVideoMode>();

}
