namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "VideoGame_User".</summary>
public class VideoGameUser : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "VideoGameID".</summary>
    public string? VideoGameID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "UserID".</summary>
    public string? UserID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "EditionID".</summary>
    public string? EditionID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "UserStatusID".</summary>
    public string? UserStatusID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "PriorityID".</summary>
    public string? PriorityID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "Explanation".</summary>
    public string? Explanation { get; set; }

    /// <summary>Navigation über FK EditionID → Edition.ID.</summary>
    public Edition? Edition { get; set; }

    /// <summary>Navigation über FK PriorityID → Priority.ID.</summary>
    public Priority? Priority { get; set; }

    /// <summary>Navigation über FK UserID → User.ID.</summary>
    public User? User { get; set; }

    /// <summary>Navigation über FK UserStatusID → Status.ID.</summary>
    public Status? StatusByUserStatusID { get; set; }

    /// <summary>Navigation über FK VideoGameID → VideoGame.ID.</summary>
    public VideoGame? VideoGame { get; set; }

}
