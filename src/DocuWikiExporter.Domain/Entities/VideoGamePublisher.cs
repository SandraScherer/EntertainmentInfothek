namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "VideoGame_Publisher".</summary>
public class VideoGamePublisher : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "VideoGameID".</summary>
    public string? VideoGameID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "CompanyID".</summary>
    public string? CompanyID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "PlatformID".</summary>
    public string? PlatformID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "CountryID".</summary>
    public string? CountryID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "ReleaseDate".</summary>
    public string? ReleaseDate { get; set; }

    /// <summary>Navigation über FK CompanyID → Company.ID.</summary>
    public Company? Company { get; set; }

    /// <summary>Navigation über FK CountryID → Country.ID.</summary>
    public Country? Country { get; set; }

    /// <summary>Navigation über FK PlatformID → Platform.ID.</summary>
    public Platform? Platform { get; set; }

    /// <summary>Navigation über FK VideoGameID → VideoGame.ID.</summary>
    public VideoGame? VideoGame { get; set; }

}
