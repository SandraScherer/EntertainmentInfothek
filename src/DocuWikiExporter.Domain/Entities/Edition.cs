namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Edition".</summary>
public class Edition : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "EnglishTitle".</summary>
    public string? EnglishTitle { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "GermanTitle".</summary>
    public string? GermanTitle { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }


    /// <summary>Abhängige Datensätze aus "Series_User".</summary>
    public ICollection<SeriesUser> SeriesUser { get; set; } = new List<SeriesUser>();

    /// <summary>Abhängige Datensätze aus "Movie_User".</summary>
    public ICollection<MovieUser> MovieUser { get; set; } = new List<MovieUser>();

    /// <summary>Abhängige Datensätze aus "Series_Cover".</summary>
    public ICollection<SeriesCover> SeriesCover { get; set; } = new List<SeriesCover>();

    /// <summary>Abhängige Datensätze aus "Movie_Cover".</summary>
    public ICollection<MovieCover> MovieCover { get; set; } = new List<MovieCover>();

    /// <summary>Abhängige Datensätze aus "Series_Runtime".</summary>
    public ICollection<SeriesRuntime> SeriesRuntime { get; set; } = new List<SeriesRuntime>();

    /// <summary>Abhängige Datensätze aus "Movie_Runtime".</summary>
    public ICollection<MovieRuntime> MovieRuntime { get; set; } = new List<MovieRuntime>();

}
