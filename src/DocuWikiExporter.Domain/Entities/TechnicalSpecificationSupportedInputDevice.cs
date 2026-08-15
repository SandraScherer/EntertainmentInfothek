namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "TechnicalSpecification_SupportedInputDevice".</summary>
public class TechnicalSpecificationSupportedInputDevice : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "TechnicalSpecificationID".</summary>
    public string? TechnicalSpecificationID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "InputDeviceID".</summary>
    public string? InputDeviceID { get; set; }

    /// <summary>Navigation über FK InputDeviceID → InputDevice.ID.</summary>
    public InputDevice? InputDevice { get; set; }

    /// <summary>Navigation über FK TechnicalSpecificationID → TechnicalSpecification.ID.</summary>
    public TechnicalSpecification? TechnicalSpecification { get; set; }

}
