namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Movie_Camera".</summary>
public class MovieCamera : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "MovieID".</summary>
    public string? MovieID { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "CameraID".</summary>
    public string? CameraID { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Camera" (FK CameraID).</summary>
    public Camera? Camera { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Movie" (FK MovieID).</summary>
    public Movie? Movie { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }
}
