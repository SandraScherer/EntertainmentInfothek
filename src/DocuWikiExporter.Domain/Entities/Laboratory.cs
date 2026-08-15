namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Laboratory".</summary>
public class Laboratory : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "Name".</summary>
    public string? Name { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Laboratory" verweisen.</summary>
    public ICollection<MovieLaboratory> MovieLaboratoryByLaboratoryID { get; set; } = new List<MovieLaboratory>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Laboratory" verweisen.</summary>
    public ICollection<SeriesLaboratory> SeriesLaboratoryByLaboratoryID { get; set; } = new List<SeriesLaboratory>();

}
