namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Movie_Country".</summary>
public class MovieCountry : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "MovieID".</summary>
    public string? MovieID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "CountryID".</summary>
    public string? CountryID { get; set; }

    /// <summary>Navigation über FK CountryID → Country.ID.</summary>
    public Country? Country { get; set; }

    /// <summary>Navigation über FK MovieID → Movie.ID.</summary>
    public Movie? Movie { get; set; }

}
