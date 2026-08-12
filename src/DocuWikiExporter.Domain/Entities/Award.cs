namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Award".</summary>
public class Award : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "Name".</summary>
    public string? Name { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "PresenterID".</summary>
    public string? PresenterID { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Company" (FK PresenterID).</summary>
    public Company? Presenter { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }


    /// <summary>Abhängige Datensätze aus "Movie_Award".</summary>
    public ICollection<MovieAward> MovieAward { get; set; } = new List<MovieAward>();

    /// <summary>Abhängige Datensätze aus "Episode_Award".</summary>
    public ICollection<EpisodeAward> EpisodeAward { get; set; } = new List<EpisodeAward>();

    /// <summary>Abhängige Datensätze aus "Series_Award".</summary>
    public ICollection<SeriesAward> SeriesAward { get; set; } = new List<SeriesAward>();

}
