namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Series_Distributor".</summary>
public class SeriesDistributor : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "SeriesID".</summary>
    public string? SeriesID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "CompanyID".</summary>
    public string? CompanyID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "CountryID".</summary>
    public string? CountryID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "ReleaseDate".</summary>
    public string? ReleaseDate { get; set; }

    /// <summary>Navigation über FK CompanyID → Company.ID.</summary>
    public Company? Company { get; set; }

    /// <summary>Navigation über FK CountryID → Country.ID.</summary>
    public Country? Country { get; set; }

    /// <summary>Navigation über FK SeriesID → Series.ID.</summary>
    public Series? Series { get; set; }

}
