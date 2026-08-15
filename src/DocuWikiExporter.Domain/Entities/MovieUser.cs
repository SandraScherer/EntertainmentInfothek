namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Movie_User".</summary>
public class MovieUser : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "MovieID".</summary>
    public string? MovieID { get; set; }

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

    /// <summary>Navigation über FK MovieID → Movie.ID.</summary>
    public Movie? Movie { get; set; }

    /// <summary>Navigation über FK PriorityID → Priority.ID.</summary>
    public Priority? Priority { get; set; }

    /// <summary>Navigation über FK UserID → User.ID.</summary>
    public User? User { get; set; }

    /// <summary>Navigation über FK UserStatusID → Status.ID.</summary>
    public Status? StatusByUserStatusID { get; set; }

}
