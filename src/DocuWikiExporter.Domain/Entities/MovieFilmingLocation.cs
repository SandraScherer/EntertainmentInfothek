namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Movie_FilmingLocation".</summary>
public class MovieFilmingLocation : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "MovieID".</summary>
    public string? MovieID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "LocationID".</summary>
    public string? LocationID { get; set; }

    /// <summary>Navigation über FK LocationID → Location.ID.</summary>
    public Location? Location { get; set; }

    /// <summary>Navigation über FK MovieID → Movie.ID.</summary>
    public Movie? Movie { get; set; }

}
