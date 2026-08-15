namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "CPU".</summary>
public class CPU : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "Name".</summary>
    public string? Name { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "CPU" verweisen.</summary>
    public ICollection<TechnicalSpecification> TechnicalSpecificationByMinimumCPUClassID { get; set; } = new List<TechnicalSpecification>();

}
