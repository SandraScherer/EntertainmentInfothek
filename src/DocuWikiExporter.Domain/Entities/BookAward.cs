namespace DocuWikiExporter.Domain.Entities;

/// <summary>EF-Core-Entity für die bestehende SQLite-Tabelle "Book_Award".</summary>
public class BookAward : EntityBase
{
    /// <summary>Abbildung der SQLite-Spalte "BookID".</summary>
    public string? BookID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "AwardID".</summary>
    public string? AwardID { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "Category".</summary>
    public string? Category { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "Year".</summary>
    public string? Year { get; set; }

    /// <summary>Abbildung der SQLite-Spalte "Winner".</summary>
    public long? Winner { get; set; }

    /// <summary>Navigation über FK AwardID → Award.ID.</summary>
    public Award? Award { get; set; }

    /// <summary>Navigation über FK BookID → Book.ID.</summary>
    public Book? Book { get; set; }

}
