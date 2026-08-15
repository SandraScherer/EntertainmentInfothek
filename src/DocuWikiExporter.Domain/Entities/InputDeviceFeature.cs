namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "InputDeviceFeature".</summary>
public class InputDeviceFeature : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "EnglishTitle".</summary>
    public string? EnglishTitle { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "GermanTitle".</summary>
    public string? GermanTitle { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "InputDeviceFeature" verweisen.</summary>
    public ICollection<TechnicalSpecificationSupportedInputDeviceFeature> TechnicalSpecificationSupportedInputDeviceFeatureByInputDeviceFeatureID { get; set; } = new List<TechnicalSpecificationSupportedInputDeviceFeature>();

}
