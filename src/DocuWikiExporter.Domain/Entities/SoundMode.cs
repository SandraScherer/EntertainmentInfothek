namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "SoundMode".</summary>
public class SoundMode : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "EnglishTitle".</summary>
    public string? EnglishTitle { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "GermanTitle".</summary>
    public string? GermanTitle { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "SoundMode" verweisen.</summary>
    public ICollection<TechnicalSpecificationSupportedSoundMode> TechnicalSpecificationSupportedSoundModeBySoundModeID { get; set; } = new List<TechnicalSpecificationSupportedSoundMode>();

}
