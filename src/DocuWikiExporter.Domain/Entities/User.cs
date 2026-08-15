namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "User".</summary>
public class User : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "UserName".</summary>
    public string? UserName { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "EMail".</summary>
    public string? EMail { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "PersonID".</summary>
    public string? PersonID { get; set; }

    /// <summary>Navigation über FK PersonID → Person.ID.</summary>
    public Person? Person { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "User" verweisen.</summary>
    public ICollection<BookUser> BookUserByUserID { get; set; } = new List<BookUser>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "User" verweisen.</summary>
    public ICollection<MovieUser> MovieUserByUserID { get; set; } = new List<MovieUser>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "User" verweisen.</summary>
    public ICollection<SeriesUser> SeriesUserByUserID { get; set; } = new List<SeriesUser>();

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "User" verweisen.</summary>
    public ICollection<VideoGameUser> VideoGameUserByUserID { get; set; } = new List<VideoGameUser>();

}
