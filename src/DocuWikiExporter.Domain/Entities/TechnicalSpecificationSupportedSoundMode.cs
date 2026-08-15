namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "TechnicalSpecification_SupportedSoundMode".</summary>
public class TechnicalSpecificationSupportedSoundMode : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "TechnicalSpecificationID".</summary>
    public string? TechnicalSpecificationID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "SoundModeID".</summary>
    public string? SoundModeID { get; set; }

    /// <summary>Navigation über FK SoundModeID → SoundMode.ID.</summary>
    public SoundMode? SoundMode { get; set; }

    /// <summary>Navigation über FK TechnicalSpecificationID → TechnicalSpecification.ID.</summary>
    public TechnicalSpecification? TechnicalSpecification { get; set; }

}
