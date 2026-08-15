namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Movie_Award_Person".</summary>
public class MovieAwardPerson : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "Movie_AwardID".</summary>
    public string? Movie_AwardID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "PersonID".</summary>
    public string? PersonID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "Role".</summary>
    public string? Role { get; set; }

    /// <summary>Navigation über FK Movie_AwardID → Movie_Award.ID.</summary>
    public MovieAward? MovieAward { get; set; }

    /// <summary>Navigation über FK PersonID → Person.ID.</summary>
    public Person? Person { get; set; }

}
