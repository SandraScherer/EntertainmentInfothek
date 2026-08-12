namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Series_Weblink".</summary>
public class SeriesWeblink : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "SeriesID".</summary>
    public string? SeriesID { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "WeblinkID".</summary>
    public string? WeblinkID { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Series" (FK SeriesID).</summary>
    public Series? Series { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Weblink" (FK WeblinkID).</summary>
    public Weblink? Weblink { get; set; }
}
