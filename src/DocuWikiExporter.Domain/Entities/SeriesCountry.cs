namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Series_Country".</summary>
public class SeriesCountry : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "SeriesID".</summary>
    public string? SeriesID { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "CountryID".</summary>
    public string? CountryID { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Country" (FK CountryID).</summary>
    public Country? Country { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Series" (FK SeriesID).</summary>
    public Series? Series { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }
}
