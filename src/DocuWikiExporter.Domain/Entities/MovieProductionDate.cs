namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Movie_ProductionDate".</summary>
public class MovieProductionDate : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "MovieID".</summary>
    public string? MovieID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "StartDate".</summary>
    public string? StartDate { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "EndDate".</summary>
    public string? EndDate { get; set; }

    /// <summary>Navigation über FK MovieID → Movie.ID.</summary>
    public Movie? Movie { get; set; }

}
