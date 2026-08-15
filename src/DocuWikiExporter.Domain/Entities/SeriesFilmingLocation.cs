namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Series_FilmingLocation".</summary>
public class SeriesFilmingLocation : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "SeriesID".</summary>
    public string? SeriesID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "LocationID".</summary>
    public string? LocationID { get; set; }

    /// <summary>Navigation über FK LocationID → Location.ID.</summary>
    public Location? Location { get; set; }

    /// <summary>Navigation über FK SeriesID → Series.ID.</summary>
    public Series? Series { get; set; }

}
