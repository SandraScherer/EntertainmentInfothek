namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Movie_Poster".</summary>
public class MoviePoster : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "MovieID".</summary>
    public string? MovieID { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "ImageID".</summary>
    public string? ImageID { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Image" (FK ImageID).</summary>
    public Image? Image { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Movie" (FK MovieID).</summary>
    public Movie? Movie { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }
}
