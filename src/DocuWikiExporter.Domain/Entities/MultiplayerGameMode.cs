namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "MultiplayerGameMode".</summary>
public class MultiplayerGameMode : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "EnglishTitle".</summary>
    public string? EnglishTitle { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "GermanTitle".</summary>
    public string? GermanTitle { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "MultiplayerGameMode" verweisen.</summary>
    public ICollection<TechnicalSpecificationMultiplayerGameMode> TechnicalSpecificationMultiplayerGameModeByMultiplayerGameModeID { get; set; } = new List<TechnicalSpecificationMultiplayerGameMode>();

}
