namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Perspective".</summary>
public class Perspective : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "EnglishTitle".</summary>
    public string? EnglishTitle { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "GermanTitle".</summary>
    public string? GermanTitle { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Perspective" verweisen.</summary>
    public ICollection<VideoGamePerspective> VideoGamePerspectiveByPerspectiveID { get; set; } = new List<VideoGamePerspective>();

}
