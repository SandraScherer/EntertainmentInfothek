namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Episode_Award".</summary>
public class EpisodeAward : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "EpisodeID".</summary>
    public string? EpisodeID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "AwardID".</summary>
    public string? AwardID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "Category".</summary>
    public string? Category { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "Date".</summary>
    public string? Date { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "Winner".</summary>
    public long? Winner { get; set; }

    /// <summary>Navigation über FK AwardID → Award.ID.</summary>
    public Award? Award { get; set; }

    /// <summary>Navigation über FK EpisodeID → Episode.ID.</summary>
    public Episode? Episode { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Episode_Award" verweisen.</summary>
    public ICollection<EpisodeAwardPerson> EpisodeAwardPersonByEpisode_AwardID { get; set; } = new List<EpisodeAwardPerson>();

}
