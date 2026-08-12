namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Certification".</summary>
public class Certification : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "Name".</summary>
    public string? Name { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "ImageID".</summary>
    public string? ImageID { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "CountryID".</summary>
    public string? CountryID { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Country" (FK CountryID).</summary>
    public Country? Country { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Image" (FK ImageID).</summary>
    public Image? Image { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }


    /// <summary>Abhängige Datensätze aus "Series_Certification".</summary>
    public ICollection<SeriesCertification> SeriesCertification { get; set; } = new List<SeriesCertification>();

    /// <summary>Abhängige Datensätze aus "Movie_Certification".</summary>
    public ICollection<MovieCertification> MovieCertification { get; set; } = new List<MovieCertification>();

}
