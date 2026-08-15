namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "VideoGame_Cast".</summary>
public class VideoGameCast : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "VideoGameID".</summary>
    public string? VideoGameID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "ActorID".</summary>
    public string? ActorID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "DubberID".</summary>
    public string? DubberID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "Character".</summary>
    public string? Character { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "CharacterID".</summary>
    public string? CharacterID { get; set; }

    /// <summary>Navigation über FK ActorID → Person.ID.</summary>
    public Person? PersonByActorID { get; set; }

    /// <summary>Navigation über FK CharacterID → Person.ID.</summary>
    public Person? PersonByCharacterID { get; set; }

    /// <summary>Navigation über FK DubberID → Person.ID.</summary>
    public Person? PersonByDubberID { get; set; }

    /// <summary>Navigation über FK VideoGameID → VideoGame.ID.</summary>
    public VideoGame? VideoGame { get; set; }

}
