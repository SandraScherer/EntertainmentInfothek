namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Weblink".</summary>
public class Weblink : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "URL".</summary>
    public string? URL { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "EnglishTitle".</summary>
    public string? EnglishTitle { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "GermanTitle".</summary>
    public string? GermanTitle { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "LanguageID".</summary>
    public string? LanguageID { get; set; }

    /// <summary>Navigation über FK LanguageID → Language.ID.</summary>
    public Language? Language { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Weblink" verweisen.</summary>
    public ICollection<BookWeblink> BookWeblinkByWeblinkID { get; set; } = new List<BookWeblink>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Weblink" verweisen.</summary>
    public ICollection<MovieWeblink> MovieWeblinkByWeblinkID { get; set; } = new List<MovieWeblink>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Weblink" verweisen.</summary>
    public ICollection<SeriesWeblink> SeriesWeblinkByWeblinkID { get; set; } = new List<SeriesWeblink>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Weblink" verweisen.</summary>
    public ICollection<VideoGameWeblink> VideoGameWeblinkByWeblinkID { get; set; } = new List<VideoGameWeblink>();

}
