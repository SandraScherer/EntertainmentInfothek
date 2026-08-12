namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Location".</summary>
public class Location : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "Location".</summary>
    public string? Location { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "CountryID".</summary>
    public string? CountryID { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Country" (FK CountryID).</summary>
    public Country? Country { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }


    /// <summary>Abhängige Datensätze aus "Series_FilmingLocation".</summary>
    public ICollection<SeriesFilmingLocation> SeriesFilmingLocation { get; set; } = new List<SeriesFilmingLocation>();

    /// <summary>Abhängige Datensätze aus "Movie_FilmingLocation".</summary>
    public ICollection<MovieFilmingLocation> MovieFilmingLocation { get; set; } = new List<MovieFilmingLocation>();

    /// <summary>Abhängige Datensätze aus "Person".</summary>
    public ICollection<Person> Person { get; set; } = new List<Person>();

    /// <summary>Abhängige Datensätze aus "Person".</summary>
    public ICollection<Person> PersonItems { get; set; } = new List<Person>();

    /// <summary>Abhängige Datensätze aus "Episode_FilmingLocation".</summary>
    public ICollection<EpisodeFilmingLocation> EpisodeFilmingLocation { get; set; } = new List<EpisodeFilmingLocation>();

}
