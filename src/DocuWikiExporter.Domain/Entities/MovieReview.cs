namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Movie_Review".</summary>
public class MovieReview : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "MovieID".</summary>
    public string? MovieID { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "TextID".</summary>
    public string? TextID { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Movie" (FK MovieID).</summary>
    public Movie? Movie { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Text" (FK TextID).</summary>
    public Text? Text { get; set; }
}
