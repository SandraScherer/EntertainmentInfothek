namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "VideoGame_Completion".</summary>
public class VideoGameCompletion : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "VideoGameID".</summary>
    public string? VideoGameID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "CompletionID".</summary>
    public string? CompletionID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "PlatformID".</summary>
    public string? PlatformID { get; set; }

    /// <summary>Navigation über FK CompletionID → Status.ID.</summary>
    public Status? StatusByCompletionID { get; set; }

    /// <summary>Navigation über FK VideoGameID → VideoGame.ID.</summary>
    public VideoGame? VideoGame { get; set; }

}
