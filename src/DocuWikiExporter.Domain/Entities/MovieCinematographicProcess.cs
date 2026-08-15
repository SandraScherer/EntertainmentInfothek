namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Movie_CinematographicProcess".</summary>
public class MovieCinematographicProcess : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "MovieID".</summary>
    public string? MovieID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "CinematographicProcessID".</summary>
    public string? CinematographicProcessID { get; set; }

    /// <summary>Navigation über FK CinematographicProcessID → CinematographicProcess.ID.</summary>
    public CinematographicProcess? CinematographicProcess { get; set; }

    /// <summary>Navigation über FK MovieID → Movie.ID.</summary>
    public Movie? Movie { get; set; }

}
