namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Series_ProductionDate".</summary>
public class SeriesProductionDate : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "SeriesID".</summary>
    public string? SeriesID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "StartDate".</summary>
    public string? StartDate { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "EndDate".</summary>
    public string? EndDate { get; set; }

    /// <summary>Navigation über FK SeriesID → Series.ID.</summary>
    public Series? Series { get; set; }

}
