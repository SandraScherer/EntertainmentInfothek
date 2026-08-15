namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Movie_AspectRatio".</summary>
public class MovieAspectRatio : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "MovieID".</summary>
    public string? MovieID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "AspectRatioID".</summary>
    public string? AspectRatioID { get; set; }

    /// <summary>Navigation über FK AspectRatioID → AspectRatio.ID.</summary>
    public AspectRatio? AspectRatio { get; set; }

    /// <summary>Navigation über FK MovieID → Movie.ID.</summary>
    public Movie? Movie { get; set; }

}
