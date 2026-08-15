namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "SoundMix".</summary>
public class SoundMix : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "EnglishTitle".</summary>
    public string? EnglishTitle { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "GermanTitle".</summary>
    public string? GermanTitle { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "SoundMix" verweisen.</summary>
    public ICollection<MovieSoundMix> MovieSoundMixBySoundMixID { get; set; } = new List<MovieSoundMix>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "SoundMix" verweisen.</summary>
    public ICollection<SeriesSoundMix> SeriesSoundMixBySoundMixID { get; set; } = new List<SeriesSoundMix>();

}
