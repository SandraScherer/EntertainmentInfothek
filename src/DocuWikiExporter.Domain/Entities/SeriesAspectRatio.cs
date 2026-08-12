namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Series_AspectRatio".</summary>
public class SeriesAspectRatio : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "SeriesID".</summary>
    public string? SeriesID { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "AspectRatioID".</summary>
    public string? AspectRatioID { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "AspectRatio" (FK AspectRatioID).</summary>
    public AspectRatio? AspectRatio { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Series" (FK SeriesID).</summary>
    public Series? Series { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }
}
