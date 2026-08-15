namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "AspectRatio".</summary>
public class AspectRatio : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "Ratio".</summary>
    public string? Ratio { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "AspectRatio" verweisen.</summary>
    public ICollection<MovieAspectRatio> MovieAspectRatioByAspectRatioID { get; set; } = new List<MovieAspectRatio>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "AspectRatio" verweisen.</summary>
    public ICollection<SeriesAspectRatio> SeriesAspectRatioByAspectRatioID { get; set; } = new List<SeriesAspectRatio>();

}
