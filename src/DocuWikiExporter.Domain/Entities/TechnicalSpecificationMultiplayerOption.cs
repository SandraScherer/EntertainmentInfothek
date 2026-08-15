namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "TechnicalSpecification_MultiplayerOption".</summary>
public class TechnicalSpecificationMultiplayerOption : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "TechnicalSpecificationID".</summary>
    public string? TechnicalSpecificationID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "MultiplayerOptionID".</summary>
    public string? MultiplayerOptionID { get; set; }

    /// <summary>Navigation über FK MultiplayerOptionID → MultiplayerOption.ID.</summary>
    public MultiplayerOption? MultiplayerOption { get; set; }

    /// <summary>Navigation über FK TechnicalSpecificationID → TechnicalSpecification.ID.</summary>
    public TechnicalSpecification? TechnicalSpecification { get; set; }

}
