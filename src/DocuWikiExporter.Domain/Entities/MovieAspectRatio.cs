namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Movie_AspectRatio".</summary>
public class MovieAspectRatio : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "MovieID".</summary>
    public string? MovieID { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "AspectRatioID".</summary>
    public string? AspectRatioID { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "AspectRatio" (FK AspectRatioID).</summary>
    public AspectRatio? AspectRatio { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Movie" (FK MovieID).</summary>
    public Movie? Movie { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }
}
