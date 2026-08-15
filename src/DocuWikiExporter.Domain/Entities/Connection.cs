namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Connection".</summary>
public class Connection : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "Title".</summary>
    public string? Title { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "ConnectionID".</summary>
    public string? ConnectionID { get; set; }

    /// <summary>Navigation über FK ConnectionID → Connection.ID.</summary>
    public Connection? Connection { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Connection" verweisen.</summary>
    public ICollection<Book> BookByConnectionID { get; set; } = new List<Book>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Connection" verweisen.</summary>
    public ICollection<Connection> ConnectionByConnectionID { get; set; } = new List<Connection>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Connection" verweisen.</summary>
    public ICollection<Movie> MovieByConnectionID { get; set; } = new List<Movie>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Connection" verweisen.</summary>
    public ICollection<Series> SeriesByConnectionID { get; set; } = new List<Series>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Connection" verweisen.</summary>
    public ICollection<VideoGame> VideoGameByConnectionID { get; set; } = new List<VideoGame>();

}
