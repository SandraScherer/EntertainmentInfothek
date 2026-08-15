namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Movie_Weblink".</summary>
public class MovieWeblink : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "MovieID".</summary>
    public string? MovieID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "WeblinkID".</summary>
    public string? WeblinkID { get; set; }

    /// <summary>Navigation über FK MovieID → Movie.ID.</summary>
    public Movie? Movie { get; set; }

    /// <summary>Navigation über FK WeblinkID → Weblink.ID.</summary>
    public Weblink? Weblink { get; set; }

}
