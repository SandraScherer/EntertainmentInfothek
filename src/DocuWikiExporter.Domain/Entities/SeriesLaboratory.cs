namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Series_Laboratory".</summary>
public class SeriesLaboratory : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "SeriesID".</summary>
    public string? SeriesID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "LaboratoryID".</summary>
    public string? LaboratoryID { get; set; }

    /// <summary>Navigation über FK LaboratoryID → Laboratory.ID.</summary>
    public Laboratory? Laboratory { get; set; }

    /// <summary>Navigation über FK SeriesID → Series.ID.</summary>
    public Series? Series { get; set; }

}
