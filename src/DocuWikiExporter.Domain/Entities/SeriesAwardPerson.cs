namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Series_Award_Person".</summary>
public class SeriesAwardPerson : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "Series_AwardID".</summary>
    public string? Series_AwardID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "PersonID".</summary>
    public string? PersonID { get; set; }

    /// <summary>Navigation über FK PersonID → Person.ID.</summary>
    public Person? Person { get; set; }

    /// <summary>Navigation über FK Series_AwardID → Series_Award.ID.</summary>
    public SeriesAward? SeriesAward { get; set; }

}
