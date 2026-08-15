namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Series_NegativeFormat".</summary>
public class SeriesNegativeFormat : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "SeriesID".</summary>
    public string? SeriesID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "FilmFormatID".</summary>
    public string? FilmFormatID { get; set; }

    /// <summary>Navigation über FK FilmFormatID → FilmFormat.ID.</summary>
    public FilmFormat? FilmFormat { get; set; }

    /// <summary>Navigation über FK SeriesID → Series.ID.</summary>
    public Series? Series { get; set; }

}
