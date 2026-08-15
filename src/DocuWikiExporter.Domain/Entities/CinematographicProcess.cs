namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "CinematographicProcess".</summary>
public class CinematographicProcess : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "Name".</summary>
    public string? Name { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "CinematographicProcess" verweisen.</summary>
    public ICollection<MovieCinematographicProcess> MovieCinematographicProcessByCinematographicProcessID { get; set; } = new List<MovieCinematographicProcess>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "CinematographicProcess" verweisen.</summary>
    public ICollection<SeriesCinematographicProcess> SeriesCinematographicProcessByCinematographicProcessID { get; set; } = new List<SeriesCinematographicProcess>();

}
