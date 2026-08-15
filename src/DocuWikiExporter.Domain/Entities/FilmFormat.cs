namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "FilmFormat".</summary>
public class FilmFormat : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "Format".</summary>
    public string? Format { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "FilmFormat" verweisen.</summary>
    public ICollection<MovieNegativeFormat> MovieNegativeFormatByFilmFormatID { get; set; } = new List<MovieNegativeFormat>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "FilmFormat" verweisen.</summary>
    public ICollection<MoviePrintedFilmFormat> MoviePrintedFilmFormatByFilmFormatID { get; set; } = new List<MoviePrintedFilmFormat>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "FilmFormat" verweisen.</summary>
    public ICollection<SeriesNegativeFormat> SeriesNegativeFormatByFilmFormatID { get; set; } = new List<SeriesNegativeFormat>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "FilmFormat" verweisen.</summary>
    public ICollection<SeriesPrintedFilmFormat> SeriesPrintedFilmFormatByFilmFormatID { get; set; } = new List<SeriesPrintedFilmFormat>();

}
