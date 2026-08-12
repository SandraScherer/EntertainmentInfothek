namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Series_User".</summary>
public class SeriesUser : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "SeriesID".</summary>
    public string? SeriesID { get; set; }
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

    /// <summary>Navigation zur referenzierten Tabelle "Priority" (FK PriorityID).</summary>
    public Priority? Priority { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Series" (FK SeriesID).</summary>
    public Series? Series { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "User" (FK UserID).</summary>
    public User? User { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK UserStatusID).</summary>
    public Status? UserStatus { get; set; }
}
