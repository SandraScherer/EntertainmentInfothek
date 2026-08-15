namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Series_CinematographicProcess".</summary>
public class SeriesCinematographicProcess : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "SeriesID".</summary>
    public string? SeriesID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "CinematographicProcessID".</summary>
    public string? CinematographicProcessID { get; set; }

    /// <summary>Navigation über FK CinematographicProcessID → CinematographicProcess.ID.</summary>
    public CinematographicProcess? CinematographicProcess { get; set; }

    /// <summary>Navigation über FK SeriesID → Series.ID.</summary>
    public Series? Series { get; set; }

}
