namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Hardware".</summary>
public class Hardware : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "EnglishTitle".</summary>
    public string? EnglishTitle { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "GermanTitle".</summary>
    public string? GermanTitle { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Hardware" verweisen.</summary>
    public ICollection<TechnicalSpecificationRequiredAdditionalHardware> TechnicalSpecificationRequiredAdditionalHardwareByHardwareID { get; set; } = new List<TechnicalSpecificationRequiredAdditionalHardware>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Hardware" verweisen.</summary>
    public ICollection<TechnicalSpecificationSupportedAdditionalHardware> TechnicalSpecificationSupportedAdditionalHardwareByHardwareID { get; set; } = new List<TechnicalSpecificationSupportedAdditionalHardware>();

}
