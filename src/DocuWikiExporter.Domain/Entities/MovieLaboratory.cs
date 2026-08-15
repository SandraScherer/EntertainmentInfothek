namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Movie_Laboratory".</summary>
public class MovieLaboratory : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "MovieID".</summary>
    public string? MovieID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "LaboratoryID".</summary>
    public string? LaboratoryID { get; set; }

    /// <summary>Navigation über FK LaboratoryID → Laboratory.ID.</summary>
    public Laboratory? Laboratory { get; set; }

    /// <summary>Navigation über FK MovieID → Movie.ID.</summary>
    public Movie? Movie { get; set; }

}
