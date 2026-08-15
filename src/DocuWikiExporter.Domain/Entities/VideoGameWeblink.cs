namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "VideoGame_Weblink".</summary>
public class VideoGameWeblink : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "VideoGameID".</summary>
    public string? VideoGameID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "WeblinkID".</summary>
    public string? WeblinkID { get; set; }

    /// <summary>Navigation über FK VideoGameID → VideoGame.ID.</summary>
    public VideoGame? VideoGame { get; set; }

    /// <summary>Navigation über FK WeblinkID → Weblink.ID.</summary>
    public Weblink? Weblink { get; set; }

}
