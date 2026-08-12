namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Movie_PrintedFilmFormat".</summary>
public class MoviePrintedFilmFormat : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "MovieID".</summary>
    public string? MovieID { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "FilmFormatID".</summary>
    public string? FilmFormatID { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "FilmFormat" (FK FilmFormatID).</summary>
    public FilmFormat? FilmFormat { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Movie" (FK MovieID).</summary>
    public Movie? Movie { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }
}
