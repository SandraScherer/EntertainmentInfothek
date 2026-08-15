namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "MultiplayerOption".</summary>
public class MultiplayerOption : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "EnglishTitle".</summary>
    public string? EnglishTitle { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "GermanTitle".</summary>
    public string? GermanTitle { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "MultiplayerOption" verweisen.</summary>
    public ICollection<TechnicalSpecificationMultiplayerOption> TechnicalSpecificationMultiplayerOptionByMultiplayerOptionID { get; set; } = new List<TechnicalSpecificationMultiplayerOption>();

}
