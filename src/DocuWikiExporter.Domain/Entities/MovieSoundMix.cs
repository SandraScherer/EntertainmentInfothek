namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Movie_SoundMix".</summary>
public class MovieSoundMix : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "MovieID".</summary>
    public string? MovieID { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "SoundMixID".</summary>
    public string? SoundMixID { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Movie" (FK MovieID).</summary>
    public Movie? Movie { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "SoundMix" (FK SoundMixID).</summary>
    public SoundMix? SoundMix { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }
}
