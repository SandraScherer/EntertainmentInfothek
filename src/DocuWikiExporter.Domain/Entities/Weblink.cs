namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Weblink".</summary>
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

    /// <summary>Navigation zur referenzierten Tabelle "Language" (FK LanguageID).</summary>
    public Language? Language { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }


    /// <summary>Abhängige Datensätze aus "Movie_Weblink".</summary>
    public ICollection<MovieWeblink> MovieWeblink { get; set; } = new List<MovieWeblink>();

    /// <summary>Abhängige Datensätze aus "Series_Weblink".</summary>
    public ICollection<SeriesWeblink> SeriesWeblink { get; set; } = new List<SeriesWeblink>();

}
