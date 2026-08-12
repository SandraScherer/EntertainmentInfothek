namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Type".</summary>
public class Type : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "EnglishTitle".</summary>
    public string? EnglishTitle { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "GermanTitle".</summary>
    public string? GermanTitle { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }


    /// <summary>Abhängige Datensätze aus "Movie".</summary>
    public ICollection<Movie> Movie { get; set; } = new List<Movie>();

    /// <summary>Abhängige Datensätze aus "Person".</summary>
    public ICollection<Person> Person { get; set; } = new List<Person>();

    /// <summary>Abhängige Datensätze aus "Image".</summary>
    public ICollection<Image> Image { get; set; } = new List<Image>();

    /// <summary>Abhängige Datensätze aus "Series".</summary>
    public ICollection<Series> Series { get; set; } = new List<Series>();

    /// <summary>Abhängige Datensätze aus "Company".</summary>
    public ICollection<Company> Company { get; set; } = new List<Company>();

}
