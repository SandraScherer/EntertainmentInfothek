namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Series_CinematographicProcess".</summary>
public class SeriesCinematographicProcess : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "SeriesID".</summary>
    public string? SeriesID { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "CinematographicProcessID".</summary>
    public string? CinematographicProcessID { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "CinematographicProcess" (FK CinematographicProcessID).</summary>
    public CinematographicProcess? CinematographicProcess { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Series" (FK SeriesID).</summary>
    public Series? Series { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }
}
