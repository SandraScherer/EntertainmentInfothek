namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Priority".</summary>
public class Priority : EntityBase
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

}
