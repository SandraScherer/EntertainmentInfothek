namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Series_Award".</summary>
public class SeriesAward : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "SeriesID".</summary>
    public string? SeriesID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "AwardID".</summary>
    public string? AwardID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "Category".</summary>
    public string? Category { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "Date".</summary>
    public string? Date { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "Winner".</summary>
    public long? Winner { get; set; }

    /// <summary>Navigation über FK AwardID → Award.ID.</summary>
    public Award? Award { get; set; }

    /// <summary>Navigation über FK SeriesID → Series.ID.</summary>
    public Series? Series { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Series_Award" verweisen.</summary>
    public ICollection<SeriesAwardPerson> SeriesAwardPersonBySeries_AwardID { get; set; } = new List<SeriesAwardPerson>();

}
