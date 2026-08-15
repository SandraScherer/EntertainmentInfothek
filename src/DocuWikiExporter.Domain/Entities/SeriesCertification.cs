namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Series_Certification".</summary>
public class SeriesCertification : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "SeriesID".</summary>
    public string? SeriesID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "CertificationID".</summary>
    public string? CertificationID { get; set; }

    /// <summary>Navigation über FK CertificationID → Certification.ID.</summary>
    public Certification? Certification { get; set; }

    /// <summary>Navigation über FK SeriesID → Series.ID.</summary>
    public Series? Series { get; set; }

}
