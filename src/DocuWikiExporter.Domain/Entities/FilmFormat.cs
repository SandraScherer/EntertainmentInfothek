namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "FilmFormat".</summary>
public class FilmFormat : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "Format".</summary>
    public string? Format { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }


    /// <summary>Abhängige Datensätze aus "Movie_PrintedFilmFormat".</summary>
    public ICollection<MoviePrintedFilmFormat> MoviePrintedFilmFormat { get; set; } = new List<MoviePrintedFilmFormat>();

    /// <summary>Abhängige Datensätze aus "Series_NegativeFormat".</summary>
    public ICollection<SeriesNegativeFormat> SeriesNegativeFormat { get; set; } = new List<SeriesNegativeFormat>();

    /// <summary>Abhängige Datensätze aus "Series_PrintedFilmFormat".</summary>
    public ICollection<SeriesPrintedFilmFormat> SeriesPrintedFilmFormat { get; set; } = new List<SeriesPrintedFilmFormat>();

    /// <summary>Abhängige Datensätze aus "Movie_NegativeFormat".</summary>
    public ICollection<MovieNegativeFormat> MovieNegativeFormat { get; set; } = new List<MovieNegativeFormat>();

}
