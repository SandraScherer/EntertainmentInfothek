namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Difficulty".</summary>
public class Difficulty : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "EnglishTitle".</summary>
    public string? EnglishTitle { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "GermanTitle".</summary>
    public string? GermanTitle { get; set; }

    /// <summary>Abhängige Datensätze, die über den entsprechenden Foreign Key auf "Difficulty" verweisen.</summary>
    public ICollection<VideoGameDifficulty> VideoGameDifficultyByDifficultyID { get; set; } = new List<VideoGameDifficulty>();

}
