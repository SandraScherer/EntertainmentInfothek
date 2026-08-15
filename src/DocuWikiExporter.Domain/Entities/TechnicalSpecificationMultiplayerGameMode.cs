namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "TechnicalSpecification_MultiplayerGameMode".</summary>
public class TechnicalSpecificationMultiplayerGameMode : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "TechnicalSpecificationID".</summary>
    public string? TechnicalSpecificationID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "MultiplayerGameModeID".</summary>
    public string? MultiplayerGameModeID { get; set; }

    /// <summary>Navigation über FK MultiplayerGameModeID → MultiplayerGameMode.ID.</summary>
    public MultiplayerGameMode? MultiplayerGameMode { get; set; }

    /// <summary>Navigation über FK TechnicalSpecificationID → TechnicalSpecification.ID.</summary>
    public TechnicalSpecification? TechnicalSpecification { get; set; }

}
