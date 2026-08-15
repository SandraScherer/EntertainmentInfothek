namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "InputDevice".</summary>
public class InputDevice : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "EnglishTitle".</summary>
    public string? EnglishTitle { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "GermanTitle".</summary>
    public string? GermanTitle { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "InputDevice" verweisen.</summary>
    public ICollection<TechnicalSpecificationRequiredInputDevice> TechnicalSpecificationRequiredInputDeviceByInputDeviceID { get; set; } = new List<TechnicalSpecificationRequiredInputDevice>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "InputDevice" verweisen.</summary>
    public ICollection<TechnicalSpecificationSupportedInputDevice> TechnicalSpecificationSupportedInputDeviceByInputDeviceID { get; set; } = new List<TechnicalSpecificationSupportedInputDevice>();

}
