namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "User".</summary>
public class User : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "UserName".</summary>
    public string? UserName { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "EMail".</summary>
    public string? EMail { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "PersonID".</summary>
    public string? PersonID { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Person" (FK PersonID).</summary>
    public Person? Person { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }


    /// <summary>Abhängige Datensätze aus "Series_User".</summary>
    public ICollection<SeriesUser> SeriesUser { get; set; } = new List<SeriesUser>();

    /// <summary>Abhängige Datensätze aus "Movie_User".</summary>
    public ICollection<MovieUser> MovieUser { get; set; } = new List<MovieUser>();

}
