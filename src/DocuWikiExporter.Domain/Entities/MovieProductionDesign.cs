namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Movie_ProductionDesign".</summary>
public class MovieProductionDesign : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "MovieID".</summary>
    public string? MovieID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "PersonID".</summary>
    public string? PersonID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "Role".</summary>
    public string? Role { get; set; }

    /// <summary>Navigation über FK MovieID → Movie.ID.</summary>
    public Movie? Movie { get; set; }

    /// <summary>Navigation über FK PersonID → Person.ID.</summary>
    public Person? Person { get; set; }

}
