namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Award".</summary>
public class Award : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "Name".</summary>
    public string? Name { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "PresenterID".</summary>
    public string? PresenterID { get; set; }

    /// <summary>Navigation über FK PresenterID → Company.ID.</summary>
    public Company? Company { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Award" verweisen.</summary>
    public ICollection<BookAward> BookAwardByAwardID { get; set; } = new List<BookAward>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Award" verweisen.</summary>
    public ICollection<EpisodeAward> EpisodeAwardByAwardID { get; set; } = new List<EpisodeAward>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Award" verweisen.</summary>
    public ICollection<MovieAward> MovieAwardByAwardID { get; set; } = new List<MovieAward>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Award" verweisen.</summary>
    public ICollection<SeriesAward> SeriesAwardByAwardID { get; set; } = new List<SeriesAward>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Award" verweisen.</summary>
    public ICollection<VideoGameAward> VideoGameAwardByAwardID { get; set; } = new List<VideoGameAward>();

}
