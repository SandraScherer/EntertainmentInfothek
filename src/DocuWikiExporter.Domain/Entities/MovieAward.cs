namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die unveränderte SQLite-Tabelle "Movie_Award".</summary>
public class MovieAward : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "MovieID".</summary>
    public string? MovieID { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "AwardID".</summary>
    public string? AwardID { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "Category".</summary>
    public string? Category { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "Date".</summary>
    public string? Date { get; set; }
    /// <summary>Abbildung der SQLite-Spalte "Winner".</summary>
    public long? Winner { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Award" (FK AwardID).</summary>
    public Award? Award { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Movie" (FK MovieID).</summary>
    public Movie? Movie { get; set; }

    /// <summary>Navigation zur referenzierten Tabelle "Status" (FK StatusID).</summary>
    public Status? Status { get; set; }


    /// <summary>Abhängige Datensätze aus "Movie_Award_Person".</summary>
    public ICollection<MovieAwardPerson> MovieAwardPerson { get; set; } = new List<MovieAwardPerson>();

}
