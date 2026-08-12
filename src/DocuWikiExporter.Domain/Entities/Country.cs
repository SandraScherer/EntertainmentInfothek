namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Country".</summary>
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

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }


    /// <summary>Abhängige Datensätze aus "Certification".</summary>
    public ICollection<Certification> Certification { get; set; } = new List<Certification>();

    /// <summary>Abhängige Datensätze aus "Movie_Country".</summary>
    public ICollection<MovieCountry> MovieCountry { get; set; } = new List<MovieCountry>();

    /// <summary>Abhängige Datensätze aus "Movie_Distributor".</summary>
    public ICollection<MovieDistributor> MovieDistributor { get; set; } = new List<MovieDistributor>();

    /// <summary>Abhängige Datensätze aus "Series_Distributor".</summary>
    public ICollection<SeriesDistributor> SeriesDistributor { get; set; } = new List<SeriesDistributor>();

    /// <summary>Abhängige Datensätze aus "Image".</summary>
    public ICollection<Image> Image { get; set; } = new List<Image>();

    /// <summary>Abhängige Datensätze aus "Series_Country".</summary>
    public ICollection<SeriesCountry> SeriesCountry { get; set; } = new List<SeriesCountry>();

    /// <summary>Abhängige Datensätze aus "Episode_Distributor".</summary>
    public ICollection<EpisodeDistributor> EpisodeDistributor { get; set; } = new List<EpisodeDistributor>();

    /// <summary>Abhängige Datensätze aus "Location".</summary>
    public ICollection<Location> Location { get; set; } = new List<Location>();

}
