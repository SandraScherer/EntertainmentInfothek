namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "TechnicalSpecification_SupportedControllerType".</summary>
public class TechnicalSpecificationSupportedControllerType : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "TechnicalSpecificationID".</summary>
    public string? TechnicalSpecificationID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "ControllerTypeID".</summary>
    public string? ControllerTypeID { get; set; }

    /// <summary>Navigation über FK ControllerTypeID → ControllerType.ID.</summary>
    public ControllerType? ControllerType { get; set; }

    /// <summary>Navigation über FK TechnicalSpecificationID → TechnicalSpecification.ID.</summary>
    public TechnicalSpecification? TechnicalSpecification { get; set; }

}
