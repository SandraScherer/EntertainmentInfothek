namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Episode_Description".</summary>
public class EpisodeDescription : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "EpisodeID".</summary>
    public string? EpisodeID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "TextID".</summary>
    public string? TextID { get; set; }

    /// <summary>Navigation über FK EpisodeID → Episode.ID.</summary>
    public Episode? Episode { get; set; }

    /// <summary>Navigation über FK TextID → Text.ID.</summary>
    public Text? Text { get; set; }

}
