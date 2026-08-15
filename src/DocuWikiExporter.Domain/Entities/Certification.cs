namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Certification".</summary>
public class Certification : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "Name".</summary>
    public string? Name { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "ImageID".</summary>
    public string? ImageID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "CountryID".</summary>
    public string? CountryID { get; set; }

    /// <summary>Navigation über FK CountryID → Country.ID.</summary>
    public Country? Country { get; set; }

    /// <summary>Navigation über FK ImageID → Image.ID.</summary>
    public Image? Image { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Certification" verweisen.</summary>
    public ICollection<MovieCertification> MovieCertificationByCertificationID { get; set; } = new List<MovieCertification>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Certification" verweisen.</summary>
    public ICollection<PublicationCertification> PublicationCertificationByCertificationID { get; set; } = new List<PublicationCertification>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Certification" verweisen.</summary>
    public ICollection<SeriesCertification> SeriesCertificationByCertificationID { get; set; } = new List<SeriesCertification>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Certification" verweisen.</summary>
    public ICollection<VideoGameCertification> VideoGameCertificationByCertificationID { get; set; } = new List<VideoGameCertification>();

}
