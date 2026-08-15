namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Series_Cast".</summary>
public class SeriesCast : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "SeriesID".</summary>
    public string? SeriesID { get; set; }

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

    /// <summary>Navigation über FK GermanDubberID → Person.ID.</summary>
    public Person? PersonByGermanDubberID { get; set; }

    /// <summary>Navigation über FK SeriesID → Series.ID.</summary>
    public Series? Series { get; set; }

}
