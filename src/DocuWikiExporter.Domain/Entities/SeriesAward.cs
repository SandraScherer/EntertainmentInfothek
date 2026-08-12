namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Series_Award".</summary>
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

    /// <summary>Navigation zur referenzierten Tabelle "Award" (FK AwardID).</summary>
    public Award? Award { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Series" (FK SeriesID).</summary>
    public Series? Series { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }


    /// <summary>Abhängige Datensätze aus "Series_Award_Person".</summary>
    public ICollection<SeriesAwardPerson> SeriesAwardPerson { get; set; } = new List<SeriesAwardPerson>();

}
