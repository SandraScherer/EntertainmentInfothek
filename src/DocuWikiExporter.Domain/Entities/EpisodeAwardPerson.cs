namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Episode_Award_Person".</summary>
public class EpisodeAwardPerson : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "Episode_AwardID".</summary>
    public string? Episode_AwardID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "PersonID".</summary>
    public string? PersonID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "Role".</summary>
    public string? Role { get; set; }

    /// <summary>Navigation über FK Episode_AwardID → Episode_Award.ID.</summary>
    public EpisodeAward? EpisodeAward { get; set; }

    /// <summary>Navigation über FK PersonID → Person.ID.</summary>
    public Person? Person { get; set; }

}
