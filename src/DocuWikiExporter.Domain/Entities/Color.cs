namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Color".</summary>
public class Color : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "EnglishTitle".</summary>
    public string? EnglishTitle { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "GermanTitle".</summary>
    public string? GermanTitle { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Color" verweisen.</summary>
    public ICollection<MovieColor> MovieColorByColorID { get; set; } = new List<MovieColor>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Color" verweisen.</summary>
    public ICollection<SeriesColor> SeriesColorByColorID { get; set; } = new List<SeriesColor>();

}
