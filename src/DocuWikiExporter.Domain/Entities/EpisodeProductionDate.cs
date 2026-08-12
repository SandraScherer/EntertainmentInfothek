namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Episode_ProductionDate".</summary>
public class EpisodeProductionDate : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "EpisodeID".</summary>
    public string? EpisodeID { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "StartDate".</summary>
    public string? StartDate { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "EndDate".</summary>
    public string? EndDate { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Episode" (FK EpisodeID).</summary>
    public Episode? Episode { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }
}
