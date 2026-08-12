namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Movie_User".</summary>
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

    /// <summary>Navigation zur referenzierten Tabelle "Edition" (FK EditionID).</summary>
    public Edition? Edition { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Movie" (FK MovieID).</summary>
    public Movie? Movie { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Priority" (FK PriorityID).</summary>
    public Priority? Priority { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "User" (FK UserID).</summary>
    public User? User { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK UserStatusID).</summary>
    public Status? UserStatus { get; set; }
}
