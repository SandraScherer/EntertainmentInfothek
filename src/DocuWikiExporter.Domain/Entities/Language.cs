namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Language".</summary>
public class Language : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "OriginalName".</summary>
    public string? OriginalName { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "EnglishName".</summary>
    public string? EnglishName { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "GermanName".</summary>
    public string? GermanName { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Language" verweisen.</summary>
    public ICollection<BookLanguage> BookLanguageByLanguageID { get; set; } = new List<BookLanguage>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Language" verweisen.</summary>
    public ICollection<MovieLanguage> MovieLanguageByLanguageID { get; set; } = new List<MovieLanguage>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Language" verweisen.</summary>
    public ICollection<PublicationLanguage> PublicationLanguageByLanguageID { get; set; } = new List<PublicationLanguage>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Language" verweisen.</summary>
    public ICollection<SeriesLanguage> SeriesLanguageByLanguageID { get; set; } = new List<SeriesLanguage>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Language" verweisen.</summary>
    public ICollection<Text> TextByLanguageID { get; set; } = new List<Text>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Language" verweisen.</summary>
    public ICollection<VideoGameLanguage> VideoGameLanguageByLanguageID { get; set; } = new List<VideoGameLanguage>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Language" verweisen.</summary>
    public ICollection<Weblink> WeblinkByLanguageID { get; set; } = new List<Weblink>();

}
