namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "CinematographicProcess".</summary>
public class CinematographicProcess : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "Name".</summary>
    public string? Name { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }


    /// <summary>Abhängige Datensätze aus "Movie_CinematographicProcess".</summary>
    public ICollection<MovieCinematographicProcess> MovieCinematographicProcess { get; set; } = new List<MovieCinematographicProcess>();

    /// <summary>Abhängige Datensätze aus "Series_CinematographicProcess".</summary>
    public ICollection<SeriesCinematographicProcess> SeriesCinematographicProcess { get; set; } = new List<SeriesCinematographicProcess>();

}
