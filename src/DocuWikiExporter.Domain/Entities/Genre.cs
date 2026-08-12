namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Genre".</summary>
public class Genre : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "EnglishTitle".</summary>
    public string? EnglishTitle { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "GermanTitle".</summary>
    public string? GermanTitle { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }


    /// <summary>Abhängige Datensätze aus "Movie_Genre".</summary>
    public ICollection<MovieGenre> MovieGenre { get; set; } = new List<MovieGenre>();

    /// <summary>Abhängige Datensätze aus "Series_Genre".</summary>
    public ICollection<SeriesGenre> SeriesGenre { get; set; } = new List<SeriesGenre>();

}
