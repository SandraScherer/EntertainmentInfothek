namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Movie_Runtime".</summary>
public class MovieRuntime : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "MovieID".</summary>
    public string? MovieID { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "Runtime".</summary>
    public long? Runtime { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "EditionID".</summary>
    public string? EditionID { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Edition" (FK EditionID).</summary>
    public Edition? Edition { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Movie" (FK MovieID).</summary>
    public Movie? Movie { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }
}
