namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Movie_Certification".</summary>
public class MovieCertification : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "MovieID".</summary>
    public string? MovieID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "CertificationID".</summary>
    public string? CertificationID { get; set; }

    /// <summary>Navigation über FK CertificationID → Certification.ID.</summary>
    public Certification? Certification { get; set; }

    /// <summary>Navigation über FK MovieID → Movie.ID.</summary>
    public Movie? Movie { get; set; }

}
