namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Country".</summary>
public class Country : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "OriginalShortName".</summary>
    public string? OriginalShortName { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "OriginalFullName".</summary>
    public string? OriginalFullName { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "EnglishShortName".</summary>
    public string? EnglishShortName { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "EnglishFullName".</summary>
    public string? EnglishFullName { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "GermanShortName".</summary>
    public string? GermanShortName { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "GermanFullName".</summary>
    public string? GermanFullName { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Country" verweisen.</summary>
    public ICollection<Certification> CertificationByCountryID { get; set; } = new List<Certification>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Country" verweisen.</summary>
    public ICollection<EpisodeDistributor> EpisodeDistributorByCountryID { get; set; } = new List<EpisodeDistributor>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Country" verweisen.</summary>
    public ICollection<Image> ImageByCountryID { get; set; } = new List<Image>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Country" verweisen.</summary>
    public ICollection<Location> LocationByCountryID { get; set; } = new List<Location>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Country" verweisen.</summary>
    public ICollection<MovieCountry> MovieCountryByCountryID { get; set; } = new List<MovieCountry>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Country" verweisen.</summary>
    public ICollection<MovieDistributor> MovieDistributorByCountryID { get; set; } = new List<MovieDistributor>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Country" verweisen.</summary>
    public ICollection<SeriesCountry> SeriesCountryByCountryID { get; set; } = new List<SeriesCountry>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Country" verweisen.</summary>
    public ICollection<SeriesDistributor> SeriesDistributorByCountryID { get; set; } = new List<SeriesDistributor>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Country" verweisen.</summary>
    public ICollection<VideoGameDeveloper> VideoGameDeveloperByCountryID { get; set; } = new List<VideoGameDeveloper>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Country" verweisen.</summary>
    public ICollection<VideoGameDistributor> VideoGameDistributorByCountryID { get; set; } = new List<VideoGameDistributor>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Country" verweisen.</summary>
    public ICollection<VideoGamePublisher> VideoGamePublisherByCountryID { get; set; } = new List<VideoGamePublisher>();

}
