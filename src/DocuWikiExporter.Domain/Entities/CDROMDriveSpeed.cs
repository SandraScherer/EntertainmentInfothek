namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "CDROMDriveSpeed".</summary>
public class CDROMDriveSpeed : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "Speed".</summary>
    public string? Speed { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "CDROMDriveSpeed" verweisen.</summary>
    public ICollection<TechnicalSpecification> TechnicalSpecificationByMinimumCDRomDriveSpeedID { get; set; } = new List<TechnicalSpecification>();

}
