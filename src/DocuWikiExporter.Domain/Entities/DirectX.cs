namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "DirectX".</summary>
public class DirectX : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "Version".</summary>
    public string? Version { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "DirectX" verweisen.</summary>
    public ICollection<TechnicalSpecification> TechnicalSpecificationByMinimumDirectXID { get; set; } = new List<TechnicalSpecification>();

}
