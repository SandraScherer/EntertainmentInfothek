namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Series_AspectRatio".</summary>
public class SeriesAspectRatio : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "SeriesID".</summary>
    public string? SeriesID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "AspectRatioID".</summary>
    public string? AspectRatioID { get; set; }

    /// <summary>Navigation über FK AspectRatioID → AspectRatio.ID.</summary>
    public AspectRatio? AspectRatio { get; set; }

    /// <summary>Navigation über FK SeriesID → Series.ID.</summary>
    public Series? Series { get; set; }

}
