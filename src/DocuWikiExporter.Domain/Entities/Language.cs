namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Language".</summary>
public class Language : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "OriginalName".</summary>
    public string? OriginalName { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "EnglishName".</summary>
    public string? EnglishName { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "GermanName".</summary>
    public string? GermanName { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }


    /// <summary>Abhängige Datensätze aus "Weblink".</summary>
    public ICollection<Weblink> Weblink { get; set; } = new List<Weblink>();

    /// <summary>Abhängige Datensätze aus "Series_Language".</summary>
    public ICollection<SeriesLanguage> SeriesLanguage { get; set; } = new List<SeriesLanguage>();

    /// <summary>Abhängige Datensätze aus "Movie_Language".</summary>
    public ICollection<MovieLanguage> MovieLanguage { get; set; } = new List<MovieLanguage>();

    /// <summary>Abhängige Datensätze aus "Text".</summary>
    public ICollection<Text> Text { get; set; } = new List<Text>();

}
