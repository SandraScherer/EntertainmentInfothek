namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Episode_CostumeDesign".</summary>
public class EpisodeCostumeDesign : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "EpisodeID".</summary>
    public string? EpisodeID { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "PersonID".</summary>
    public string? PersonID { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "Role".</summary>
    public string? Role { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Episode" (FK EpisodeID).</summary>
    public Episode? Episode { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Person" (FK PersonID).</summary>
    public Person? Person { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }
}
