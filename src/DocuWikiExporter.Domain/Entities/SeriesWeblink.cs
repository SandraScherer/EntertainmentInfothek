namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Series_Weblink".</summary>
public class SeriesWeblink : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "SeriesID".</summary>
    public string? SeriesID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "WeblinkID".</summary>
    public string? WeblinkID { get; set; }

    /// <summary>Navigation über FK SeriesID → Series.ID.</summary>
    public Series? Series { get; set; }

    /// <summary>Navigation über FK WeblinkID → Weblink.ID.</summary>
    public Weblink? Weblink { get; set; }

}
