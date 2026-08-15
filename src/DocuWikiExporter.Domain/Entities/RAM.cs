namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "RAM".</summary>
public class RAM : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "Memory".</summary>
    public string? Memory { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "RAM" verweisen.</summary>
    public ICollection<TechnicalSpecification> TechnicalSpecificationByMinimumRAMID { get; set; } = new List<TechnicalSpecification>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "RAM" verweisen.</summary>
    public ICollection<TechnicalSpecification> TechnicalSpecificationByMinimumVideoRAMID { get; set; } = new List<TechnicalSpecification>();

}
