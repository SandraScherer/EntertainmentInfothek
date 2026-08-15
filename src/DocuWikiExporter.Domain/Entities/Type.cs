namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Type".</summary>
public class Type : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "EnglishTitle".</summary>
    public string? EnglishTitle { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "GermanTitle".</summary>
    public string? GermanTitle { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Type" verweisen.</summary>
    public ICollection<Book> BookByTypeID { get; set; } = new List<Book>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Type" verweisen.</summary>
    public ICollection<Company> CompanyByTypeID { get; set; } = new List<Company>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Type" verweisen.</summary>
    public ICollection<Image> ImageByTypeID { get; set; } = new List<Image>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Type" verweisen.</summary>
    public ICollection<Movie> MovieByTypeID { get; set; } = new List<Movie>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Type" verweisen.</summary>
    public ICollection<Person> PersonByTypeID { get; set; } = new List<Person>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Type" verweisen.</summary>
    public ICollection<Publication> PublicationByFormatID { get; set; } = new List<Publication>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Type" verweisen.</summary>
    public ICollection<Series> SeriesByTypeID { get; set; } = new List<Series>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Type" verweisen.</summary>
    public ICollection<Version> VersionByTypeID { get; set; } = new List<Version>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Type" verweisen.</summary>
    public ICollection<VideoGame> VideoGameByTypeID { get; set; } = new List<VideoGame>();

}
