namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Episode_Award".</summary>
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

    /// <summary>Navigation zur referenzierten Tabelle "Award" (FK AwardID).</summary>
    public Award? Award { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Episode" (FK EpisodeID).</summary>
    public Episode? Episode { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }


    /// <summary>Abhängige Datensätze aus "Episode_Award_Person".</summary>
    public ICollection<EpisodeAwardPerson> EpisodeAwardPerson { get; set; } = new List<EpisodeAwardPerson>();

}
