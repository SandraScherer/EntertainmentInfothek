namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Camera".</summary>
public class Camera : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "Name".</summary>
    public string? Name { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "Lenses".</summary>
    public string? Lenses { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }


    /// <summary>Abhängige Datensätze aus "Series_Camera".</summary>
    public ICollection<SeriesCamera> SeriesCamera { get; set; } = new List<SeriesCamera>();

    /// <summary>Abhängige Datensätze aus "Movie_Camera".</summary>
    public ICollection<MovieCamera> MovieCamera { get; set; } = new List<MovieCamera>();

}
