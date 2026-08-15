namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "ControllerType".</summary>
public class ControllerType : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "EnglishTitle".</summary>
    public string? EnglishTitle { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "GermanTitle".</summary>
    public string? GermanTitle { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "ControllerType" verweisen.</summary>
    public ICollection<TechnicalSpecificationSupportedControllerType> TechnicalSpecificationSupportedControllerTypeByControllerTypeID { get; set; } = new List<TechnicalSpecificationSupportedControllerType>();

}
