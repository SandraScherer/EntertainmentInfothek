namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "AspectRatio".</summary>
public class AspectRatio : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "Ratio".</summary>
    public string? Ratio { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }


    /// <summary>Abhängige Datensätze aus "Series_AspectRatio".</summary>
    public ICollection<SeriesAspectRatio> SeriesAspectRatio { get; set; } = new List<SeriesAspectRatio>();

    /// <summary>Abhängige Datensätze aus "Movie_AspectRatio".</summary>
    public ICollection<MovieAspectRatio> MovieAspectRatio { get; set; } = new List<MovieAspectRatio>();

}
