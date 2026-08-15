namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "VideoGame_Difficulty".</summary>
public class VideoGameDifficulty : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "VideoGameID".</summary>
    public string? VideoGameID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "DifficultyID".</summary>
    public string? DifficultyID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "PlatformID".</summary>
    public string? PlatformID { get; set; }

    /// <summary>Navigation über FK DifficultyID → Difficulty.ID.</summary>
    public Difficulty? Difficulty { get; set; }

    /// <summary>Navigation über FK PlatformID → Platform.ID.</summary>
    public Platform? Platform { get; set; }

    /// <summary>Navigation über FK VideoGameID → VideoGame.ID.</summary>
    public VideoGame? VideoGame { get; set; }

}
