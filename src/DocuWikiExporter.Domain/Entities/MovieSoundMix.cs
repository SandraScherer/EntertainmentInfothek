namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Movie_SoundMix".</summary>
public class MovieSoundMix : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "MovieID".</summary>
    public string? MovieID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "SoundMixID".</summary>
    public string? SoundMixID { get; set; }

    /// <summary>Navigation über FK MovieID → Movie.ID.</summary>
    public Movie? Movie { get; set; }

    /// <summary>Navigation über FK SoundMixID → SoundMix.ID.</summary>
    public SoundMix? SoundMix { get; set; }

}
