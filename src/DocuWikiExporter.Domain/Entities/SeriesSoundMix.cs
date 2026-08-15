namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Series_SoundMix".</summary>
public class SeriesSoundMix : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "SeriesID".</summary>
    public string? SeriesID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "SoundMixID".</summary>
    public string? SoundMixID { get; set; }

    /// <summary>Navigation über FK SeriesID → Series.ID.</summary>
    public Series? Series { get; set; }

    /// <summary>Navigation über FK SoundMixID → SoundMix.ID.</summary>
    public SoundMix? SoundMix { get; set; }

}
