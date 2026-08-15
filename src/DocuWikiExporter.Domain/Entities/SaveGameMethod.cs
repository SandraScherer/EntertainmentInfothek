namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "SaveGameMethod".</summary>
public class SaveGameMethod : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "EnglishTitle".</summary>
    public string? EnglishTitle { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "GermanTitle".</summary>
    public string? GermanTitle { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "SaveGameMethod" verweisen.</summary>
    public ICollection<TechnicalSpecificationSaveGameMethod> TechnicalSpecificationSaveGameMethodBySaveGameMethodID { get; set; } = new List<TechnicalSpecificationSaveGameMethod>();

}
