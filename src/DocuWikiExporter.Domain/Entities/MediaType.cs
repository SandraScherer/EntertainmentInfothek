namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "MediaType".</summary>
public class MediaType : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "Name".</summary>
    public string? Name { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "MediaType" verweisen.</summary>
    public ICollection<TechnicalSpecificationMediaType> TechnicalSpecificationMediaTypeByMediaTypeID { get; set; } = new List<TechnicalSpecificationMediaType>();

}
