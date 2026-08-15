namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "VideoGame_Language".</summary>
public class VideoGameLanguage : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "VideoGameID".</summary>
    public string? VideoGameID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "LanguageID".</summary>
    public string? LanguageID { get; set; }

    /// <summary>Navigation über FK LanguageID → Language.ID.</summary>
    public Language? Language { get; set; }

    /// <summary>Navigation über FK VideoGameID → VideoGame.ID.</summary>
    public VideoGame? VideoGame { get; set; }

}
