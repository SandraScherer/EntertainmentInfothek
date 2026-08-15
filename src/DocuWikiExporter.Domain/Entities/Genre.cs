namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Genre".</summary>
public class Genre : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "EnglishTitle".</summary>
    public string? EnglishTitle { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "GermanTitle".</summary>
    public string? GermanTitle { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Genre" verweisen.</summary>
    public ICollection<BookGenre> BookGenreByGenreID { get; set; } = new List<BookGenre>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Genre" verweisen.</summary>
    public ICollection<MovieGenre> MovieGenreByGenreID { get; set; } = new List<MovieGenre>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Genre" verweisen.</summary>
    public ICollection<SeriesGenre> SeriesGenreByGenreID { get; set; } = new List<SeriesGenre>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Genre" verweisen.</summary>
    public ICollection<VideoGameGenre> VideoGameGenreByGenreID { get; set; } = new List<VideoGameGenre>();

}
