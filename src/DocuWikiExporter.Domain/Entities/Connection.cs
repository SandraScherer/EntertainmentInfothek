namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Connection".</summary>
public class Connection : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "Title".</summary>
    public string? Title { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "ConnectionID".</summary>
    public string? ConnectionID { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Connection" (FK ConnectionID).</summary>
    public Connection? Connection { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }


    /// <summary>Abhängige Datensätze aus "Movie".</summary>
    public ICollection<Movie> Movie { get; set; } = new List<Movie>();

    /// <summary>Abhängige Datensätze aus "Connection".</summary>
    public ICollection<Connection> Connection { get; set; } = new List<Connection>();

    /// <summary>Abhängige Datensätze aus "Series".</summary>
    public ICollection<Series> Series { get; set; } = new List<Series>();

}
