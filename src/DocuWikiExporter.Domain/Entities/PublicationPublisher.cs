namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Publication_Publisher".</summary>
public class PublicationPublisher : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "PublicationID".</summary>
    public string? PublicationID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "CompanyID".</summary>
    public string? CompanyID { get; set; }

    /// <summary>Navigation über FK CompanyID → Company.ID.</summary>
    public Company? Company { get; set; }

    /// <summary>Navigation über FK PublicationID → Publication.ID.</summary>
    public Publication? Publication { get; set; }

}
