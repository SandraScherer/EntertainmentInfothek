namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "TechnicalSpecification_SupportedSoundDevice".</summary>
public class TechnicalSpecificationSupportedSoundDevice : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "TechnicalSpecificationID".</summary>
    public string? TechnicalSpecificationID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "SoundDeviceID".</summary>
    public string? SoundDeviceID { get; set; }

    /// <summary>Navigation über FK SoundDeviceID → SoundDevice.ID.</summary>
    public SoundDevice? SoundDevice { get; set; }

    /// <summary>Navigation über FK TechnicalSpecificationID → TechnicalSpecification.ID.</summary>
    public TechnicalSpecification? TechnicalSpecification { get; set; }

}
