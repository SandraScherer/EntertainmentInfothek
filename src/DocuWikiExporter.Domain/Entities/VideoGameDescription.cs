namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "VideoGame_Description".</summary>
public class VideoGameDescription : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "VideoGameID".</summary>
    public string? VideoGameID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "TextID".</summary>
    public string? TextID { get; set; }

    /// <summary>Navigation über FK TextID → Text.ID.</summary>
    public Text? Text { get; set; }

    /// <summary>Navigation über FK VideoGameID → VideoGame.ID.</summary>
    public VideoGame? VideoGame { get; set; }

}
