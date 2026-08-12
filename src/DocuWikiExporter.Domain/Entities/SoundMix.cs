namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "SoundMix".</summary>
public class SoundMix : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "EnglishTitle".</summary>
    public string? EnglishTitle { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "GermanTitle".</summary>
    public string? GermanTitle { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }


    /// <summary>Abhängige Datensätze aus "Movie_SoundMix".</summary>
    public ICollection<MovieSoundMix> MovieSoundMix { get; set; } = new List<MovieSoundMix>();

    /// <summary>Abhängige Datensätze aus "Series_SoundMix".</summary>
    public ICollection<SeriesSoundMix> SeriesSoundMix { get; set; } = new List<SeriesSoundMix>();

}
