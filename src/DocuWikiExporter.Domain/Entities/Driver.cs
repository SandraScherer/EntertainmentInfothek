namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Driver".</summary>
public class Driver : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "EnglishTitle".</summary>
    public string? EnglishTitle { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "GermanTitle".</summary>
    public string? GermanTitle { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Driver" verweisen.</summary>
    public ICollection<TechnicalSpecificationSupportedDriver> TechnicalSpecificationSupportedDriverByDriverID { get; set; } = new List<TechnicalSpecificationSupportedDriver>();

}
