namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Publication".</summary>
public class Publication : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "ISBN13".</summary>
    public string? ISBN13 { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "ISBN10".</summary>
    public string? ISBN10 { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "ReleaseDate".</summary>
    public string? ReleaseDate { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "FormatID".</summary>
    public string? FormatID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "EditionID".</summary>
    public string? EditionID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "NoOfPages".</summary>
    public string? NoOfPages { get; set; }

    /// <summary>Navigation über FK EditionID → Edition.ID.</summary>
    public Edition? Edition { get; set; }

    /// <summary>Navigation über FK FormatID → Type.ID.</summary>
    public Type? Type { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Publication" verweisen.</summary>
    public ICollection<BookPublication> BookPublicationByPublicationID { get; set; } = new List<BookPublication>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Publication" verweisen.</summary>
    public ICollection<BookUser> BookUserByPublicationID { get; set; } = new List<BookUser>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Publication" verweisen.</summary>
    public ICollection<PublicationCertification> PublicationCertificationByPublicationID { get; set; } = new List<PublicationCertification>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Publication" verweisen.</summary>
    public ICollection<PublicationLanguage> PublicationLanguageByPublicationID { get; set; } = new List<PublicationLanguage>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Publication" verweisen.</summary>
    public ICollection<PublicationPublisher> PublicationPublisherByPublicationID { get; set; } = new List<PublicationPublisher>();

}
