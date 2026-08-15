namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "TechnicalSpecification_SupportedInputDeviceFeature".</summary>
public class TechnicalSpecificationSupportedInputDeviceFeature : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "TechnicalSpecificationID".</summary>
    public string? TechnicalSpecificationID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "InputDeviceFeatureID".</summary>
    public string? InputDeviceFeatureID { get; set; }

    /// <summary>Navigation über FK InputDeviceFeatureID → InputDeviceFeature.ID.</summary>
    public InputDeviceFeature? InputDeviceFeature { get; set; }

    /// <summary>Navigation über FK TechnicalSpecificationID → TechnicalSpecification.ID.</summary>
    public TechnicalSpecification? TechnicalSpecification { get; set; }

}
