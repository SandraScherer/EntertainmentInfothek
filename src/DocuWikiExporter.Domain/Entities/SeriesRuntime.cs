namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Series_Runtime".</summary>
public class SeriesRuntime : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "SeriesID".</summary>
    public string? SeriesID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "Runtime".</summary>
    public long? Runtime { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "EditionID".</summary>
    public string? EditionID { get; set; }

    /// <summary>Navigation über FK EditionID → Edition.ID.</summary>
    public Edition? Edition { get; set; }

    /// <summary>Navigation über FK SeriesID → Series.ID.</summary>
    public Series? Series { get; set; }

}
