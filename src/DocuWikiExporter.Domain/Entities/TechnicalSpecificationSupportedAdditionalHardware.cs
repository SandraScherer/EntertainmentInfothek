namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "TechnicalSpecification_SupportedAdditionalHardware".</summary>
public class TechnicalSpecificationSupportedAdditionalHardware : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "TechnicalSpecificationID".</summary>
    public string? TechnicalSpecificationID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "HardwareID".</summary>
    public string? HardwareID { get; set; }

    /// <summary>Navigation über FK HardwareID → Hardware.ID.</summary>
    public Hardware? Hardware { get; set; }

    /// <summary>Navigation über FK TechnicalSpecificationID → TechnicalSpecification.ID.</summary>
    public TechnicalSpecification? TechnicalSpecification { get; set; }

}
