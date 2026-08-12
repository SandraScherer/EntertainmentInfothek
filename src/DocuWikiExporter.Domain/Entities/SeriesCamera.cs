namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Series_Camera".</summary>
public class SeriesCamera : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "SeriesID".</summary>
    public string? SeriesID { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "CameraID".</summary>
    public string? CameraID { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Camera" (FK CameraID).</summary>
    public Camera? Camera { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Series" (FK SeriesID).</summary>
    public Series? Series { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }
}
