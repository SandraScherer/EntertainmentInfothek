namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Publication_Certification".</summary>
public class PublicationCertification : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "PublicationID".</summary>
    public string? PublicationID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "CertificationID".</summary>
    public string? CertificationID { get; set; }

    /// <summary>Navigation über FK CertificationID → Certification.ID.</summary>
    public Certification? Certification { get; set; }

    /// <summary>Navigation über FK PublicationID → Publication.ID.</summary>
    public Publication? Publication { get; set; }

}
