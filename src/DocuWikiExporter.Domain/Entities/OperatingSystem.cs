namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "OperatingSystem".</summary>
public class OperatingSystem : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "Name".</summary>
    public string? Name { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "OperatingSystem" verweisen.</summary>
    public ICollection<TechnicalSpecification> TechnicalSpecificationByMinimumOSClassID { get; set; } = new List<TechnicalSpecification>();

}
