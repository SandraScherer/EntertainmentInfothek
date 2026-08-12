namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Series_NegativeFormat".</summary>
public class SeriesNegativeFormat : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "SeriesID".</summary>
    public string? SeriesID { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "FilmFormatID".</summary>
    public string? FilmFormatID { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "FilmFormat" (FK FilmFormatID).</summary>
    public FilmFormat? FilmFormat { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Series" (FK SeriesID).</summary>
    public Series? Series { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }
}
