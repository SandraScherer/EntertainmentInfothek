namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Location".</summary>
public class Location : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "Location".</summary>
    public string? Location { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "CountryID".</summary>
    public string? CountryID { get; set; }

    /// <summary>Navigation über FK CountryID → Country.ID.</summary>
    public Country? Country { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Location" verweisen.</summary>
    public ICollection<EpisodeFilmingLocation> EpisodeFilmingLocationByLocationID { get; set; } = new List<EpisodeFilmingLocation>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Location" verweisen.</summary>
    public ICollection<MovieFilmingLocation> MovieFilmingLocationByLocationID { get; set; } = new List<MovieFilmingLocation>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Location" verweisen.</summary>
    public ICollection<Person> PersonByLocationOfBirthID { get; set; } = new List<Person>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Location" verweisen.</summary>
    public ICollection<Person> PersonByLocationOfDeathID { get; set; } = new List<Person>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Location" verweisen.</summary>
    public ICollection<SeriesFilmingLocation> SeriesFilmingLocationByLocationID { get; set; } = new List<SeriesFilmingLocation>();

}
