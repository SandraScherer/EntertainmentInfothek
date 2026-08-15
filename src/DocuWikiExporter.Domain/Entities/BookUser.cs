namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Book_User".</summary>
public class BookUser : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "BookID".</summary>
    public string? BookID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "UserID".</summary>
    public string? UserID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "PublicationID".</summary>
    public string? PublicationID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "UserStatusID".</summary>
    public string? UserStatusID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "PriorityID".</summary>
    public string? PriorityID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "Explanation".</summary>
    public string? Explanation { get; set; }

    /// <summary>Navigation über FK BookID → Book.ID.</summary>
    public Book? Book { get; set; }

    /// <summary>Navigation über FK PriorityID → Priority.ID.</summary>
    public Priority? Priority { get; set; }

    /// <summary>Navigation über FK PublicationID → Publication.ID.</summary>
    public Publication? Publication { get; set; }

    /// <summary>Navigation über FK UserID → User.ID.</summary>
    public User? User { get; set; }

    /// <summary>Navigation über FK UserStatusID → Status.ID.</summary>
    public Status? StatusByUserStatusID { get; set; }

}
