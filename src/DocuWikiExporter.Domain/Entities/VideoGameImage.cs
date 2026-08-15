namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "VideoGame_Image".</summary>
public class VideoGameImage : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "VideoGameID".</summary>
    public string? VideoGameID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "ImageID".</summary>
    public string? ImageID { get; set; }

    /// <summary>Navigation über FK ImageID → Image.ID.</summary>
    public Image? Image { get; set; }

    /// <summary>Navigation über FK VideoGameID → VideoGame.ID.</summary>
    public VideoGame? VideoGame { get; set; }

}
