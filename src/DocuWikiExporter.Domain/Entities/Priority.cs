namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Priority".</summary>
public class Priority : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "EnglishTitle".</summary>
    public string? EnglishTitle { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "GermanTitle".</summary>
    public string? GermanTitle { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Priority" verweisen.</summary>
    public ICollection<BookUser> BookUserByPriorityID { get; set; } = new List<BookUser>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Priority" verweisen.</summary>
    public ICollection<MovieUser> MovieUserByPriorityID { get; set; } = new List<MovieUser>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Priority" verweisen.</summary>
    public ICollection<SeriesUser> SeriesUserByPriorityID { get; set; } = new List<SeriesUser>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Priority" verweisen.</summary>
    public ICollection<VideoGameUser> VideoGameUserByPriorityID { get; set; } = new List<VideoGameUser>();

}
