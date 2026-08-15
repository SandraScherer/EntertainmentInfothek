namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Camera".</summary>
public class Camera : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "Name".</summary>
    public string? Name { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "Lenses".</summary>
    public string? Lenses { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Camera" verweisen.</summary>
    public ICollection<MovieCamera> MovieCameraByCameraID { get; set; } = new List<MovieCamera>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Camera" verweisen.</summary>
    public ICollection<SeriesCamera> SeriesCameraByCameraID { get; set; } = new List<SeriesCamera>();

}
