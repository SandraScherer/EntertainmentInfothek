namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Episode_Cast".</summary>
public class EpisodeCast : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "EpisodeID".</summary>
    public string? EpisodeID { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "ActorID".</summary>
    public string? ActorID { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "GermanDubberID".</summary>
    public string? GermanDubberID { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "Character".</summary>
    public string? Character { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "CharacterID".</summary>
    public string? CharacterID { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Person" (FK ActorID).</summary>
    public Person? Actor { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Person" (FK CharacterID).</summary>
    public Person? Character { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Episode" (FK EpisodeID).</summary>
    public Episode? Episode { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Person" (FK GermanDubberID).</summary>
    public Person? GermanDubber { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }
}
