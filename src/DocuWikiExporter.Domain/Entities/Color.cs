namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Color".</summary>
public class Color : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "EnglishTitle".</summary>
    public string? EnglishTitle { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "GermanTitle".</summary>
    public string? GermanTitle { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }


    /// <summary>Abhängige Datensätze aus "Series_Color".</summary>
    public ICollection<SeriesColor> SeriesColor { get; set; } = new List<SeriesColor>();

    /// <summary>Abhängige Datensätze aus "Movie_Color".</summary>
    public ICollection<MovieColor> MovieColor { get; set; } = new List<MovieColor>();

}
