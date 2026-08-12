namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Movie_CinematographicProcess".</summary>
public class MovieCinematographicProcess : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "MovieID".</summary>
    public string? MovieID { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "CinematographicProcessID".</summary>
    public string? CinematographicProcessID { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "CinematographicProcess" (FK CinematographicProcessID).</summary>
    public CinematographicProcess? CinematographicProcess { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Movie" (FK MovieID).</summary>
    public Movie? Movie { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }
}
