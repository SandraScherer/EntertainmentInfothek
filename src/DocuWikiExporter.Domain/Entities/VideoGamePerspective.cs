namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "VideoGame_Perspective".</summary>
public class VideoGamePerspective : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "VideoGameID".</summary>
    public string? VideoGameID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "PerspectiveID".</summary>
    public string? PerspectiveID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "PlatformID".</summary>
    public string? PlatformID { get; set; }

    /// <summary>Navigation über FK PerspectiveID → Perspective.ID.</summary>
    public Perspective? Perspective { get; set; }

    /// <summary>Navigation über FK PlatformID → Platform.ID.</summary>
    public Platform? Platform { get; set; }

    /// <summary>Navigation über FK VideoGameID → VideoGame.ID.</summary>
    public VideoGame? VideoGame { get; set; }

}
