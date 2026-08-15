namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "MacOSSprocket".</summary>
public class MacOSSprocket : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "Name".</summary>
    public string? Name { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "MacOSSprocket" verweisen.</summary>
    public ICollection<TechnicalSpecificationMacOSSprocket> TechnicalSpecificationMacOSSprocketByMacOSSprocketID { get; set; } = new List<TechnicalSpecificationMacOSSprocket>();

}
