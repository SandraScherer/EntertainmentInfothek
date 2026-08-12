namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Laboratory".</summary>
public class Laboratory : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "Name".</summary>
    public string? Name { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }


    /// <summary>Abhängige Datensätze aus "Series_Laboratory".</summary>
    public ICollection<SeriesLaboratory> SeriesLaboratory { get; set; } = new List<SeriesLaboratory>();

    /// <summary>Abhängige Datensätze aus "Movie_Laboratory".</summary>
    public ICollection<MovieLaboratory> MovieLaboratory { get; set; } = new List<MovieLaboratory>();

}
