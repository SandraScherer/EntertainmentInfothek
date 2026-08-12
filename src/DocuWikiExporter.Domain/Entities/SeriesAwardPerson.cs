namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Series_Award_Person".</summary>
public class SeriesAwardPerson : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "Series_AwardID".</summary>
    public string? Series_AwardID { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "PersonID".</summary>
    public string? PersonID { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Person" (FK PersonID).</summary>
    public Person? Person { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Series_Award" (FK Series_AwardID).</summary>
    public SeriesAward? Series_Award { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }
}
