namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Episode_SpecialEffects".</summary>
public class EpisodeSpecialEffects : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "EpisodeID".</summary>
    public string? EpisodeID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "PersonID".</summary>
    public string? PersonID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "Role".</summary>
    public string? Role { get; set; }

    /// <summary>Navigation über FK EpisodeID → Episode.ID.</summary>
    public Episode? Episode { get; set; }

    /// <summary>Navigation über FK PersonID → Person.ID.</summary>
    public Person? Person { get; set; }

}
