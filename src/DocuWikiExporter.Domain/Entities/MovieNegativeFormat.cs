namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Movie_NegativeFormat".</summary>
public class MovieNegativeFormat : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "MovieID".</summary>
    public string? MovieID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "FilmFormatID".</summary>
    public string? FilmFormatID { get; set; }

    /// <summary>Navigation über FK FilmFormatID → FilmFormat.ID.</summary>
    public FilmFormat? FilmFormat { get; set; }

    /// <summary>Navigation über FK MovieID → Movie.ID.</summary>
    public Movie? Movie { get; set; }

}
