namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Episode_Cast".</summary>
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

    /// <summary>Navigation über FK ActorID → Person.ID.</summary>
    public Person? PersonByActorID { get; set; }

    /// <summary>Navigation über FK CharacterID → Person.ID.</summary>
    public Person? PersonByCharacterID { get; set; }

    /// <summary>Navigation über FK EpisodeID → Episode.ID.</summary>
    public Episode? Episode { get; set; }

    /// <summary>Navigation über FK GermanDubberID → Person.ID.</summary>
    public Person? PersonByGermanDubberID { get; set; }

}
