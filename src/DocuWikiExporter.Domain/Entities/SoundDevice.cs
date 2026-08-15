namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "SoundDevice".</summary>
public class SoundDevice : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "EnglishTitle".</summary>
    public string? EnglishTitle { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "GermanTitle".</summary>
    public string? GermanTitle { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "SoundDevice" verweisen.</summary>
    public ICollection<TechnicalSpecificationSupportedSoundDevice> TechnicalSpecificationSupportedSoundDeviceBySoundDeviceID { get; set; } = new List<TechnicalSpecificationSupportedSoundDevice>();

}
