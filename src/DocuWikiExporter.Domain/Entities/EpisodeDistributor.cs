namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Episode_Distributor".</summary>
public class EpisodeDistributor : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "EpisodeID".</summary>
    public string? EpisodeID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "CompanyID".</summary>
    public string? CompanyID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "CountryID".</summary>
    public string? CountryID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "ReleaseDate".</summary>
    public string? ReleaseDate { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "Role".</summary>
    public string? Role { get; set; }

    /// <summary>Navigation über FK CompanyID → Company.ID.</summary>
    public Company? Company { get; set; }

    /// <summary>Navigation über FK CountryID → Country.ID.</summary>
    public Country? Country { get; set; }

    /// <summary>Navigation über FK EpisodeID → Episode.ID.</summary>
    public Episode? Episode { get; set; }

}
