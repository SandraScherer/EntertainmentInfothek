namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Movie_Cast".</summary>
public class MovieCast : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "MovieID".</summary>
    public string? MovieID { get; set; }
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

    /// <summary>Navigation zur referenzierten Tabelle "Person" (FK GermanDubberID).</summary>
    public Person? GermanDubber { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Movie" (FK MovieID).</summary>
    public Movie? Movie { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }
}
